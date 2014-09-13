using System;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Collections;


namespace EAppService
{
	/// <summary>
	/// Handles the database related operations like Getting registered printers, 
	/// Registering a printer, Deregistering a printer, updating printer and job status.
	/// </summary>
	public class DBAccess
	{
		private const string CANCEL_JOB_STATUS = "5";
		private const string PROCESSING_JOB_STATUS = "2";
		/// <summary>
		/// Holds the database connection string.
		/// </summary>
		private string strConnection = null;
		
		/// <summary>
		/// The Constructor of the class takes the database connection string.
		/// </summary>
		/// <param name="strConnection">The database connection string.</param>
		public DBAccess(string strConnection)
		{
			// sets the connection string.
			this.strConnection = strConnection;
		}

		/// <summary>
		/// Return the Max Printer Id for a area code.
		/// </summary>
		/// <param name="strAreaCode">area code</param>
		/// <returns></returns>
		private string getMaxPrinterId(string strAreaCode)
		{
			string strMaxPrinterId = null;

			try
			{
				string strSQL = "select max(printer_id) from printer where area_code='" + strAreaCode + "'";

				SqlConnection sqlConn = new SqlConnection(this.strConnection);
				sqlConn.Open();
				
				SqlCommand sqlCmd = new SqlCommand(strSQL,sqlConn);
				SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();

				while(sqlDataReader.Read() )
				{
					strMaxPrinterId = sqlDataReader.GetString(0);
				}
				
				sqlDataReader.Close();
				sqlConn.Close();
			}
			catch(Exception err)
			{
				EASDebug.LogException("DBAccess::getMaxPrinterId()" + err.ToString() );
				throw err;
			}

			return strMaxPrinterId;
		}
	
		/// <summary>
		/// Get the print jobs for a printer.
		/// </summary>
		/// <param name="strAreaCode_PrinterId">JBH_101</param>
		/// <returns>The JobInfo Array</returns>
		public JobInfo[] getPrintJobs(string strAreaCode_PrinterId)
		{
			try
			{
				const string FAILED_JOB_STATUS = "4";
				// Given: PrinterId (JBH_101)
				// Get all jobs with PrinterId and job status = 4
				// Info : epthost, eptportno 
				string[] strData = strAreaCode_PrinterId.Split('_');
				
				string strSQL = 
					"select j1.job_id, j1.cost, j1.copies, j1.job_filename, j1.job_filesize, p1.ept_host_ip, p1.ept_host_portno from printer p1, jobinfo j1" +
					"where p1.area_code = '" + strData[0] + "' " + 
					"and p1.printer_id = '"  + strData[1] + "' " +
					"and j1.area_code = '"   + strData[0] + "' " +
					"and j1.printer_id = '"  + strData[1] + "' " +
					"and j1.job_status = '" + FAILED_JOB_STATUS + "' ";

				SqlConnection sqlConn = new SqlConnection(this.strConnection);
				sqlConn.Open();
				
				SqlCommand sqlCmd = new SqlCommand(strSQL,sqlConn);
				SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();

				Queue qJobs = new Queue();
					
				while(sqlDataReader.Read() )
				{
					JobInfo jobObj
					= new JobInfo(EASConstants.RT_NWJ,strAreaCode_PrinterId,
						sqlDataReader.GetString(0),
						sqlDataReader.GetString(1),
						sqlDataReader.GetString(2),
						sqlDataReader.GetString(3),
						sqlDataReader.GetString(4),
						sqlDataReader.GetString(5),
						sqlDataReader.GetString(6));

					qJobs.Enqueue(jobObj);
				}
				sqlDataReader.Close();
				sqlConn.Close();

				JobInfo[] jobInfo = new JobInfo[qJobs.Count];

				IEnumerator qEnumerator = qJobs.GetEnumerator();
				int iJobCount = 0;
				while ( qEnumerator.MoveNext() )
				{
					jobInfo[iJobCount] = (JobInfo) qEnumerator.Current;
					iJobCount++;
				}

				return jobInfo;	
			}
			catch(Exception err)
			{
				EASDebug.LogException("DBAccess::getPrintJobs()" + err.ToString() );
				throw err;
			}
		}

		/// <summary>
		/// Updates the printer status.
		/// </summary>
		/// <param name="strAreaCode"></param>
		/// <param name="strPrinterId"></param>
		/// <param name="strPrinterStatus"></param>
		/// <param name="strEPTHostIp"></param>
		/// <param name="strEPTPortNo"></param>
		public void updatePrinterStatus(string strAreaCode_PrinterId, string strPrinterStatus, string strEPTHostIp, string strEPTPortNo)
		{
			try
			{
				string[] strData = strAreaCode_PrinterId.Split('_');
				string strSQL = "update printer set printer_status = '" + strPrinterStatus + "', printer_status_date = getDate(), ept_host_ip = '" + strEPTHostIp + "', ept_host_portno = '"+ strEPTPortNo +"' where area_code ='" + strData[0] + "' and printer_id ='"+ strData[1] +"'";

				SqlConnection sqlConn = new SqlConnection(this.strConnection);
				sqlConn.Open();
				
				SqlCommand sqlCmd = new SqlCommand(strSQL, sqlConn);
				sqlCmd.ExecuteReader();

				sqlConn.Close();

			}
			catch(Exception err)
			{
				EASDebug.LogException("DBAccess::updatePrinterStatus()"+ err.ToString() );
				throw err;
			}
		}

		/// <summary>
		/// Updates the job status in the database.
		/// </summary>
		/// <param name="strAreaCode">The Area Code</param>
		/// <param name="strPrinterId">The Printer Id.</param>
		/// <param name="strJobId">The Job Id.</param>
		/// <param name="strJobStatus">The Job Status.</param>
		public void updateJobStatus(string strAreaCode_PrinterId, string strJobId, string strJobStatus)
		{
			try
			{
				string[] strData = strAreaCode_PrinterId.Split('_');
				string strSQL = "update jobinfo set job_status = '" + strJobStatus + "' where area_code ='" + strData[0] + "' and printer_id ='" + strData[1] + "' and job_id ='" + strJobId + "'";

				SqlConnection sqlConn = new SqlConnection(this.strConnection);
				sqlConn.Open();
				
				SqlCommand sqlCmd = new SqlCommand(strSQL, sqlConn);
				sqlCmd.ExecuteReader();

				sqlConn.Close();
			}
			catch(Exception err)
			{
				EASDebug.LogException("DBAccess::updateJobStatus()"+ err.ToString() );
				throw err;
			}
		}

		/// <summary>
		/// Cancels a print job.
		/// </summary>
		/// <param name="strJobId">The Job Id.</param>
		public void cancelPrintJob(string strJobId)
		{
			try
			{
				string strSQL = "update jobinfo set job_status = '" + CANCEL_JOB_STATUS + "' where job_id ='" + strJobId + "' and job_status = '" + PROCESSING_JOB_STATUS + "'";

				SqlConnection sqlConn = new SqlConnection(this.strConnection);
				sqlConn.Open();
				
				SqlCommand sqlCmd = new SqlCommand(strSQL, sqlConn);
				sqlCmd.ExecuteReader();

				sqlConn.Close();
			}
			catch(Exception err)
			{
				EASDebug.LogException("DBAccess::cancelPrintJob()"+ err.ToString() );
				throw err;
			}
		}

		/// <summary>
		/// Checks whether a job is cancelled or not.
		/// </summary>
		/// <param name="strJobId">The JOB Id.</param>
		/// <returns>True if job is cancelled false otherwise.</returns>
		public bool isJobCancelled(string strJobId)
		{
			bool bJobFlag = false;

			try
			{
				string strSQL = "select job_status from jobinfo where job_id = '" + strJobId + "'";

				SqlConnection sqlConn = new SqlConnection(this.strConnection);
				sqlConn.Open();
					
				SqlCommand sqlCmd = new SqlCommand(strSQL, sqlConn);
				SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();

				string strJobStatus = null;
				while(sqlDataReader.Read() )
				{
					strJobStatus = sqlDataReader.GetString(0);
					if ( strJobStatus.Equals(CANCEL_JOB_STATUS))
					{
						bJobFlag = true;
						break;
					}
					else
					{
						break;	
					}
				}
				
				sqlDataReader.Close();
				sqlConn.Close();
				return bJobFlag;
			}
			catch(Exception err)
			{
				EASDebug.LogException("DBAccess::cancelPrintJob()"+ err.ToString() );
				return bJobFlag;
			}
		}


		/// <summary>
		/// Insert New Print Job.
		/// </summary>
		/// <param name="strAreaCode_PrinterId">The printer id with area code.</param>
		/// <param name="strJobId">the job information</param>
		/// <param name="strCopies">the no of copies</param>
		/// <param name="strCost">the cost of the print job</param>
		/// <param name="strJobFileName">the job file name</param>
		/// <param name="strJobFileSize">the job file size</param>
		public void insertPrintJob(string strAreaCode_PrinterId, string strJobId, string strCopies, string strCost, string strJobFileName, string strJobFileSize)
		{
			try
			{
				string[] strData = strAreaCode_PrinterId.Split('_');
				
				string strSQL = "insert jobinfo (area_code, printer_id, job_id, copies, cost, job_filename, job_filesize) values " +
					"('" + strData[0] + "','" + strData[1] + "','" + strJobId + "'," + Int32.Parse(strCopies) + "," + Int32.Parse(strCost) + ",'" + strJobFileName + "','" + strJobFileSize + "')";
				
				SqlConnection sqlConn = new SqlConnection(this.strConnection);
				sqlConn.Open();
				
				SqlCommand sqlCmd = new SqlCommand(strSQL, sqlConn);
				sqlCmd.ExecuteReader();

				sqlConn.Close();
			}
			catch(Exception err)
			{
				EASDebug.LogException("DBAccess::insertPrintJob()"+ err.ToString() );
				throw err;
			}
		}

		/// <summary>
		/// Degisters a printer and sets the deregister flag to 'true'.
		/// </summary>
		/// <param name="strPrinterId">The Printer Id (areacode_printerid)</param>
		public void deRegisterPrinter(string strAreaCode_PrinterId)
		{
			try
			{
				string[] strData = strAreaCode_PrinterId.Split('_');
				string strSQL = "update printer set deregister = 'true' , deregister_date = getDate() where area_code ='" + strData[0] + "' and printer_id ='"+ strData[1] +"'";

				SqlConnection sqlConn = new SqlConnection(this.strConnection);
				sqlConn.Open();
				
				SqlCommand sqlCmd = new SqlCommand(strSQL, sqlConn);
				sqlCmd.ExecuteReader();

				sqlConn.Close();
			}
			catch(Exception err)
			{
				EASDebug.LogException("DBAccess::deRegisterPrinter()"+ err.ToString() );
				throw err;
			}
		}

		/// <summary>
		/// Registers a Printer.
		/// </summary>
		/// <param name="strAreaCode">The Area Code where the printer resides.</param>
		/// <param name="printerCap">The PrinterCap data object </param>
		/// <returns>The Printer Id</returns>
		public string registerPrinter(string strAreaCode, PrinterCap printerCap)
		{
			string strNewPrinterId = "101";

			try
			{
				string strMaxPrinterId = this.getMaxPrinterId(strAreaCode);

				// If the area code is new.
				if ( strMaxPrinterId != null)
				{
					strNewPrinterId = (Int64.Parse(strMaxPrinterId) + 1) + "";
				}
				else
				{
					// TODO: Validate area code.
				}

				string strSQL = "insert printer (area_code, printer_id, manufacturer, model, type, color, duplex, ept_host_ip, ept_host_portno) values " +
					"('" + strAreaCode + "','" + strNewPrinterId + "','" + printerCap.getManufacturer() + "','" + printerCap.getModel() + "','" + printerCap.getType() + "','" + printerCap.getColor() + "','" + printerCap.getDuplex() + "','" + printerCap.getEptHostIp() +"','" + printerCap.getEptPortNo() + "')";

				SqlConnection sqlConn = new SqlConnection(this.strConnection);
				sqlConn.Open();
				
				SqlCommand sqlCmd = new SqlCommand(strSQL, sqlConn);
				sqlCmd.ExecuteReader();

				sqlConn.Close();

				PaperInfo[] paperInfo = printerCap.getPaperInfo();

				for ( int iCnt = 0 ; iCnt < paperInfo.Length; iCnt++)
				{
					insertPaperInfo(strAreaCode, strNewPrinterId, paperInfo[iCnt]);
				}

				return strAreaCode + "_" + strNewPrinterId;
			}
			catch(Exception err)
			{
				EASDebug.LogException("DBAccess::registerPrinter()"+ err.ToString() );
				throw err;
			}
		}

		/// <summary>
		/// Inserts Paper information into the database.
		/// </summary>
		/// <param name="strEpcId">The EPC Id</param>
		/// <param name="strPrinterId">The Printer Id</param>
		/// <param name="paperInfo">The Paper Information data object.</param>
		/// <returns>0 - If no error occurs, 401 - If an error occurs.</returns>
		private void insertPaperInfo(string strAreaCode, string strPrinterId, PaperInfo paperInfo) 
		{
			try
			{
				string strSQL = "insert into paperinfo (area_code, printer_id, paper_size, paper_width, paper_height) values" +
					"('" + strAreaCode + "','" + strPrinterId + "','" + paperInfo.getSize() + "','" + paperInfo.getWidth() + "','" + paperInfo.getHeight() + "')";

				SqlConnection sqlConn = new SqlConnection(this.strConnection);
				sqlConn.Open();
				
				SqlCommand sqlCmd = new SqlCommand(strSQL, sqlConn);
				sqlCmd.ExecuteReader();

				sqlConn.Close();
			}
			catch(Exception err)
			{
				EASDebug.LogException("DBAccess::insertPaperInfo()"+ err.ToString() );
				throw err;
			}
		}

		/// <summary>
		/// Determines the validity of the printer.
		/// </summary>
		/// <param name="strPrinterId"></param>
		/// <returns>true - if printer is valid, false otherwise.</returns>
		public bool isPrinterIdValid(string strAreaCode_PrinterId)
		{
			// the first part contains the EPC id and the next part is printer id.
			string[] strData = strAreaCode_PrinterId.Split('_');
			bool bPrinterFlag = false;

			try
			{
				string strSQL = "select printer_id from printer where area_code='" + strData[0] + "' and printer_id = '" + strData[1] + "' and deregister = 'false'";

				SqlConnection sqlConn = new SqlConnection(this.strConnection);
				sqlConn.Open();
				
				SqlCommand sqlCmd = new SqlCommand(strSQL,sqlConn);
				SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();

				while(sqlDataReader.Read() )
				{
					string strVal = sqlDataReader.GetString(0);
			
					if ( strVal == null)
					{
						bPrinterFlag = false;
					}
					else
					{
						bPrinterFlag = true;
					}
				}
				
				sqlDataReader.Close();
				sqlConn.Close();

				
			}
			catch(Exception err)
			{
				EASDebug.LogException("DBAccess::isPrinterIdValid()" + err.ToString() );
				bPrinterFlag = false;
			}

			return bPrinterFlag;

		}

	}
}
