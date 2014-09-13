using System;
using System.IO;
using System.Xml;
using System.Threading;

namespace EPrinterTerminal
{
	/// <summary>
	/// Summary description for EPTPollingProcess.
	/// </summary>
	public class EPTPollingProcess
	{
		private string strHostName = null;
		private int iPortNo = 0;
		private string strPrinterId = null;
		private int iPollFreq = 0;
		private FrmEPrinterTerminal parent = null;

		public EPTPollingProcess(string strHostName, int iPortNo, 
								string strPrinterId, int iPollFreq, 
								FrmEPrinterTerminal parent)
		{
			this.strHostName = strHostName;
			this.iPortNo = iPortNo;
			this.strPrinterId = strPrinterId;
			this.iPollFreq = iPollFreq;
			this.parent = parent;
		}

		/// <summary>
		/// this should run as a background thread.
		/// </summary>
		public void RunForLife()
		{
			try
			{
				ConnectionManager cMgr 
					= new ConnectionManager(this.strHostName, this.iPortNo);

				while(true)
				{
					// NPS :: 1 - Ready, 0 - Not Ready.
					string strNPSResponse = 
						cMgr.sendPostRequest(				// NPS - 1.
						EPTXmlRequest.GetNPSRequest(this.strPrinterId,"1") );
				
					EPTDebug.LogException("NPS:"+ strNPSResponse);

					// NWJ
					parent.SetStatusBarText("Searching for new jobs...");

					string strNWJResponse = 
						cMgr.sendPostRequest(				
						EPTXmlRequest.GetRequest(EPTConstants.RT_NWJ, strPrinterId) );

					EPTDebug.LogException("NWJ:"+ strNWJResponse);
				
					StringReader sr = new StringReader(strNWJResponse);
					XmlTextReader xtr = new XmlTextReader(sr);
					XmlResponseParser xrp = new XmlResponseParser(xtr);
							 
					string strReturnCode = xrp.getReturnCode();
					parent.SetStatusBarText(parent.getRCDescription(strReturnCode) );

					// Go for GJF request.
					if ( strReturnCode.Equals("200"))
					{
						// GJF
						int iFileSize = Int32.Parse(xrp.getFileSize());
	
						string strGJFRequest 
							= EPTXmlRequest.GetGJFRequest(xrp.getPrinterId(),
														xrp.getJobId(),
														xrp.getFileName() 
														);
						
						// create a directory (jobid) under current directory and
						// save the file under that.
						cMgr.sendGetJobFileRequest(iFileSize, 
											xrp.getFileName(), 
											strGJFRequest);
				
						// NJS :: 1 - Success, 2 - Re-try, 3 - Processing.
						string strNJSResponse = 
							cMgr.sendPostRequest(	
							EPTXmlRequest.GetNJSRequest(this.strPrinterId,"213","1") );

					}
				
					// wait for some time, before u start polling again.
					Thread.Sleep(iPollFreq);
				}

			}
			catch(Exception e)
			{
				EPTDebug.LogException(e.ToString() );
			}
		}

	}
}
