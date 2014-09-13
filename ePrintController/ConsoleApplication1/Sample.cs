using System;
using System.IO;
using System.Globalization;
using System.Xml;
using System.Collections;
using System.Resources;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace EPCService
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
			
				//Console.WriteLine(ResponseHandlers.GenerateGRPRequest("HM1234") );	
				
				string strSQL = "select * from printer";

				string connectionStr = 
					"server=NAV2K;uid=sa;password=;database=EAS";

				SqlConnection conn = new SqlConnection(connectionStr);

				conn.Open();

				SqlDataAdapter adapt = new SqlDataAdapter(strSQL,conn);
				DataSet objDset = new DataSet();
				adapt.Fill(objDset);
		
				DataTableCollection dtc = objDset.Tables;

				IEnumerator myEnumerator = dtc.GetEnumerator();
				while ( myEnumerator.MoveNext() )
				{
					DataTable dt = new DataTable();
					dt = (DataTable) myEnumerator.Current;

					ShowRows(dt);
				}
				Console.Read();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
				Console.Read();
			}
		}			

		private static void ShowRows(DataTable myTable)
		{
			// Print the number of rows in the collection.
			Console.WriteLine(myTable.Rows.Count);
			// Print the value of columns 1 in each row
			foreach(DataRow row in myTable.Rows)
			{
				Console.WriteLine(row[1]);
			}
		}


	}

}
