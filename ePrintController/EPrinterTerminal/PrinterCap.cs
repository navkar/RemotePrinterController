using System;

namespace EPrinterTerminal
{
	/// <summary>
	/// Summary description for PrinterCap.
	/// </summary>
	public class PrinterCap
	{
		private string strAreaCode = null;
		private string strEptHostIp = null;
		private string strEptPortNo = null;
		private string strManufacturer = null;
		private string strModel = null;
		private string strType = null;
		private string strColor = null;
		private string strDuplex = null;
		private PaperInfo[] paperInfo = null;

		public string getAreaCode()
		{
			return this.strAreaCode;
		}

		public string getEptHostIp()
		{
			return this.strEptHostIp;
		}

		public string getEptPortNo()
		{
			return this.strEptPortNo;
		}

		public string getManufacturer()
		{
				return this.strManufacturer;
		}

		public string getModel()
		{
				return this.strModel;
		}

		public string getType()
		{
				return this.strType;
		}

		public string getColor()
		{
			return this.strColor;
		}

		public string getDuplex()
		{
			return this.strDuplex;
		}
		
		public PaperInfo[] getPaperInfo()
		{
			return this.paperInfo;
		}

		public PrinterCap(string strAreaCode,
							string strEptHostIp,
							string strEptPortNo,
							string strManufacturer,
							string strModel,
							string strType,
							string strColor,
							string strDuplex,
							PaperInfo[] paperInfo)
			
		{
			this.strAreaCode = strAreaCode;
			this.strEptHostIp = strEptHostIp;
			this.strEptPortNo = strEptPortNo; 
			this.strManufacturer = strManufacturer;
			this.strModel = strModel;
			this.strType = strType;
			this.strColor = strColor;
			this.strDuplex = strDuplex;
			this.paperInfo = paperInfo;
		}
	}
}
