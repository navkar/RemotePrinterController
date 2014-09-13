using System;
using System.Text;

namespace EAppService
{
	/// <summary>
	/// Generates XML messages for NWJ and responses.
	/// </summary>
	public class ResponseHandlers
	{
		public ResponseHandlers()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// Returns the New Job Information in XML.
		/// </summary>
		/// <param name="jobInfo">the job info data object.</param>
		/// <returns>XML data as a string</returns>
		public static string GenerateNWJRequest(JobInfo jobInfo)
		{
			if ( jobInfo != null)
			{
				StringBuilder sb = new StringBuilder();		

				sb.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\" standalone=\"yes\"?>");
				sb.Append(EASConstants.CRLF);
			
				sb.Append("<" + EASConstants.XT_PRINTSERVER + ">");
				sb.Append(EASConstants.CRLF);

				//Request
				sb.Append("<" + EASConstants.XT_REQUEST + ">");
				sb.Append(	jobInfo.getRequest() );
				sb.Append("</" + EASConstants.XT_REQUEST + ">");
				sb.Append(EASConstants.CRLF);
			
				//Printer Id
				sb.Append("<" + EASConstants.XT_PRINTERID + ">");
				sb.Append( jobInfo.getAreaCode_PrinterId() );
				sb.Append("</" + EASConstants.XT_PRINTERID + ">");
				sb.Append(EASConstants.CRLF);

				//Job Info
				sb.Append("<" + EASConstants.XT_JOBINFO + " "); 
				sb.Append(EASConstants.XT_JIID + "=\""+ jobInfo.getJobId() +"\" ");
				sb.Append(EASConstants.XT_COST + "=\""+ jobInfo.getJobCost() +"\" ");
				sb.Append(EASConstants.XT_COPIES + "=\""+ jobInfo.getJobCopies() +"\">");
				sb.Append("</" + EASConstants.XT_JOBINFO + ">");
				sb.Append(EASConstants.CRLF);

				//File Info
				sb.Append("<" + EASConstants.XT_FILEINFO + " "); 
				sb.Append(EASConstants.XT_FILENAME + "=\""+ jobInfo.getFileName() +"\" ");
				sb.Append(EASConstants.XT_FILESIZE + "=\""+ jobInfo.getFileSize() +"\">");
				sb.Append("</" + EASConstants.XT_FILEINFO + ">");
				sb.Append(EASConstants.CRLF);

				//EPT Host IP
				sb.Append("<" + EASConstants.XT_EPTHOSTIP + ">"); 
				sb.Append(jobInfo.getEPTHostIp().Trim() );
				sb.Append("</" + EASConstants.XT_EPTHOSTIP + ">");
				sb.Append(EASConstants.CRLF);

				//EPT Port No
				sb.Append("<" + EASConstants.XT_EPTPORTNO + ">"); 
				sb.Append(jobInfo.getEPTPortNo().Trim() );
				sb.Append("</" + EASConstants.XT_EPTPORTNO + ">");
				sb.Append(EASConstants.CRLF);

				sb.Append("</" + EASConstants.XT_PRINTSERVER + ">");
				sb.Append(EASConstants.CRLF);

				return sb.ToString();
			}
			else 
			{
				return "";
			}

		}

		/// <summary>
		/// Generates the EPT Responses.
		/// </summary>
		/// <param name="iReturnCode">Return code</param>
		/// <param name="strRequest">The request type</param>
		/// <param name="strPrinterId">The AreaCode_PrinterId</param>
		/// <returns>The XML reply message.</returns>
		public static string EPTResponse(int iReturnCode, string strRequest, string strPrinterId)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\" standalone=\"yes\"?>");
			sb.Append(EASConstants.CRLF);
			
			sb.Append("<" + EASConstants.XT_PRINTSERVER + ">");
			sb.Append(EASConstants.CRLF);

			sb.Append("<" + EASConstants.XT_RETURNCODE + ">");
			sb.Append(iReturnCode);
			sb.Append("</" + EASConstants.XT_RETURNCODE + ">");
			sb.Append(EASConstants.CRLF);

			sb.Append("<" + EASConstants.XT_REQUEST + ">");
			sb.Append(strRequest);
			sb.Append("</" + EASConstants.XT_REQUEST + ">");
			sb.Append(EASConstants.CRLF);

			sb.Append("<" + EASConstants.XT_PRINTERID + ">");
			sb.Append(strPrinterId);
			sb.Append("</" + EASConstants.XT_PRINTERID + ">");
			sb.Append(EASConstants.CRLF);

			sb.Append("</" + EASConstants.XT_PRINTSERVER + ">");
			sb.Append(EASConstants.CRLF);

			return sb.ToString();
		}

	}
}
