using System;
using System.Text;

namespace EPrinterTerminal
{
	/// <summary>
	/// Generates various XML requests.
	/// </summary>
	public class EPTXmlRequest
	{
		public EPTXmlRequest()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="printerCap">The printer capabilities data.</param>
		/// <returns>The RPR request in XML.</returns>
		public static string GetRPRRequest(PrinterCap printerCap)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\" standalone=\"yes\"?>");
			sb.Append(EPTConstants.CRLF);
	
			sb.Append("<" + EPTConstants.XT_PRINTERTERMINAL + ">");
			sb.Append(EPTConstants.CRLF);

			sb.Append("<" + EPTConstants.XT_REQUEST + ">");
			sb.Append(EPTConstants.RT_RPR);
			sb.Append("</" + EPTConstants.XT_REQUEST + ">");
			sb.Append(EPTConstants.CRLF);

			sb.Append("<" + EPTConstants.XT_PRINTERID + ">");
			sb.Append("</" + EPTConstants.XT_PRINTERID + ">");
			sb.Append(EPTConstants.CRLF);

			// Printer Capability Information.
			sb.Append("<" + EPTConstants.XT_PRINTERCAP + " " + EPTConstants.XT_PCMF + "=\"" + printerCap.getManufacturer() + "\"");
			sb.Append(" " + EPTConstants.XT_PCMODEL + "=\"" + printerCap.getModel() + "\"");
			sb.Append(" " + EPTConstants.XT_PCTYPE + "=\"" + printerCap.getType() + "\"");
			sb.Append(" " + EPTConstants.XT_PCCOLOR + "=\"" + printerCap.getColor() + "\"");
			sb.Append(" " + EPTConstants.XT_PCDUPLEX + "=\"" + printerCap.getDuplex() + "\">");
			sb.Append(EPTConstants.CRLF);

			PaperInfo[] pi = printerCap.getPaperInfo();

			for (int iCnt=0; iCnt < pi.Length ; iCnt++)
			{
				sb.Append("<" + EPTConstants.XT_PAPERINFO + " " + EPTConstants.XT_PISIZE + "=\"" + pi[iCnt].getSize() + "\"");
				sb.Append(" " + EPTConstants.XT_PIWIDTH + "=\"" + pi[iCnt].getWidth() + "\"");
				sb.Append(" " + EPTConstants.XT_PIHEIGHT + "=\"" + pi[iCnt].getHeight() + "\"/>");
				sb.Append(EPTConstants.CRLF);
			}
			
			sb.Append("</" + EPTConstants.XT_PRINTERCAP + ">");
			sb.Append(EPTConstants.CRLF);

			sb.Append("<" + EPTConstants.XT_EPTHOSTIP + ">");
			sb.Append(printerCap.getEptHostIp() );
			sb.Append("</" + EPTConstants.XT_EPTHOSTIP + ">");
			sb.Append(EPTConstants.CRLF);

			sb.Append("<" + EPTConstants.XT_EPTPORTNO + ">");
			sb.Append(printerCap.getEptPortNo() );
			sb.Append("</" + EPTConstants.XT_EPTPORTNO + ">");
			sb.Append(EPTConstants.CRLF);

			sb.Append("<" + EPTConstants.XT_AREACODE + ">");
			sb.Append(printerCap.getAreaCode());
			sb.Append("</" + EPTConstants.XT_AREACODE + ">");
			sb.Append(EPTConstants.CRLF);

			sb.Append("</" + EPTConstants.XT_PRINTERTERMINAL + ">");
			sb.Append(EPTConstants.CRLF);

			return sb.ToString();
		}

		/// <summary>
		/// Used for generating DPR requests.
		/// </summary>
		/// <param name="strPrinterId">The Printer Id. (For eg: HM1234_123)</param>
		/// <returns></returns>
		public static string GetDPRRequest(string strPrinterId)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\" standalone=\"yes\"?>");
			sb.Append(EPTConstants.CRLF);
	
			sb.Append("<" + EPTConstants.XT_PRINTERTERMINAL + ">");
			sb.Append(EPTConstants.CRLF);

			sb.Append("<" + EPTConstants.XT_REQUEST + ">");
			sb.Append(EPTConstants.RT_DPR);
			sb.Append("</" + EPTConstants.XT_REQUEST + ">");
			sb.Append(EPTConstants.CRLF);

			sb.Append("<" + EPTConstants.XT_PRINTERID + ">");
			sb.Append(strPrinterId);
			sb.Append("</" + EPTConstants.XT_PRINTERID + ">");
			sb.Append(EPTConstants.CRLF);

			sb.Append("</" + EPTConstants.XT_PRINTERTERMINAL + ">");
			sb.Append(EPTConstants.CRLF);

			return sb.ToString();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strPrinterId"></param>
		/// <param name="strJobId"></param>
		/// <param name="strFileName"></param>
		/// <returns></returns>
		public static string GetGJFRequest(string strPrinterId, 
											string strJobId, string strFileName)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\" standalone=\"yes\"?>");
			sb.Append(EPTConstants.CRLF);
	
			sb.Append("<" + EPTConstants.XT_PRINTERTERMINAL + ">");
			sb.Append(EPTConstants.CRLF);

			sb.Append("<" + EPTConstants.XT_REQUEST + ">");
			sb.Append(EPTConstants.RT_GJF);
			sb.Append("</" + EPTConstants.XT_REQUEST + ">");
			sb.Append(EPTConstants.CRLF);

			sb.Append("<" + EPTConstants.XT_PRINTERID + ">");
			sb.Append(strPrinterId);
			sb.Append("</" + EPTConstants.XT_PRINTERID + ">");
			sb.Append(EPTConstants.CRLF);

			//	Job Information.
			sb.Append("<" + EPTConstants.XT_JOBINFO + " " + EPTConstants.XT_JIID + "=\"" + strJobId + "\"");
			sb.Append(" " + EPTConstants.XT_JISTATUS + "=\"" +  "\"/>");
			// File Information.
			sb.Append("<" + EPTConstants.XT_FILEINFO + " " + EPTConstants.XT_FILENAME + "=\"" + strFileName + "\"/>");
			
			sb.Append("</" + EPTConstants.XT_PRINTERTERMINAL + ">");
			sb.Append(EPTConstants.CRLF);

			return sb.ToString();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strPrinterId"></param>
		/// <param name="strJobId"></param>
		/// <param name="strJobStatus"></param>
		/// <returns></returns>
		public static string GetNJSRequest(string strPrinterId, string strJobId, 
											string strJobStatus)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\" standalone=\"yes\"?>");
			sb.Append(EPTConstants.CRLF);
	
			sb.Append("<" + EPTConstants.XT_PRINTERTERMINAL + ">");
			sb.Append(EPTConstants.CRLF);

			sb.Append("<" + EPTConstants.XT_REQUEST + ">");
			sb.Append(EPTConstants.RT_NJS);
			sb.Append("</" + EPTConstants.XT_REQUEST + ">");
			sb.Append(EPTConstants.CRLF);

			sb.Append("<" + EPTConstants.XT_PRINTERID + ">");
			sb.Append(strPrinterId);
			sb.Append("</" + EPTConstants.XT_PRINTERID + ">");
			sb.Append(EPTConstants.CRLF);

			//	Job Information.
			sb.Append("<" + EPTConstants.XT_JOBINFO + " " + EPTConstants.XT_JIID + "=\"" + strJobId + "\"");
			sb.Append(" " + EPTConstants.XT_JISTATUS + "=\"" + strJobStatus + "\"/>");
		
			sb.Append("</" + EPTConstants.XT_PRINTERTERMINAL + ">");
			sb.Append(EPTConstants.CRLF);

			return sb.ToString();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strPrinterId"></param>
		/// <param name="strPrinterStatus"></param>
		/// <returns></returns>
		public static string GetNPSRequest(string strPrinterId, string strPrinterStatus, string strEPTHostIp, string strEPTPortNo)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("<?xml version=\"1.0\" encoding=\"ISO-8859-1\" standalone=\"yes\"?>");
			sb.Append(EPTConstants.CRLF);
	
			sb.Append("<" + EPTConstants.XT_PRINTERTERMINAL + ">");
			sb.Append(EPTConstants.CRLF);

			sb.Append("<" + EPTConstants.XT_REQUEST + ">");
			sb.Append(EPTConstants.RT_NPS);
			sb.Append("</" + EPTConstants.XT_REQUEST + ">");
			sb.Append(EPTConstants.CRLF);

			sb.Append("<" + EPTConstants.XT_PRINTERID + ">");
			sb.Append(strPrinterId);
			sb.Append("</" + EPTConstants.XT_PRINTERID + ">");
			sb.Append(EPTConstants.CRLF);

			//	Printer Information.
			sb.Append("<" + EPTConstants.XT_PRINTERINFO + " " + EPTConstants.XT_PISTATUS + "=\"" + strPrinterStatus + "\"/>");
			sb.Append(EPTConstants.CRLF);

			sb.Append("<" + EPTConstants.XT_EPTHOSTIP + ">");
			sb.Append(strEPTHostIp );
			sb.Append("</" + EPTConstants.XT_EPTHOSTIP + ">");
			sb.Append(EPTConstants.CRLF);

			sb.Append("<" + EPTConstants.XT_EPTPORTNO + ">");
			sb.Append(strEPTPortNo );
			sb.Append("</" + EPTConstants.XT_EPTPORTNO + ">");
			sb.Append(EPTConstants.CRLF);
		
			sb.Append("</" + EPTConstants.XT_PRINTERTERMINAL + ">");
			sb.Append(EPTConstants.CRLF);

			return sb.ToString();
		}

	}
}
