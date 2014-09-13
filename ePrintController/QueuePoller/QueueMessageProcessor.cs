using System;
using System.Data;
using System.Xml;
using System.Resources;
using System.IO;
using System.Messaging;
using System.Threading;	
using EAppService;

namespace JobQueueController
{
	/// <summary>
	/// Summary description for QueueMessageProcessor.
	/// </summary>
	public class QueueMessageProcessor
	{
		private string strNewJobMessage = null;
		private string strDbConn = null;
		private const string FAILED_JOB_STATUS = "4";
		private const string PRINTER_NOTREADY = "0";

		public QueueMessageProcessor(string strDbConn, string strNewJobMessage)
		{
			this.strDbConn = strDbConn;
			this.strNewJobMessage = strNewJobMessage;
			Thread thrdStartProcessing = new Thread(new ThreadStart(this.process));
			thrdStartProcessing.Name = "QueueMessageProcessor";
			thrdStartProcessing.Start();
		}

		private void process()
		{
			try
			{
				EASDebug.LogException("New thread started...");
				StringReader sr = new StringReader(this.strNewJobMessage);
				XmlTextReader xtr = new XmlTextReader(sr);
				// Parse the XML data.
				EASXmlReader easXmlReader = new EASXmlReader(xtr);		

				string strEPTHostIp = easXmlReader.getEPTHostIp();
				string strEPTPortNo = easXmlReader.getEPTPortNo();
				string strAreaCode_PrinterId = easXmlReader.getPrinterId();

				EASDebug.LogException("strEPTHostIp: " + strEPTHostIp );
				EASDebug.LogException("strEPTPortNo: " + strEPTPortNo);
				EASDebug.LogException("strAreaCode_PrinterId: " + strAreaCode_PrinterId);
	
				try
				{	
					TCPClient client = new TCPClient(strEPTHostIp, Int32.Parse(strEPTPortNo));
					string strResponse = client.sendMessageToEPT(this.strNewJobMessage);
					EASDebug.LogException("Response from EPT: " + strResponse);
				}
				catch(Exception e)
				{
					EASDebug.LogException("TCP Client Exception: " +  e.ToString() );
					// Update the job status to 4.
					DBAccess dba = new DBAccess(this.strDbConn);
					dba.updatePrinterStatus(strAreaCode_PrinterId, PRINTER_NOTREADY, strEPTHostIp, strEPTPortNo);
					dba.updateJobStatus(strAreaCode_PrinterId, easXmlReader.getJobId(), FAILED_JOB_STATUS );
				}
				
				EASDebug.LogException("Thread execution complete.");
			}
			catch(Exception e)
			{
				EASDebug.LogException("QMsgProcessor Exception: " +  e.ToString() );
			}
		}

	}
}
