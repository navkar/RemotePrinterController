using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Xml;
using System.IO;
using System.Resources;
using System.Net;

namespace EPrinterTerminal
{
	/// <summary>
	/// The main class that displays the EPrinterTerminal form.
	/// </summary>
	public class FrmEPrinterTerminal : System.Windows.Forms.Form
	{
		/// <summary>
		/// This hashtable holds the EPT configuration data.
		/// </summary>
		private Hashtable htConfigData = null;
		private Hashtable htReturnCodes = null;
		private Thread thrdRegisterPrinter = null;
		//private Thread thrdEptPoller = null;
		private string strRprXmlRequest = null;
		private Icon tmpPrinterIcon = null;
		//
		private System.Windows.Forms.ListView listVJobs;
		private System.Windows.Forms.MainMenu mainMnu;
		private System.Windows.Forms.MenuItem mICtrl;
		private System.Windows.Forms.MenuItem mICtrlRPR;
		private System.Windows.Forms.MenuItem mICtrlDPR;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem mICtrlExit;
		private System.Windows.Forms.MenuItem mIEdit;
		private System.Windows.Forms.MenuItem mIProp;
		private System.Windows.Forms.MenuItem mIView;
		private System.Windows.Forms.MenuItem mISetting;
		private System.Windows.Forms.MenuItem mIDelJobs;
		private System.Windows.Forms.MenuItem mIHelp;
		private System.Windows.Forms.MenuItem mIHelpAbout;
		private System.Windows.Forms.ContextMenu mnuCtxList;
		private System.Windows.Forms.MenuItem mnuIDelJob;
		private System.Windows.Forms.MenuItem mnuIDispGridLines;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.StatusBarPanel statusBarPanelReq;
		private System.Windows.Forms.MenuItem mISepCtx;
		private System.Windows.Forms.StatusBarPanel statusBarPanelDummy;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// constructor of the class.
		/// </summary>
		public FrmEPrinterTerminal()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Check for configuration files before loading.
			// CheckConfigurationFiles();

			//--- Reading Configuration Files
		
			XmlFileReaderWriter xfrw 
				= new XmlFileReaderWriter(EPTConstants.APP_CONFIG_PATH + EPTConstants.APP_CONFIG_NAME);
			this.htConfigData = xfrw.ReadXmlFile();
			
			// -- Add Local IP Address to the htConfigData.
			// TODO: Note enable this when LIVE.
			/*
			IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName);
			IPAddress[] ipAddr = ipHost.AddressList;
			this.htConfigData.Add("EPTHostIp", ipAddr[0].ToString() );
			*/
			// TODO: delete this line below in production.
			this.htConfigData.Remove("EPTHostIp");
			this.htConfigData.Add("EPTHostIp", "localhost" );

			PrintKeysAndValues(htConfigData);

			// Reading the return code resource files.
			IResourceReader reader = new ResourceReader(EPTConstants.APP_CONFIG_PATH + "returncodes.resources");
			IDictionaryEnumerator en = reader.GetEnumerator();
			this.htReturnCodes = new Hashtable();
			
			//Go through the enumerator, printing out the key and value pairs.
			while (en.MoveNext()) 
			{
				this.htReturnCodes.Add(en.Key,en.Value);
			}
			reader.Close();
			// closing the reader.
		
			//--------------

			ColumnHeader[] colHeader = new ColumnHeader[4];

			colHeader[0] = new ColumnHeader();
			colHeader[0].Text = "Date";
			colHeader[0].Width = listVJobs.Width/3;
			
			colHeader[1] = new ColumnHeader();
			colHeader[1].Text = "Print Jobs";
			colHeader[1].Width = listVJobs.Width/4;

			colHeader[2] = new ColumnHeader();
			colHeader[2].Text = "Cost (Yen)";
			colHeader[2].Width = listVJobs.Width/5;

			colHeader[3] = new ColumnHeader();
			colHeader[3].Text = "Copies";
			colHeader[3].Width = listVJobs.Width/5;

			ListView.ColumnHeaderCollection lvColHeadColl 
				= new ListView.ColumnHeaderCollection(listVJobs);
			lvColHeadColl.AddRange(colHeader);

			// TODO: Delete this during production.
			this.addJobDataToListView("hello.pdf","12122","4");

			string strPrinterId = (string) this.htConfigData["PrinterId"];
			
			// Check for printer id, if the printer id exists! 
			if (strPrinterId != null)
			{
				this.mICtrlRPR.Enabled = false;	
				
/*
				// start the EPT Polling thread.
				EPTPollingProcess eptPoller 
					= new EPTPollingProcess(
					(string) this.htConfigData["HostName"],
					Int32.Parse((string) this.htConfigData["PortNo"]),
					strPrinterId,
					Int32.Parse((string) this.htConfigData["PollingFrequency"]),
					this
					);

				this.thrdEptPoller = new Thread(
					new ThreadStart( eptPoller.RunForLife ) );

				this.thrdEptPoller.Start();
*/				
			}
			else
			{
				// Copy the icon before setting it to null
				this.tmpPrinterIcon = this.statusBarPanelReq.Icon;
				this.statusBarPanelReq.Icon = null;
				this.mICtrlDPR.Enabled = false;
				this.SetStatusBarText("EPrinterTerminal is not registered.");
			}

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmEPrinterTerminal));
			this.listVJobs = new System.Windows.Forms.ListView();
			this.mnuCtxList = new System.Windows.Forms.ContextMenu();
			this.mnuIDelJob = new System.Windows.Forms.MenuItem();
			this.mISepCtx = new System.Windows.Forms.MenuItem();
			this.mnuIDispGridLines = new System.Windows.Forms.MenuItem();
			this.mainMnu = new System.Windows.Forms.MainMenu();
			this.mICtrl = new System.Windows.Forms.MenuItem();
			this.mICtrlRPR = new System.Windows.Forms.MenuItem();
			this.mICtrlDPR = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.mICtrlExit = new System.Windows.Forms.MenuItem();
			this.mIEdit = new System.Windows.Forms.MenuItem();
			this.mIDelJobs = new System.Windows.Forms.MenuItem();
			this.mIProp = new System.Windows.Forms.MenuItem();
			this.mIView = new System.Windows.Forms.MenuItem();
			this.mISetting = new System.Windows.Forms.MenuItem();
			this.mIHelp = new System.Windows.Forms.MenuItem();
			this.mIHelpAbout = new System.Windows.Forms.MenuItem();
			this.statusBarPanelDummy = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanelReq = new System.Windows.Forms.StatusBarPanel();
			this.statusBar = new System.Windows.Forms.StatusBar();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelDummy)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelReq)).BeginInit();
			this.SuspendLayout();
			// 
			// listVJobs
			// 
			this.listVJobs.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.listVJobs.ContextMenu = this.mnuCtxList;
			this.listVJobs.FullRowSelect = true;
			this.listVJobs.GridLines = true;
			this.listVJobs.HoverSelection = true;
			this.listVJobs.Location = new System.Drawing.Point(0, 2);
			this.listVJobs.MultiSelect = false;
			this.listVJobs.Name = "listVJobs";
			this.listVJobs.Size = new System.Drawing.Size(472, 200);
			this.listVJobs.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listVJobs.TabIndex = 2;
			this.listVJobs.View = System.Windows.Forms.View.Details;
			// 
			// mnuCtxList
			// 
			this.mnuCtxList.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mnuIDelJob,
																					   this.mISepCtx,
																					   this.mnuIDispGridLines});
			// 
			// mnuIDelJob
			// 
			this.mnuIDelJob.Index = 0;
			this.mnuIDelJob.Text = "Delete Job";
			this.mnuIDelJob.Click += new System.EventHandler(this.mnuIDelJob_Click);
			// 
			// mISepCtx
			// 
			this.mISepCtx.Index = 1;
			this.mISepCtx.Text = "-";
			// 
			// mnuIDispGridLines
			// 
			this.mnuIDispGridLines.Checked = true;
			this.mnuIDispGridLines.Index = 2;
			this.mnuIDispGridLines.Text = "Display Grid lines";
			this.mnuIDispGridLines.Click += new System.EventHandler(this.mnuIDispGridLines_Click);
			// 
			// mainMnu
			// 
			this.mainMnu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mICtrl,
																					this.mIEdit,
																					this.mIView,
																					this.mIHelp});
			// 
			// mICtrl
			// 
			this.mICtrl.Index = 0;
			this.mICtrl.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.mICtrlRPR,
																				   this.mICtrlDPR,
																				   this.menuItem4,
																				   this.mICtrlExit});
			this.mICtrl.Text = "&Control";
			// 
			// mICtrlRPR
			// 
			this.mICtrlRPR.Index = 0;
			this.mICtrlRPR.Text = "&Register Printer";
			this.mICtrlRPR.Click += new System.EventHandler(this.mICtrlRPR_Click);
			// 
			// mICtrlDPR
			// 
			this.mICtrlDPR.Index = 1;
			this.mICtrlDPR.Text = "&DeRegister Printer";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "-";
			// 
			// mICtrlExit
			// 
			this.mICtrlExit.Index = 3;
			this.mICtrlExit.Text = "&Exit";
			this.mICtrlExit.Click += new System.EventHandler(this.mICtrlExit_Click);
			// 
			// mIEdit
			// 
			this.mIEdit.Index = 1;
			this.mIEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.mIDelJobs,
																				   this.mIProp});
			this.mIEdit.Text = "&Edit";
			// 
			// mIDelJobs
			// 
			this.mIDelJobs.Index = 0;
			this.mIDelJobs.Text = "Delete Jobs";
			this.mIDelJobs.Click += new System.EventHandler(this.mIDelJobs_Click);
			// 
			// mIProp
			// 
			this.mIProp.Index = 1;
			this.mIProp.Text = "Properties";
			this.mIProp.Click += new System.EventHandler(this.mIProp_Click);
			// 
			// mIView
			// 
			this.mIView.Index = 2;
			this.mIView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.mISetting});
			this.mIView.Text = "&View";
			// 
			// mISetting
			// 
			this.mISetting.Index = 0;
			this.mISetting.Text = "Printer Terminal Settings";
			// 
			// mIHelp
			// 
			this.mIHelp.Index = 3;
			this.mIHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.mIHelpAbout});
			this.mIHelp.Text = "&Help";
			// 
			// mIHelpAbout
			// 
			this.mIHelpAbout.Index = 0;
			this.mIHelpAbout.Text = "About EPrinterTerminal...";
			// 
			// statusBarPanelDummy
			// 
			this.statusBarPanelDummy.MinWidth = 3;
			this.statusBarPanelDummy.Width = 3;
			// 
			// statusBarPanelReq
			// 
			this.statusBarPanelReq.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanelReq.Icon = ((System.Drawing.Icon)(resources.GetObject("statusBarPanelReq.Icon")));
			this.statusBarPanelReq.MinWidth = 100;
			this.statusBarPanelReq.ToolTipText = "Displays the current status.";
			this.statusBarPanelReq.Width = 453;
			// 
			// statusBar
			// 
			this.statusBar.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.statusBar.Dock = System.Windows.Forms.DockStyle.None;
			this.statusBar.Location = new System.Drawing.Point(0, 203);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						 this.statusBarPanelReq,
																						 this.statusBarPanelDummy});
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new System.Drawing.Size(472, 22);
			this.statusBar.TabIndex = 1;
			// 
			// FrmEPrinterTerminal
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(472, 225);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.listVJobs,
																		  this.statusBar});
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMnu;
			this.Name = "FrmEPrinterTerminal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "EPrinterTerminal";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmEPrinterTerminal_Closing);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelDummy)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelReq)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FrmEPrinterTerminal());
		}

		private void mICtrlRPR_Click(object sender, System.EventArgs e)
		{
			FrmRegisterPrinter x = new FrmRegisterPrinter(this);
			x.ShowDialog();
		}

		private void mIDelJobs_Click(object sender, System.EventArgs e)
		{
			ListView.SelectedListViewItemCollection lstVSelColl 
				= new ListView.SelectedListViewItemCollection(listVJobs);

			lstVSelColl = listVJobs.SelectedItems;
	
			if (lstVSelColl.Count > 0 )
			{
				listVJobs.Items.Remove(lstVSelColl[0]);
			}

			if ( listVJobs.Items.Count <= 0)
			{
				mIDelJobs.Enabled = false;
				mnuIDelJob.Enabled = false;
			}
		}

		private void mnuIDelJob_Click(object sender, System.EventArgs e)
		{
			mIDelJobs_Click(sender,e);
		}

		private void mnuIDispGridLines_Click(object sender, System.EventArgs e)
		{
			if ( mnuIDispGridLines.Checked == true)
			{
				mnuIDispGridLines.Checked = false;	
				listVJobs.GridLines = false;
			}
			else
			{
				mnuIDispGridLines.Checked = true;
				listVJobs.GridLines = true;
			}
		}
	
	
		public static void PrintKeysAndValues( Hashtable myList )  
		{
			IDictionaryEnumerator myEnumerator = myList.GetEnumerator();
			Console.WriteLine( "\t-KEY-\t-VALUE-" );
			while ( myEnumerator.MoveNext() )
				Console.WriteLine("\t{0}:\t{1}", myEnumerator.Key, myEnumerator.Value);
			Console.WriteLine();
		}

		/// <summary>
		/// This function is called by the (FrmRegisterPrinter) form.
		/// </summary>
		/// <param name="strRprXmlRequest">The XML RPR request.</param>
		public void sendRprRequest(string strRprXmlRequest)
		{
			this.strRprXmlRequest = strRprXmlRequest;
			MessageBox.Show(strRprXmlRequest,"RPR request");
			// Write the RPR xml request into a file.
			XmlFileReaderWriter xfrw 
				= new XmlFileReaderWriter(EPTConstants.APP_CONFIG_PATH + "RegPrinter.xml");
			xfrw.WriteFile(strRprXmlRequest);

			// Sends a RPR request to the EPC on a separate thread.
			thrdRegisterPrinter 
				= new Thread(
				new ThreadStart( this.RegisterPrinterHandler ));	

			thrdRegisterPrinter.Name = "RPR Thread";
			thrdRegisterPrinter.Start();
		}

		/// <summary>
		/// This method runs as a separate thread.
		/// </summary>
		private void RegisterPrinterHandler()
		{
			ConnectionManager cm = new ConnectionManager
				((string) htConfigData["HostName"], // Host Name
				System.Int32.Parse( (string) htConfigData["PortNo"]) // Port No
				);
			
			// update the status bar.
			SetStatusBarText("Waiting for RPR response...");

			string strResponse 
				= cm.sendPostRequest(this.strRprXmlRequest);
			
			// TODO: Show RPR response.
			// TODO: please delete this when things are stable.
			MessageBox.Show(strResponse,"RPR response");

			// Now parse the XML response and do something.
			if ( strResponse != String.Empty)
			{
				StringReader sr = new StringReader(strResponse);
				XmlTextReader xtr = new XmlTextReader(sr);
				XmlResponseParser xrp = new XmlResponseParser(xtr);

				int iReturnCode = System.Int32.Parse(xrp.getReturnCode());
				
				switch (iReturnCode)
				{
					// OK
					case 200:
						// Save the Printer Id in the Hashtable.
						this.htConfigData.Remove("PrinterId");
						this.htConfigData.Add("PrinterId",xrp.getPrinterId());
						XmlFileReaderWriter xfrw 
							= new XmlFileReaderWriter(EPTConstants.APP_CONFIG_PATH + EPTConstants.APP_CONFIG_NAME);

						xfrw.WriteXmlFile(htConfigData,"Configuration");
						
						this.statusBarPanelReq.Icon = this.tmpPrinterIcon;
						this.mICtrlRPR.Enabled = false;							
						this.mICtrlDPR.Enabled = true;
						SetStatusBarText("EPrinterTerminal registration complete.");

						break;

					default:
						
						string strReturn = (string) this.htReturnCodes[iReturnCode+""];

						DialogResult dr = 
							MessageBox.Show("Unable to register printer : "+ strReturn ,
							"Please confim...",
							MessageBoxButtons.RetryCancel,
							MessageBoxIcon.Question,
							MessageBoxDefaultButton.Button1);

						if ( dr == DialogResult.Retry)
						{
							this.sendRprRequest(this.strRprXmlRequest);		
						}
						else if ( dr == DialogResult.Cancel)
						{
							// TODO: dont know what to do?		
						}

						break;
				}

			}
			else
			{
				// No response from the server.
			}
		}

		
		public void addJobDataToListView(string strFileName, string strCost, string strCopies)
		{
			string[] strListData = { System.DateTime.Now.ToString(), strFileName, strCost ,strCopies};
			ListViewItem lvi = new ListViewItem(strListData);
			listVJobs.Items.Add(lvi);
		}

		private void mIProp_Click(object sender, System.EventArgs e)
		{
			FrmEptConfig frmConf = new FrmEptConfig(this, this.htConfigData);
			frmConf.ShowDialog();
		}

		public void SetConfigHashtable(Hashtable htConfigData)
		{
			this.htConfigData = htConfigData;
		}

		public void SetStatusBarText(string strText)
		{
			statusBarPanelReq.Text = strText;
		}

		private void mICtrlExit_Click(object sender, System.EventArgs e)
		{
			DialogResult dr = 
				MessageBox.Show("Are you sure you want to exit?",
				"Please confirm...",
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2);

			if ( dr == DialogResult.OK)
			{
			//	closureActivities();
				//this.thrdEptPoller.Suspend();
				this.Close();
				this.Dispose();
				Application.Exit();				
			}
		}

		private void frmEPrinterTerminal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// TO DO: verify this code.
			/*
			DialogResult dr = 
				MessageBox.Show("Are you sure you want to exit?",
				"Please confirm...",
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2);

			if ( dr == DialogResult.OK)
			{
				Console.WriteLine("Form closing...OK button clicked");
				closureActivities();
			}
			else
			{
				// setting this to true to cancel the event.
				e.Cancel = true;
			}
			*/
		}

		private void closureActivities()
		{
			// TODO: identify closure activities, stop all threads etc.
			this.Close();
			this.Dispose();
			Application.Exit();				
		}
	
		public string getRCDescription(string strKey)
		{
			return (string) this.htReturnCodes[strKey];
		}

		/// <summary>
		/// [0] - AreaCode
		/// [1] - EPTHostIp
		/// [2] - EPTPortNo
		/// </summary>
		/// <returns> </returns>
		public string[] getEPTDetails()
		{
			return new string[] 
			{ 
			(string) this.htConfigData["AreaCode"],
			(string) this.htConfigData["EPTHostIp"],
			(string) this.htConfigData["EPTPortNo"]
			};
		}

	}
}
