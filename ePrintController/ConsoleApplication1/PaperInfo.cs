using System;

namespace EAppService
{
	/// <summary>
	/// Summary description for PaperInfo.
	/// </summary>
	public class PaperInfo
	{
		private string strSize = null;
		private string strWidth = null;
		private string strHeight = null;

		public string getSize()
		{
			return this.strSize;
		}
	
		public string getWidth()
		{
			return this.strWidth;
		}

		public string getHeight()
		{
			return this.strHeight;
		}

		public PaperInfo(string strSize, string strWidth, string strHeight)
		{
			this.strSize = strSize;
			this.strWidth = strWidth;
			this.strHeight = strHeight;
		}

		public override string ToString()
		{
			return "strSize:" + strSize + "\nstrWidth:"+ strWidth + "\nstrHeight: " + strHeight;
		}

	}
}
