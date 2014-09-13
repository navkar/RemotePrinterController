using System;
using System.Windows.Forms;

namespace EPrinterTerminal
{
	/// <summary>
	/// Summary description for EPCConstants.
	/// XT - Xml Tag.
	/// </summary>
	public class EPTConstants
	{

		public static string ENTRY_POINT = "/eas/eas.aspx";

		/// <summary>
		/// The 'CONFIG' directory shall contain all the .ico and .xml files.
		/// </summary>
		public static string APP_CONFIG_PATH = Application.StartupPath + "\\CONFIG" + "\\";

		/// <summary>
		/// 'EptConfig.xml'
		/// </summary>
		public static string APP_CONFIG_NAME = "EptConfig.xml";
		
		/// <summary>
		/// The boundary string.
		/// </summary>
		public static string BOUNDARY = "1234PQRS";
		
		/// <summary>
		/// Carriage Return and Line Feed.
		/// </summary>
		public static string CRLF = "\r\n";

		/// <summary>
		/// Area Code
		/// </summary>
		public static string XT_AREACODE = "AreaCode";

		/// <summary>
		/// EPT Host Ip
		/// </summary>
		public static string XT_EPTHOSTIP = "EPTHostIp";
		
		/// <summary>
		/// EPT Port No
		/// </summary>
		public static string XT_EPTPORTNO = "EPTPortNo";
		
		/// <summary>
		/// Print Server tag.
		/// </summary>
		public static string XT_PRINTSERVER = "PrintServer";

		/// <summary>
		/// Print Server tag.
		/// </summary>
		public static string XT_PRINTERTERMINAL = "PrinterTerminal";

		/// <summary>
		/// Return code RC tag.
		/// </summary>
		public static string XT_RETURNCODE	= "RC";
		/// <summary>
		/// Request Xml Tag.
		/// </summary>
		public static string XT_REQUEST = "Request";	

		/// <summary>
		/// PrinterId
		/// </summary>
		public static string XT_PRINTERID = "PrinterId";

		/// <summary>
		/// PrinterCap
		/// </summary>
		public static string XT_PRINTERCAP = "PrinterCap";

		/// <summary>
		/// manufacturer
		/// </summary>
		public static string XT_PCMF = "manufacturer";

		/// <summary>
		/// model
		/// </summary>
		public static string XT_PCMODEL = "model";

		/// <summary>
		/// type
		/// </summary>
		public static string XT_PCTYPE = "type";

		/// <summary>
		/// color
		/// </summary>
		public static string XT_PCCOLOR = "color";

		/// <summary>
		/// duplex
		/// </summary>
		public static string XT_PCDUPLEX = "duplex";

		/// <summary>
		/// PaperInfo
		/// </summary>
		public static string XT_PAPERINFO = "PaperInfo";

		/// <summary>
		/// size
		/// </summary>
		public static string XT_PISIZE = "size";

		/// <summary>
		/// width
		/// </summary>
		public static string XT_PIWIDTH = "width";

		/// <summary>
		/// height
		/// </summary>
		public static string XT_PIHEIGHT = "height";

		/// <summary>
		/// JobInfo
		/// </summary>
		public static string XT_JOBINFO = "JobInfo";

		/// <summary>
		/// JobStatus
		/// </summary>
		public static string XT_JISTATUS = "jobStatus";
		

		/// <summary>
		/// jobId
		/// </summary>
		public static string XT_JIID = "jobId";

		/// <summary>
		/// cost
		/// </summary>
		public static string XT_JCOST = "cost";

		/// <summary>
		/// cost
		/// </summary>
		public static string XT_JCOPIES = "copies";

		/// <summary>
		/// PrinterInfo
		/// </summary>
		public static string XT_PRINTERINFO = "PrinterInfo";

		/// <summary>
		/// printerStatus
		/// </summary>
		public static string XT_PISTATUS = "printerStatus";

		/// <summary>
		/// FileInfo
		/// </summary>
		public static string XT_FILEINFO = "FileInfo";

		/// <summary>
		/// name
		/// </summary>
		public static string XT_FILENAME = "name";
	
		/// <summary>
		/// name
		/// </summary>
		public static string XT_FILESIZE = "size";

		/// <summary>
		/// empty job info string.
		/// </summary>
		public static string XT_EMPTY_JOBINFO = "<JobInfo jobId=\"\" cost=\"\" copies=\"\" />";

		/// <summary>
		/// empty file info string.
		/// </summary>
		public static string XT_EMPTY_FILEINFO = "<FileInfo name=\"\" size=\"\"/>";

		/// <summary>
		/// Get Registered Printers.
		/// </summary>
		public const string RT_GRP = "GRP";

		/// <summary>
		/// Register Printer request.
		/// </summary>
		public const string RT_RPR = "RPR";

		/// <summary>
		/// Delete printer request.
		/// </summary>
		public const string RT_DPR = "DPR";

		/// <summary>
		/// Get job file request.
		/// </summary>
		public const string RT_GJF = "GJF";
		
		/// <summary>
		/// Notify job status.
		/// </summary>
		public const string RT_NJS = "NJS";

		/// <summary>
		/// Notify Printer status.
		/// </summary>
		public const string RT_NPS = "NPS";

		/// <summary>
		/// New print job request.
		/// </summary>
		public const string RT_NWJ = "NWJ";

		public const string OPT_OTHERS = "Others";
		public const string OPT_INKJET = "Inkjet";
		public const string OPT_LASER = "Laser";
		public const string OPT_YES = "Yes";
		public const string OPT_NO = "No";






	}
}
