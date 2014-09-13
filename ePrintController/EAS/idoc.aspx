<% @Page Language="C#" %>
<% @Import Namespace="System.Data" %>
<% @Import Namespace="System.Data.SqlClient" %>

<html>
	<head>
		<title>EPSON iPrint Service</title>
	</head>
	<body >

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


	<form runat="server">
	<div align="center">
	<table border=0 bgcolor="#ccffee" CellPadding="2" CellSpacing="0" Width="90%" >
	<tr><td align="center">
	<asp:label HorizontalAlign="Center" runat="server" id="lblTitle2"
			Font-Name="Verdana" Font-Italic="false" Font-Size="Smaller" />
	</td></tr>
	</table>

	<asp:DataGrid id="printersGrid" runat="server"
    	AutoGenerateColumns="false"
		BackColor="White"
	    BorderWidth="1px" BorderStyle="Solid" BorderColor="Tan"
    	CellPadding="2" CellSpacing="0"	Width="90%"
	    Font-Name="Verdana" Font-Size="9pt"
		AllowSorting="false"
		AllowPaging="true" PageSize="7"
	    OnPageIndexChanged="OnPageIndexChangedPrintersGrid">
	    
    <SelectedItemStyle BackColor="PaleGoldenRod" Font-Bold="true"/>
  	<HeaderStyle BackColor="DarkRed" ForeColor="White" Font-Bold="true"/>
    <AlternatingItemStyle BackColor="Beige"/>
    <ItemStyle ForeColor="DarkSlateBlue"/>
   
	<PagerStyle Mode="NextPrev" HorizontalAlign="Left"
				ForeColor="White" BackColor="Tan" 
				NextPageText="Next Page >>" PrevPageText="<< Prev. Page">
   	</PagerStyle> 

   	<Columns>

	    <asp:HyperLinkColumn Text="Select" 
	    DataNavigateUrlField="printer_guid"
        DataNavigateUrlFormatString="iJob.aspx?printer_guid={0}"/>

	    <asp:BoundColumn HeaderText="Printer Name" DataField="model" /> 
		<asp:BoundColumn HeaderText="Manufacturer" DataField="manufacturer" /> 
	    <asp:BoundColumn HeaderText="Location" DataField="area_code"/> 
	    <asp:BoundColumn HeaderText="Printer Id" DataField="printer_id"/> 
	    <asp:BoundColumn HeaderText="Color" DataField="color"/> 
	    <asp:BoundColumn HeaderText="Status" DataField="printer_status"/> 		
		<asp:BoundColumn DataFormatString="{0:dd-MMM-yy H:mm:ss }" 
		HeaderText="Last updated status" DataField="printer_status_date"/> 
   
   	</Columns>

	</asp:DataGrid>

	<table border=0 CellPadding="2" CellSpacing="0" Width="90%">
	<tr><td>
	<asp:label HorizontalAlign="Left" runat="server" id="lblNavigation"
			Font-Name="Verdana" Font-Italic="false" Font-Size="Smaller" />
	</td></tr>
	</table>
	<BR><BR>

	<table border=0 CellPadding="2" CellSpacing="0" Width="100%">
	<tr><td align="Left" bgcolor="#ccccff">
	<asp:label HorizontalAlign="Center" runat="server" id="lblSubTitle"
	Font-Name="Verdana" Font-Italic="false" Font-Size="Smaller" />
	</td></tr>
	<tr><td>
	<asp:HyperLink HorizontalAlign="Center" runat="server" id="docLink"
	Font-Name="Verdana" Font-Italic="false" Font-Size="Smaller" 
    NavigateUrl="iprint.aspx" Text="iPrint Document Page"/>
	</td></tr>
	</table>

  	</div>	

	</form>
	</body>
	</html>

<script language="C#" runat="server">

		protected void OnPageIndexChangedPrintersGrid(object sender, DataGridPageChangedEventArgs e)
		{
			printersGrid.CurrentPageIndex = e.NewPageIndex;
			bindData();
		}

 		public void Page_Load( Object source, EventArgs e)
		{
		    if (!Page.IsPostBack )
		    {
				Session["printFile"] = Request["listFiles"];
				Session["NoOfCopies"] = Request["NoOfCopies"];
				bindData();
		    }

		    lblTitle.Text = "EPSON iPrint Service";
			lblTitle2.Text = "iPrint Printer Box";
			lblMessage.Text = "Select a printer to print '" + Session["printFile"] + "'";
			lblSubTitle.Text = "Quick Links";

		}

		private void bindData()
		{
			Hashtable htConfig = (Hashtable) Application["CONFIG"];

			if (htConfig != null)
			{
				string strDbURL = (string) htConfig["database_url"];

			    SqlConnection conn = new SqlConnection(strDbURL);
			    SqlDataAdapter dataAdapt = new SqlDataAdapter("select * from printer order by printer_status_date desc",conn);

				DataSet ds = new DataSet();
				dataAdapt.Fill(ds,"printer");

				printersGrid.DataSource = ds.Tables["printer"].DefaultView;
				printersGrid.DataBind();

				lblNavigation.Text = "Viewing Page " + (printersGrid.CurrentPageIndex + 1) +
									  " of " + printersGrid.PageCount;
			}
		}
</script>


