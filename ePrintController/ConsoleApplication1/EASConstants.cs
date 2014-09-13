using System;

namespace EAppService
{
	/// <summary>
	/// Summary description for EASConstants.
	/// XT - Xml Tag.
	/// </summary>
	public class EASConstants
	{
		/// <summary>
		/// Carriage Return and Line Feed.
		/// </summary>
		public static string CRLF = "\r\n";

		/// <summary>
		/// EPT Host Ip.
		/// </summary>
		public static string XT_EPTHOSTIP  = "EPTHostIp";

		/// <summary>
		/// EPT Port No.
		/// </summary>
		public static string XT_EPTPORTNO  = "EPTPortNo";

		/// <summary>
		/// The Area Code.
		/// </summary>
		public static string XT_AREACODE  = "AreaCode";

		/// <summary>
		/// Print Server tag.
		/// </summary>
		public static string XT_PRINTSERVER = "PrintServer";
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
		/// jobId
		/// </summary>
		public static string XT_JIID = "jobId";

		/// <summary>
		/// cost
		/// </summary>
		public static string XT_COST = "cost";

		/// <summary>
		/// copies
		/// </summary>
		public static string XT_COPIES = "copies";

		/// <summary>
		/// jobStatus
		/// </summary>
		public static string XT_JISTATUS = "jobStatus";

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
		/// file name
		/// </summary>
		public static string XT_FILENAME = "name";
	
		/// <summary>
		/// file size
		/// </summary>
		public static string XT_FILESIZE = "size";

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

	}
}
