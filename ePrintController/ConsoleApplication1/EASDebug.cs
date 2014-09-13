using System;
using System.IO;

namespace EAppService
{
	/// <summary>
	/// Used for logging exceptional and informational messages.
	/// </summary>
	public class EASDebug
	{
		/// <summary>
		/// default EAS Log File Name.
		/// </summary>
		private static string strLogFileName = "eas.log";
		
		public EASDebug()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// Sets the log file name.
		/// </summary>
		/// <param name="strFileName"></param>
		public static void setLogFileName(string strFileName)
		{
			strLogFileName = strFileName;
		}

		/// <summary>
		/// Logs the exceptions into a log file.
		/// </summary>
		/// <param name="strData">The message to be logged.</param>
		public static void LogException(string strData)
		{
			try
			{
				lock (typeof(string)) 
				{
					StreamWriter sw = new StreamWriter(
					new FileStream(strLogFileName, FileMode.Append,FileAccess.Write));
					sw.WriteLine(System.DateTime.Now + " @ " + strData);
					sw.Close();
				}
			}
			catch(Exception)
			{
			}
		}


	}
}
