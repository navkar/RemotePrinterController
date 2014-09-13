using System;
using System.IO;
using System.Globalization;
using System.Xml;
using System.Collections;
using System.Resources;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using EPCService;

namespace QueuePoller
{
	/// <summary>
	/// 
	/// </summary>
	class Sample
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			try
			{
//				string connStr = "server=NAV2K;uid=sa;password=;database=EAS";
	
//				DBAccess x = new DBAccess(connStr);
//
//				int iRetCode = x.DeRegisterPrinter("HM1234","001");
//				PaperInfo[] pi = new PaperInfo[1];
//
//				pi[0] = new PaperInfo("A4","100","100");	
//
//				PrinterCap pc = new PrinterCap("HP-vectra","HP-800c","1","0","1",pi);
//
//				iRetCode = x.RegisterPrinter("JBH","420",pc);

//				string xmlData = x.GetRegisteredPrinters("asdJBH");
//				Console.WriteLine(xmlData);

//				string[] str = FrmPoller.SplitEPCPrinterId("HM1234_101");
//
//				Console.WriteLine(str[0]);
//				Console.WriteLine(str[1]);

//			FileStream fs = new FileStream("C:\\Downloads\\NaveenResume.doc",FileMode.Open ,FileAccess.Read);
//
//				StreamReader sr = new StreamReader(fs);
//
//				string strLine = null;
//				while( (strLine = sr.ReadLine()) != null )
//				{
//					
//				}
//				sr.Close();
//				fs.Close();



			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}			
	}

}
