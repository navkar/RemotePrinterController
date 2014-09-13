using System;
using System.Collections;
using System.Xml;
using System.IO;

namespace EPrinterTerminal
{
	/// <summary>
	/// Summary description for XmlFileReaderWriter.
	/// </summary>
	public class XmlFileReaderWriter
	{
		/// <summary>
		/// The file name is used to read and write data.
		/// </summary>
		private string strFileName = null;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strFileName">the file name is used to read and write data.</param>
		public XmlFileReaderWriter(string strFileName)
		{
			this.strFileName = strFileName;
		}

		/// <summary>
		/// Reads the elements and values from the XML file and populates the hashtable.
		/// </summary>
		/// <returns>Returns a hashtable containing all the elements and their values.</returns>
		public Hashtable ReadXmlFile()
		{
			Hashtable htXmlData = new Hashtable();
			
			try
			{
				XmlTextReader xtr = new XmlTextReader(this.strFileName);
				xtr.WhitespaceHandling = WhitespaceHandling.None;

				string strNodeName = null;

				while( xtr.Read() )
				{
					if (xtr.NodeType == XmlNodeType.Element)
					{
						strNodeName = xtr.Name;
					}
				
					if (xtr.NodeType == XmlNodeType.Text)
					{
						//Console.WriteLine("Name: " + strNodeName + " value:" + xtr.Value );
						htXmlData.Add(strNodeName, xtr.Value );			
					}
				}
				xtr.Close();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.ToString() );
			}

			return htXmlData;
		}

		/// <summary>
		/// Writes an XML file from the data received from the Hashtable.
		/// </summary>
		/// <param name="htXmlData">The hashtable containing the elements and values.</param>
		/// <param name="strEnclosingStartElement">The starting element of the XML file.</param>
		public void WriteXmlFile(Hashtable htXmlData, string strEnclosingStartElement)
		{
			XmlTextWriter xtw =		// filename , encoding.
					new XmlTextWriter(this.strFileName, null);

			try
			{
				if ( htXmlData != null && htXmlData.Count > 0)
				{
					xtw.Formatting = Formatting.Indented;
					xtw.Indentation = 6;
					xtw.Namespaces = false;
					xtw.WriteStartDocument();
					xtw.WriteStartElement("", strEnclosingStartElement , "");
					
					IDictionaryEnumerator myEnumerator = htXmlData.GetEnumerator();
					while ( myEnumerator.MoveNext() )
					{
						xtw.WriteStartElement("", (string) myEnumerator.Key , "");
						xtw.WriteString((string) myEnumerator.Value);
						xtw.WriteEndElement();
					}

					xtw.WriteEndElement();
					xtw.Flush();
				}
			}
			catch(Exception e)
			{
					Console.WriteLine( e.ToString() );
			}
			finally
			{
				if ( xtw != null)
				{
					xtw.Close();
				}
			}

		}

		public void WriteFile(string strData)
		{
			try
			{
				// The file stream is written to the file.
				FileStream fs = new FileStream(this.strFileName, FileMode.Create, 
					FileAccess.Write);

				StreamWriter sw = new StreamWriter(fs);
	
				sw.Write(strData);
				sw.Close();
				fs.Close();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.ToString() );
			}
		}

	}
}
