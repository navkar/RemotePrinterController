using System;
using System.IO;
using System.Collections;

namespace EAppService
{
	/// <summary>
	/// Summary description for ReadConfigFile.
	/// </summary>
	public class ReadConfigFile
	{
		private string strFileName = null;
		
		public ReadConfigFile(string strFileName)
		{
			this.strFileName = strFileName;
		}

		public Hashtable GetConfigData()
		{
			Hashtable htConfig = new Hashtable();

			try
			{
				FileStream fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
				// Create a Char reader.
				StreamReader sr = new StreamReader(fs);        
				// Set the file pointer to the beginning.
				sr.BaseStream.Seek(0, SeekOrigin.Begin);   
				while (sr.Peek() > -1) 
				{
					string strLine = sr.ReadLine();
					int equalIndex = strLine.IndexOf("=");

					if ( equalIndex != -1)
					{
						string strName = strLine.Substring(0,equalIndex);
						string strValue = strLine.Substring(equalIndex + 1);

						if ( strName!= null && strValue != null)
						{
							htConfig.Add(strName.Trim() ,strValue.Trim() );
						}
					}

				}
				return htConfig;
			}
			catch(Exception e)
			{
				EASDebug.LogException("ReadConfigFile:"	+ e.Message);
				return null;
			}	
	
		}
	}
}
