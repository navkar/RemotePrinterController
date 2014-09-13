using System;
using System.IO;

namespace EPrinterTerminal
{
	/// <summary>
	/// Summary description for EPCDebug.
	/// </summary>
	public class EPTDebug
	{
		/// <summary>
		/// The EPC Log File Name.
		/// </summary>
		private static string strLogFileName = "ept.log";
		
		public EPTDebug()
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
			FileStream fs = null;
			try
			{
				fs = new FileStream(strLogFileName, FileMode.Append,FileAccess.Write);
				StreamWriter sw = new StreamWriter(fs);
				sw.WriteLine(System.DateTime.Now + " @ " + strData);
				sw.Close();
			}
			catch(IOException e)
			{
				Console.WriteLine(e.ToString() );
			}
			finally
			{
				if ( fs != null)
				{
					fs.Close();
				}
			}
		}


	}
}
