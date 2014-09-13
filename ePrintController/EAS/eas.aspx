<% @Page Language="C#" %>
<% @Import Namespace="System.IO" %> 
<% @Import Namespace="System.Xml" %>
<% @Import Namespace="System.Text" %>
<% @Import Namespace="System.Resources" %>
<% @Import Namespace="EAppService" %>

<%

	// Holds the response object to send data to the client.
	TextWriter tw = null;
	
	try
	{	
		// Reads the multipart data from the EPT client.
		EASDebug.LogException("EAS.aspx:Reads the multipart data from the EPT client.");
		// The multipart data is stored in the string bulider.
		const int BUFFER_SIZE = 255;
		int iBytesRead = 0;
		Byte[] bBuffer = new Byte[BUFFER_SIZE];
		// The string builder will also include, the starting and the ending boundary.
		StringBuilder strBuf = new StringBuilder();
		Stream streamX = Request.InputStream;
		iBytesRead = streamX.Read(bBuffer, 0, BUFFER_SIZE);
        
        while ( iBytesRead != 0)
        {
                strBuf.Append(Encoding.ASCII.GetString(bBuffer, 0, iBytesRead));
                iBytesRead = streamX.Read(bBuffer, 0, BUFFER_SIZE);
        }

        EASDebug.LogException("EAS.aspx:Getting the boundary string from the 'Content-Type' header.");

        // Getting the boundary string from the 'Content-Type' header.
        string strLookFor = "boundary=";
        string strContentType = Request.ContentType;
        int iBIndex = strContentType.IndexOf(strLookFor,0);
        // This variable holds the boundary value.
		string strBoundary = null;
		
		if ( iBIndex  != -1 )
		{	
				strBoundary = strContentType.Substring(iBIndex + strLookFor.Length);
		}   
        
        // Trying to remove the starting and the ending boundary.
        strBuf.Replace("--" + strBoundary + "\r\n","");
        strBuf.Replace("--" + strBoundary + "--" + "\r\n","");

        string strXmlData = strBuf.ToString();
        
   	    EASDebug.LogException("EAS.aspx:Xml data -> " + strXmlData);

        StringReader sr = new StringReader(strXmlData);
        XmlTextReader xtr = new XmlTextReader(sr);
        // parsing and validating the XML data read from the EPT.
 		EASXmlReader eptXml = new EASXmlReader(xtr);
        int iErrorCode = eptXml.validate();
		EASDebug.LogException("EAS.aspx:iErrorCode = " + iErrorCode);
        xtr.Close(); 

        tw = Response.Output;
        
		// send the error messages to the ept.
		if ( iErrorCode != 200 )
		{
			string errResponse 
				= ResponseHandlers.EPTResponse(iErrorCode,
										eptXml.getRequest(), 
										eptXml.getPrinterId() );
	 			tw.Write(errResponse);
		}
		else // Start the actual data processing.
		{
			Hashtable htConfig = (Hashtable) Application["CONFIG"];
			string strDownloadDir = null;
			string strDbUrlConn = null;
			string strJobQueueName = null;
		
			if ( htConfig != null)
			{
				strDownloadDir = (string) htConfig["shared_directory"];
				strDbUrlConn = (string) htConfig["database_url"];
				strJobQueueName = (string) htConfig["job_queue_name"];
			}
	 	    else
			{
				throw new Exception("Application[\"CONFIG\"] object is null");
			}
				  
			// IMP NOTE: The printer id will be of the format "AreaCode_PrinterId".
			string strPrinterId = eptXml.getPrinterId();
			string strRequest = eptXml.getRequest();

			DBAccess dbAccess = new DBAccess(strDbUrlConn);
	
			if ( !(strRequest.Equals(EASConstants.RT_RPR)) ) 
			{
				// does NOT throw an exception if the database is down.
				bool bValidFlag = dbAccess.isPrinterIdValid(strPrinterId);

				if ( bValidFlag == false )
				{
		    		// Invalid Printer Id.
		    		string errResponse 
							= ResponseHandlers.EPTResponse(302,
				   										  strRequest,
				  	 		   						   	  strPrinterId	);
					tw.Write(errResponse);
				}
				else // Handle all other requests here.
				{
					switch (strRequest)
					{
					// DPR request.
					case EASConstants.RT_DPR :

						try
						{	
						    EASDebug.LogException("EAS.aspx:DPR operation");						
							// De-register printer.
							dbAccess.deRegisterPrinter(strPrinterId);

							tw.Write(
							ResponseHandlers.EPTResponse(200,
							EASConstants.RT_DPR, strPrinterId) );

						}
						catch(Exception DPRException)
						{
						    EASDebug.LogException("EAS.aspx:DPR exception \n" + DPRException.ToString() );

							tw.Write(
							ResponseHandlers.EPTResponse(402,
							EASConstants.RT_DPR, strPrinterId) );
						}
												  				
				    break;
					
					// NJS request.
					case EASConstants.RT_NJS :

  						try
						{	
						    EASDebug.LogException("EAS.aspx:NJS operation");						
							// Update Job Status.
							dbAccess.updateJobStatus(
										strPrinterId, 
										eptXml.getJobId(), 
										eptXml.getJobStatus() );

							tw.Write(
							ResponseHandlers.EPTResponse(200,
							EASConstants.RT_NJS, strPrinterId) );

						}
						catch(Exception NJSException)
						{
						    EASDebug.LogException("EAS.aspx:NJS exception \n" + NJSException.ToString() );

							tw.Write(
							ResponseHandlers.EPTResponse(500,
							EASConstants.RT_NJS, strPrinterId) );
						}

					break;
		
					// NPS request.
					case EASConstants.RT_NPS :
					
  						try
						{	
						    EASDebug.LogException("EAS.aspx:NPS operation");						
							// Update Printer Status.
						   	dbAccess.updatePrinterStatus(
										strPrinterId, 
										eptXml.getPrinterStatus(), 
										eptXml.getEPTHostIp(), 
										eptXml.getEPTPortNo() );

							tw.Write(
							ResponseHandlers.EPTResponse(200,
							EASConstants.RT_NPS, strPrinterId) );

							// Place all the job messages in the job Queue.
							JobInfo[] jobInfo = dbAccess.getPrintJobs(strPrinterId);
							QueueManager jobQMgr = new QueueManager(strJobQueueName);
									  
							for (int iCnt = 0; iCnt < jobInfo.Length ; iCnt++)
							{
							   string strJobInfo 
							   = ResponseHandlers.GenerateNWJRequest(jobInfo[iCnt]);
							   // Place the messages in the queue.
							   jobQMgr.sendMessage(strJobInfo,EASConstants.RT_NWJ);
							}

						}
						catch(Exception NPSException)
						{
						    EASDebug.LogException("EAS.aspx:NPS exception \n" + NPSException.ToString() );

							tw.Write(
							ResponseHandlers.EPTResponse(500,
							EASConstants.RT_NPS, strPrinterId) );
						}

					break;
		
					// GJF request.
					case EASConstants.RT_GJF :

						try
						{
							// First check for job cancellation
							if (dbAccess.isJobCancelled(eptXml.getJobId()) )
							{
								tw.Write(
								ResponseHandlers.EPTResponse(404,
								EASConstants.RT_NPS, strPrinterId) );
							}
							else // job is not cancelled.
							{
								// Forming the file download path.
								// download dir + file name.
							    string strFilePath = strDownloadDir + "\\" + eptXml.getFileName(); 
								// File information.
		 						FileInfo myFileInfo = new FileInfo(strFilePath);
				  				// writing the response.
				  				Response.WriteFile(strFilePath, 0, myFileInfo.Length);

								dbAccess.updateJobStatus
											(strPrinterId,eptXml.getJobId(),"3");
							}
						}
						catch(Exception GJFException)
						{
						    EASDebug.LogException("EAS.aspx:GJF exception \n" + GJFException.ToString() );

							tw.Write(
							ResponseHandlers.EPTResponse(500,
							EASConstants.RT_GJF, strPrinterId) );
						}
																		
					break;
			  	
			  	} // end-switch
			  
				} // end-else
			}
		    else // Handle RPR request.
		    {
				EASDebug.LogException("EAS.aspx:Handling RPR request");
				string strNewPrinterId = "";

				try
				{
				    strNewPrinterId =
					dbAccess.registerPrinter( eptXml.getAreaCode(), eptXml.getPrinterCap() );

					tw.Write( 
					ResponseHandlers.EPTResponse(200,EASConstants.RT_RPR, strNewPrinterId) );
					
				}
				catch (Exception RPRException)
				{
				 	EASDebug.LogException("EAS.aspx:RPR exception" + RPRException.ToString() );

					tw.Write( 
					ResponseHandlers.EPTResponse(401,EASConstants.RT_RPR, strNewPrinterId) );
				}
	  	
		    } // end - RPR.

	    } // end-else
	} // end-try
	catch(Exception eek)
	{
			EASDebug.LogException("EAS.aspx:"+ eek.Message); 
			string easInternalError = ResponseHandlers.EPTResponse(500,"","");
			
			if ( tw == null) 
			{
				tw = Response.Output; 
			}	       			

			tw.Write(easInternalError); 	
	}   
	finally
	{
			if ( tw != null)
			{
				tw.Close();
			}
	}     

%>

