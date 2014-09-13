<% @Page Language="C#" %>
<% @Import Namespace="System.IO" %>

<html>
	<head>
		<title>EPSON iPrint Service</title>
	</head>
	<body>
		<form action="idoc.aspx" method="POST" id="iDoc">

			<table border=0 bgcolor="#ccccff" CellPadding="2" CellSpacing="0" Width="100%">
			<tr><td align="center">
			<asp:label HorizontalAlign="Center" runat="server" id="lblTitle"
				Font-Name="Verdana" Font-Italic="false" Font-Size="Smaller" />
			</td></tr>
			<tr bgcolor="white">
				<td>&nbsp;
				</td>
			</tr>
			<tr bgcolor="white">
			<td align="center">
			<asp:label HorizontalAlign="Center" runat="server" id="lblMessage"
				Font-Name="Verdana" Font-Italic="false" Font-Size="Smaller" />
			</td></tr>
			</table>
			<BR>
				<div align="center">
				<asp:RadioButtonList 
					AutoPostBack="False"
					ID="listFiles" 
					Runat="server" 
				 	CellPadding="2" CellSpacing="0"
				 	RepeatDirection="Vertical" 
					RepeatColumns="2" 
					RepeatLayout="Table"   
					Font-Name="Verdana" Font-Size="9pt" Font-Bold="true"
					BackColor="Beige"
				    BorderWidth="2" 
					ForeColor="DarkSlateBlue"
				    BorderStyle="Solid" 
				    BorderColor="Tan">
				</asp:RadioButtonList>
			<BR>
				<asp:label Text="Specify Copies:" HorizontalAlign="Center" runat="server" id="lblCopies"
				Font-Name="Verdana" Font-Italic="false" Font-Size="Smaller" />
				<asp:DropDownList id="NoOfCopies" runat="server" >
				         <asp:ListItem>1 </asp:ListItem>
				         <asp:ListItem>2 </asp:ListItem>
				         <asp:ListItem>3 </asp:ListItem>
			    	     <asp:ListItem>4 </asp:ListItem>
			    	     <asp:ListItem>5 </asp:ListItem>
				</asp:DropDownList>
			<BR><BR>
				<input type="SUBMIT" value="Print Document">

			<BR><BR>
		
			<table border=0 CellPadding="2" CellSpacing="0" Width="100%">
			<tr><td align="Left" bgcolor="#ccccff">
			<asp:label HorizontalAlign="Center" runat="server" id="lblSubTitle"
			Font-Name="Verdana" Font-Italic="false" Font-Size="Smaller" />
			</td></tr>
			<tr><td>
			<asp:HyperLink HorizontalAlign="Center" runat="server" id="docLink"
			Font-Name="Verdana" Font-Italic="false" Font-Size="Smaller" 
		    NavigateUrl="ijob.aspx" Text="iPrint Job Box Page"/>
			</td></tr>
			</table>


			</div>
		</form>
	</body>
</html>


<script language="C#" runat="server">

 	protected override void OnLoad( EventArgs e)
	{
	    lblTitle.Text = "EPSON iPrint Service";
		lblMessage.Text = "Select a document to print...";
		lblSubTitle.Text = "Quick Links";
		Hashtable htConfig = (Hashtable) Application["CONFIG"];
	
		if (htConfig != null)
		{
			string strDirectory = (string) htConfig["shared_directory"];
		
			DirectoryInfo dirInfo = new DirectoryInfo(strDirectory);
			FileInfo[] fileInfo = dirInfo.GetFiles(); 
			
			listFiles.Items.Clear();
			
			for (int iCnt = 0 ; iCnt < fileInfo.Length; iCnt++)
			{      
				listFiles.Items.Add( fileInfo[iCnt].Name );
			}   
 			
			// the first item is selected.
			if (fileInfo.Length > 0)
			{
				listFiles.SelectedIndex = 0;
			}
			else
			{
				Response.Write("No file(s) found in the directory: " + strDirectory);
			}
		}
	}
	
	


</script>
