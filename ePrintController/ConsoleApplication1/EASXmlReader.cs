using System;
using System.IO;
using System.Xml;
using System.Collections;

namespace EAppService
{
	/// <summary>
	/// Summary description for ParseXmlData.
	/// </summary>
	public class EASXmlReader
	{
		private Hashtable htXmlTags = new Hashtable();
		private Queue qPaperInfo = new Queue();
		private bool bErrorFlag = false;


		/// <summary>
		/// Returns the EPT Host Ip
		/// </summary>
		/// <returns>The EPT Host Ip Adress</returns>
		public String getEPTHostIp()
		{
			return (string) htXmlTags[EASConstants.XT_EPTHOSTIP];
		}

		/// <summary>
		/// Returns the EPT Port No
		/// </summary>
		/// <returns>The EPT Port No </returns>
		public String getEPTPortNo()
		{
			return (string) htXmlTags[EASConstants.XT_EPTPORTNO];
		}


		/// <summary>
		/// Returns the Area Code.
		/// </summary>
		/// <returns>The Area Code</returns>
		public String getAreaCode()
		{
			return (string) htXmlTags[EASConstants.XT_AREACODE];
		}

		/// <summary>
		/// Returns the Request type.
		/// </summary>
		/// <returns>Request Type</returns>
		public String getRequest()
		{
			return (string) htXmlTags[EASConstants.XT_REQUEST];
		}

		/// <summary>
		/// Returns the Printer Id.
		/// </summary>
		/// <returns>Printer Id</returns>
		public String getPrinterId()
		{
			return (string)htXmlTags[EASConstants.XT_PRINTERID];
		}

		/// <summary>
		/// Returns the Printer Capability Information.
		/// </summary>
		/// <returns>Printer Cap data object</returns>
		public PrinterCap getPrinterCap()
		{
			PaperInfo[] paperInfo = new PaperInfo[qPaperInfo.Count];
				
			IEnumerator myEnumerator = qPaperInfo.GetEnumerator();
			int iCnt = 0;
			while ( myEnumerator.MoveNext() )
			{
				paperInfo[iCnt] = (PaperInfo) myEnumerator.Current;
				iCnt++;
			}

			return new PrinterCap(
				(string)htXmlTags[EASConstants.XT_EPTHOSTIP],
				(string)htXmlTags[EASConstants.XT_EPTPORTNO],
				(string)htXmlTags[EASConstants.XT_PCMF],
				(string)htXmlTags[EASConstants.XT_PCMODEL],
				(string)htXmlTags[EASConstants.XT_PCTYPE],
				(string)htXmlTags[EASConstants.XT_PCCOLOR],
				(string)htXmlTags[EASConstants.XT_PCDUPLEX],
				paperInfo);
		}


		/// <summary>
		/// Returns the Job Id.
		/// </summary>
		/// <returns>Job Id</returns>
		public string getJobId()
		{
			return (string)htXmlTags[EASConstants.XT_JIID];
		}

		/// <summary>
		/// Returns the Job Status.
		/// </summary>
		/// <returns>Job Status</returns>
		public string getJobStatus()
		{
			return (string)htXmlTags[EASConstants.XT_JISTATUS];
		}

		/// <summary>
		/// Returns the Printer Status.
		/// </summary>
		/// <returns>Printer Status</returns>
		public string getPrinterStatus()
		{
			return (string)htXmlTags[EASConstants.XT_PISTATUS];
		}

		/// <summary>
		/// Returns the File Name.
		/// </summary>
		/// <returns>File Name</returns>
		public string getFileName()
		{
			return (string)htXmlTags[EASConstants.XT_FILENAME];
		}

		/// <summary>
		/// Parses the XML data.
		/// </summary>
		/// <param name="reader">Holds the XML data from the EPT</param>
		public EASXmlReader(XmlTextReader reader)
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

							if ( strElement.Equals(EASConstants.XT_REQUEST) )		
							{
								reader.Read();
								htXmlTags.Add(EASConstants.XT_REQUEST,reader.Value);
								continue;
							}
							else
								if ( strElement.Equals(EASConstants.XT_PRINTERID) )		
							{
								reader.Read();
								htXmlTags.Add(EASConstants.XT_PRINTERID,reader.Value);
								continue;
							}
							else
								if  ( strElement.Equals(EASConstants.XT_PRINTERCAP) )
							{
								if ( reader.AttributeCount > 0)
								{
									htXmlTags.Add(EASConstants.XT_PCMF, reader.GetAttribute(EASConstants.XT_PCMF));
									htXmlTags.Add(EASConstants.XT_PCMODEL, reader.GetAttribute(EASConstants.XT_PCMODEL));
									htXmlTags.Add(EASConstants.XT_PCTYPE, reader.GetAttribute(EASConstants.XT_PCTYPE));
									htXmlTags.Add(EASConstants.XT_PCCOLOR, reader.GetAttribute(EASConstants.XT_PCCOLOR));
									htXmlTags.Add(EASConstants.XT_PCDUPLEX, reader.GetAttribute(EASConstants.XT_PCDUPLEX));	
								}
								continue;
							}	
							else
								if  ( strElement.Equals(EASConstants.XT_PAPERINFO) )
							{
								if ( reader.AttributeCount > 0)
								{
									PaperInfo piData = 
										new PaperInfo(reader.GetAttribute(EASConstants.XT_PISIZE),
										reader.GetAttribute(EASConstants.XT_PIWIDTH),
										reader.GetAttribute(EASConstants.XT_PIHEIGHT)	);
							
									qPaperInfo.Enqueue(piData);	
								}
								continue;
							}
							else 
								if ( strElement.Equals(EASConstants.XT_JOBINFO) )
							{
								htXmlTags.Add(EASConstants.XT_JIID, reader.GetAttribute(EASConstants.XT_JIID));
								htXmlTags.Add(EASConstants.XT_JISTATUS, reader.GetAttribute(EASConstants.XT_JISTATUS));
								continue;
							}
							else 
								if ( strElement.Equals(EASConstants.XT_FILEINFO) )
							{
								htXmlTags.Add(EASConstants.XT_FILENAME, reader.GetAttribute(EASConstants.XT_FILENAME));
								continue;
							}
							else 
								if ( strElement.Equals(EASConstants.XT_PRINTERINFO) )
							{
								htXmlTags.Add(EASConstants.XT_PISTATUS, reader.GetAttribute(EASConstants.XT_PISTATUS));
								continue;
							}
							else 
								if ( strElement.Equals(EASConstants.XT_AREACODE) )
							{
								reader.Read();
								htXmlTags.Add(EASConstants.XT_AREACODE,reader.Value);
								continue;
							}
							else 
								if ( strElement.Equals(EASConstants.XT_EPTHOSTIP) )
							{
								reader.Read();
								htXmlTags.Add(EASConstants.XT_EPTHOSTIP,reader.Value);
								continue;
							}
							else 
								if ( strElement.Equals(EASConstants.XT_EPTPORTNO) )
							{
								reader.Read();
								htXmlTags.Add(EASConstants.XT_EPTPORTNO,reader.Value);
								continue;
							}

							break;
					}  // end-switch     
				}   // end-while

			}
			catch(System.Xml.XmlException xmle)
			{
				this.bErrorFlag = true;
				EASDebug.LogException("EPTXmlReader:"	+ xmle.ToString() );
			}
			finally
			{
				if (reader!=null)
					reader.Close();
			}
		}

		/// <summary>
		/// Validates the XML data according to the specifications.
		/// </summary>
		/// <returns> 200 If there is no error, else returns a predefined error code. </returns>
		public int validate()
		{
			try
			{
				if (this.bErrorFlag)
				{
					this.bErrorFlag = false;
					return 300;
				}
				else
				{
					// Validate for request type.
					string strRequest = this.getRequest();

					// Validate data common in all the requests.
					if ( this.getPrinterId().Equals("") && 
						(!strRequest.Equals(EASConstants.RT_RPR)) )
					{
						return 302;
					}

					switch (strRequest)
					{
						case EASConstants.RT_RPR :
					
							// TODO: validate area code, host address, and port no.	

							PrinterCap pc = this.getPrinterCap();
								
							if ( pc.getModel().Equals("") )
							{
								return 303;
							}
							else if (!( pc.getType().Equals("0") || pc.getType().Equals("1") || pc.getType().Equals("2") ) )
							{
								return 303;		
							}
							else if (!( pc.getColor().Equals("0") || pc.getColor().Equals("1") ) )
							{
								return 303;
							}
							else if (!( pc.getDuplex().Equals("0") || pc.getDuplex().Equals("1") ) )
							{
								return 303;
							}
							else
							{
								PaperInfo[] paperInfo = pc.getPaperInfo();

								for (int iCnt = 0 ; iCnt < paperInfo.Length ; iCnt++)
								{
									if ( paperInfo[iCnt].getSize().Equals(""))
									{
										return 304;
									}
								}
							}

							break;
		
						case EASConstants.RT_DPR :
							break;

						case EASConstants.RT_GJF :

							if ( this.getJobId().Equals("") )
							{
								return 305;
							}

							if ( this.getFileName().Equals("") )
							{
								return 306;
							}

							break;

						case  EASConstants.RT_NJS :

							if ( this.getJobId().Equals("") || this.getJobStatus().Equals("") )
							{
								return 305;
							}
							else if (!( this.getJobStatus().Equals("1") || this.getJobStatus().Equals("2") || this.getJobStatus().Equals("3") ) )
							{
								return 305;		
							}

							break;

						case EASConstants.RT_NPS:

							if ( this.getPrinterStatus().Equals("") )
							{
								return 307;
							}							
							else if (!( this.getPrinterStatus().Equals("0") || this.getPrinterStatus().Equals("1") ) )
							{
								return 307;		
							}

							break;

						default:
							return  301;
					}
				}				
			}
			catch(Exception e)
			{
				EASDebug.LogException("EASXmlReader:"	+ e.ToString() );
				return 300;
			}
			// '200' is returned if no error occurs.
			return 200;
		}

	}
}
