using System;
using System.IO;
using System.Xml;
using System.Collections;

namespace EPrinterTerminal
{
	/// <summary>
	/// Summary description for ParseXmlData.
	/// </summary>
	public class XmlResponseParser
	{
		private Hashtable htXmlTags = new Hashtable();
		private bool bErrorFlag = false;

		/// <summary>
		/// Returns the Return code.
		/// </summary>
		/// <returns>The Return code.</returns>
		public String getReturnCode()
		{
			return (string) htXmlTags[EPTConstants.XT_RETURNCODE];
		}

		/// <summary>
		/// Returns the Request type.
		/// </summary>
		/// <returns>Request Type</returns>
		public String getRequest()
		{
			return (string) htXmlTags[EPTConstants.XT_REQUEST];
		}

		/// <summary>
		/// Returns the Printer Id.
		/// </summary>
		/// <returns>Printer Id</returns>
		public String getPrinterId()
		{
			return (string)htXmlTags[EPTConstants.XT_PRINTERID];
		}

		/// <summary>
		/// Returns the Job Id.
		/// </summary>
		/// <returns>Job Id</returns>
		public string getJobId()
		{
			return (string)htXmlTags[EPTConstants.XT_JIID];
		}

		/// <summary>
		/// Returns the Job Cost.
		/// </summary>
		/// <returns>Job Cost</returns>
		public string getJobCost()
		{
			return (string)htXmlTags[EPTConstants.XT_JCOST];
		}

		/// <summary>
		/// Returns the Job Copies.
		/// </summary>
		/// <returns>Job Copies</returns>
		public string getJobCopies()
		{
			return (string)htXmlTags[EPTConstants.XT_JCOPIES];
		}

		/// <summary>
		/// Returns the Printer Status.
		/// </summary>
		/// <returns>Printer Status</returns>
		public string getFileName()
		{
			return (string)htXmlTags[EPTConstants.XT_FILENAME];
		}

		/// <summary>
		/// Returns the file size.
		/// </summary>
		/// <returns>File Size</returns>
		public string getFileSize()
		{
			return (string)htXmlTags[EPTConstants.XT_FILESIZE];
		}

		/// <summary>
		/// Parses the XML data.
		/// </summary>
		/// <param name="reader">Holds the XML data from the EPC</param>
		public XmlResponseParser(XmlTextReader reader)
		{
			try
			{  
				reader.WhitespaceHandling = WhitespaceHandling.None;

				//Parse the file and display each of the nodes.
				while (reader.Read())
				{
					switch (reader.NodeType)
					{
						case XmlNodeType.Element:
							
							// Store the name of the element.
							string strElement = reader.Name;	

							if ( strElement.Equals(EPTConstants.XT_RETURNCODE) )		
							{
								reader.Read();
								htXmlTags.Add(EPTConstants.XT_RETURNCODE,reader.Value);
								continue;
							}
							else
								if ( strElement.Equals(EPTConstants.XT_REQUEST) )		
							{
								reader.Read();
								htXmlTags.Add(EPTConstants.XT_REQUEST,reader.Value);
								continue;
							}
							else
								if ( strElement.Equals(EPTConstants.XT_PRINTERID) )		
							{
								reader.Read();
								htXmlTags.Add(EPTConstants.XT_PRINTERID,reader.Value);
								continue;
							}
							else
								if  ( strElement.Equals(EPTConstants.XT_JOBINFO) )
							{
								if ( reader.AttributeCount > 0)
								{
									htXmlTags.Add(EPTConstants.XT_JIID, reader.GetAttribute(EPTConstants.XT_JIID));
									htXmlTags.Add(EPTConstants.XT_JCOST, reader.GetAttribute(EPTConstants.XT_JCOST));
									htXmlTags.Add(EPTConstants.XT_JCOPIES, reader.GetAttribute(EPTConstants.XT_JCOPIES));
								}
								continue;
							}	
							else
								if  ( strElement.Equals(EPTConstants.XT_FILEINFO) )
							{
								if ( reader.AttributeCount > 0)
								{
									htXmlTags.Add(EPTConstants.XT_FILENAME, reader.GetAttribute(EPTConstants.XT_FILENAME));
									htXmlTags.Add(EPTConstants.XT_FILESIZE, reader.GetAttribute(EPTConstants.XT_FILESIZE));
								}
								continue;
							}
							else 
								if ( strElement.Equals(EPTConstants.XT_JOBINFO) )
							{
								htXmlTags.Add(EPTConstants.XT_JIID, reader.GetAttribute(EPTConstants.XT_JIID));
								htXmlTags.Add(EPTConstants.XT_JISTATUS, reader.GetAttribute(EPTConstants.XT_JISTATUS));
								continue;
							}
			
							break;
					}  // end-switch     
				}   // end-while

			}
			catch(System.Xml.XmlException )
			{
				this.bErrorFlag = true;
				//EPCDebug.LogException("EPTXmlReader:"	+ xmle.ToString() );
			}
			finally
			{
				if (reader!=null)
					reader.Close();
			}
		}
	}
}
