<% @Page Language="C#" %>
<% @Import Namespace="System.IO" %> 
<% @Import Namespace="System.Xml" %>
<% @Import Namespace="System.Text" %>
<% @Import Namespace="System.Resources" %>
<% @Import Namespace="System.Messaging" %>
<% @Import Namespace="EPCService" %>
<%@ Import Namespace="System.IO" %>

<%

 //   
 	string strFileName = "C:\\Downloads\\WEB_DOWN\\bgnet.pdf";
 
// Read the contents of a binary file

   Stream objStream = File.Open(strFileName, FileMode.Open);
   byte[] buffer = new byte[objStream.Length];

		   objStream.Read(buffer, 0, (int) objStream.Length);
   		   objStream.Close();

   Response.BinaryWrite(buffer);

%>