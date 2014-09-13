using System;

namespace EAppService
{
	/// <summary>
	/// The Job Information data object.
	/// </summary>
	public class JobInfo
	{
		private string strRequest = null;
		private string strAreaCode_PrinterId = null;
		private string strJobId = null;
		private string strJobCost = null;
		private string strJobCopies = null;
		private string strFileName = null;
		private string strFileSize = null;
		private string strEPTHostIp = null;
		private string strEPTPortNo = null;
		
		public JobInfo(string strRequest,
				string strAreaCode_PrinterId,
				string strJobId,
				string strJobCost,
				string strJobCopies,
				string strFileName,
				string strFileSize,	
				string strEPTHostIp,
				string strEPTPortNo)
		{
				this.strRequest = strRequest;
				this.strAreaCode_PrinterId = strAreaCode_PrinterId;
				this.strJobId = strJobId;
				this.strJobCost = strJobCost;
				this.strJobCopies = strJobCopies;
				this.strFileName = strFileName;
				this.strFileSize = strFileSize;
				this.strEPTHostIp = strEPTHostIp;
				this.strEPTPortNo = strEPTPortNo;
		}

		public string getRequest()
		{
			return this.strRequest;
		}

		public string getAreaCode_PrinterId()
		{
			return this.strAreaCode_PrinterId;
		}

		public string getJobId()
		{
			return this.strJobId;
		}

		public string getJobCost()
		{
			return this.strJobCost;			
		}

		public string getJobCopies()
		{
			return this.strJobCopies;
		}

		public string getFileName()
		{
			return this.strFileName;
		}

		public string getFileSize()
		{
			return this.strFileSize;
		}

		public string getEPTHostIp()
		{
			return this.strEPTHostIp;
		}

		public string getEPTPortNo()
		{
			return this.strEPTPortNo;
		}
	}
}
