<% @Import Namespace="System" %>
<% @Import Namespace="EAppService" %>

<script language="C#" runat="server">

     public void Application_OnStart() 
     {
		const string CONFIG_PATH = 	"/EAS/eas.config";

		try
		{
			// Reading the 'eas.config' configuration file.
	   		ReadConfigFile rcf = new ReadConfigFile(Server.MapPath(CONFIG_PATH) );
			Hashtable htConfig = rcf.GetConfigData();
			string strLogFilePath, strLogFileName = null;

	   		if ( htConfig == null)
			{
				throw new Exception("global.asax:File 'eas.config' was not found in "+ Server.MapPath(CONFIG_PATH) +" directory");
			}
			else
			{
				strLogFileName = (string) htConfig["log_file_name"];
				strLogFilePath = (string) htConfig["log_file_directory"];
			}	  

			// Setting the log file name and path.
			EASDebug.setLogFileName(strLogFilePath + "\\" + strLogFileName);
			EASDebug.LogException("global.asax:Application_OnStart() "); 

			Application.Add("CONFIG", htConfig);
		
		}
		catch(Exception e)
		{
		  EASDebug.LogException("global.asax:"	+ e.Message); 
		}	
		
	 }          

     public void Application_BeginRequest() 
     {
         // Application code for each request could go here.
     }

     public void Application_OnEnd() 
     {
         // Application clean-up code goes here.
     }

</script>
