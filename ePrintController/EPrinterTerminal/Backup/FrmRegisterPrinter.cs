using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace EPrinterTerminal
{
	/// <summary>
	/// Summary description for Form2.
	/// </summary>
	public class FrmRegisterPrinter : System.Windows.Forms.Form
	{
		private FrmEPrinterTerminal parentForm;
		private System.Windows.Forms.Label lblTxtPrinterCap;
		private System.Windows.Forms.Label lblTxtPMan;
		private System.Windows.Forms.TextBox txtPManufacturer;
		private System.Windows.Forms.Label lblTxtPModel;
		private System.Windows.Forms.TextBox txtPModel;
		private System.Windows.Forms.Label lblTxtPType;
		private System.Windows.Forms.ComboBox cmbPType;
		private System.Windows.Forms.Label lblTxtColor;
		private System.Windows.Forms.ComboBox cmbPColor;
		private System.Windows.Forms.Label lblTxtDuplex;
		private System.Windows.Forms.ComboBox cmbPDuplex;
		private System.Windows.Forms.Label lblAsterisk;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ListView lstVPaperInfo;
		private System.Windows.Forms.Label lblTxtPInfo;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Button btnListAdd;
		private System.Windows.Forms.Button btnListDel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox grpBoxRPDiag;
		private System.Windows.Forms.Label lblAsterisk2;
		private System.Windows.Forms.ContextMenu ctxMnuPI;
		private System.Windows.Forms.MenuItem mnuIGridLines;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmRegisterPrinter(FrmEPrinterTerminal ept)
		{
			this.parentForm = ept;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.cmbPDuplex.Items.AddRange(new object[] {
															EPTConstants.OPT_NO,
															EPTConstants.OPT_YES});

			this.cmbPType.Items.AddRange(new object[] {
														  EPTConstants.OPT_OTHERS,
														  EPTConstants.OPT_INKJET,
														  EPTConstants.OPT_LASER});

			this.cmbPColor.Items.AddRange(new object[] {
														   EPTConstants.OPT_NO,
														   EPTConstants.OPT_YES});
	
			cmbPType.SelectedIndex = 0;
			cmbPColor.SelectedIndex = 0;
			cmbPDuplex.SelectedIndex = 0; 

			// Initializing the Column Headers for List View.
			ColumnHeader[] colHeader = new ColumnHeader[3];

			colHeader[0] = new ColumnHeader();
			colHeader[0].Text = "Paper Size";
			colHeader[0].Width = lstVPaperInfo.Width/4;
			
			colHeader[1] = new ColumnHeader();
			colHeader[1].Text = "Paper Width (Cms)";
			colHeader[1].Width = lstVPaperInfo.Width/3;

			colHeader[2] = new ColumnHeader();
			colHeader[2].Text = "Paper Height (Cms)";
			colHeader[2].Width = lstVPaperInfo.Width/3;

			ListView.ColumnHeaderCollection lvColHeadColl 
					= new ListView.ColumnHeaderCollection(lstVPaperInfo);
			lvColHeadColl.AddRange(colHeader);

			string[] str = { "A4", "80", "118" };

			ListViewItem lvi = new ListViewItem(str);

			lstVPaperInfo.Items.Add(lvi);

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmRegisterPrinter));
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnListAdd = new System.Windows.Forms.Button();
			this.lblTxtDuplex = new System.Windows.Forms.Label();
			this.txtPModel = new System.Windows.Forms.TextBox();
			this.txtPManufacturer = new System.Windows.Forms.TextBox();
			this.cmbPColor = new System.Windows.Forms.ComboBox();
			this.lblTxtPType = new System.Windows.Forms.Label();
			this.cmbPDuplex = new System.Windows.Forms.ComboBox();
			this.lblAsterisk = new System.Windows.Forms.Label();
			this.lblTxtPMan = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.grpBoxRPDiag = new System.Windows.Forms.GroupBox();
			this.lblAsterisk2 = new System.Windows.Forms.Label();
			this.btnListDel = new System.Windows.Forms.Button();
			this.lblTxtPInfo = new System.Windows.Forms.Label();
			this.lstVPaperInfo = new System.Windows.Forms.ListView();
			this.ctxMnuPI = new System.Windows.Forms.ContextMenu();
			this.mnuIGridLines = new System.Windows.Forms.MenuItem();
			this.lblTxtColor = new System.Windows.Forms.Label();
			this.cmbPType = new System.Windows.Forms.ComboBox();
			this.lblTxtPModel = new System.Windows.Forms.Label();
			this.lblTxtPrinterCap = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.grpBoxRPDiag.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox2
			// 
			this.pictureBox2.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.pictureBox2.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(8, 198);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(45, 36);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox2.TabIndex = 15;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(40, 40);
			this.pictureBox1.TabIndex = 12;
			this.pictureBox1.TabStop = false;
			// 
			// btnListAdd
			// 
			this.btnListAdd.Location = new System.Drawing.Point(136, 352);
			this.btnListAdd.Name = "btnListAdd";
			this.btnListAdd.TabIndex = 16;
			this.btnListAdd.Text = "&Add";
			this.btnListAdd.Click += new System.EventHandler(this.btnListAdd_Click);
			// 
			// lblTxtDuplex
			// 
			this.lblTxtDuplex.AutoSize = true;
			this.lblTxtDuplex.Location = new System.Drawing.Point(8, 184);
			this.lblTxtDuplex.Name = "lblTxtDuplex";
			this.lblTxtDuplex.Size = new System.Drawing.Size(96, 14);
			this.lblTxtDuplex.TabIndex = 0;
			this.lblTxtDuplex.Text = "Duplex support:";
			// 
			// txtPModel
			// 
			this.txtPModel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtPModel.Location = new System.Drawing.Point(160, 88);
			this.txtPModel.MaxLength = 30;
			this.txtPModel.Name = "txtPModel";
			this.txtPModel.Size = new System.Drawing.Size(240, 21);
			this.txtPModel.TabIndex = 2;
			this.txtPModel.Text = "";
			// 
			// txtPManufacturer
			// 
			this.txtPManufacturer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtPManufacturer.Location = new System.Drawing.Point(160, 56);
			this.txtPManufacturer.MaxLength = 30;
			this.txtPManufacturer.Name = "txtPManufacturer";
			this.txtPManufacturer.Size = new System.Drawing.Size(240, 21);
			this.txtPManufacturer.TabIndex = 1;
			this.txtPManufacturer.Text = "";
			// 
			// cmbPColor
			// 
			this.cmbPColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPColor.DropDownWidth = 121;
			this.cmbPColor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbPColor.Location = new System.Drawing.Point(160, 152);
			this.cmbPColor.Name = "cmbPColor";
			this.cmbPColor.TabIndex = 4;
			// 
			// lblTxtPType
			// 
			this.lblTxtPType.AutoSize = true;
			this.lblTxtPType.Location = new System.Drawing.Point(8, 120);
			this.lblTxtPType.Name = "lblTxtPType";
			this.lblTxtPType.Size = new System.Drawing.Size(79, 14);
			this.lblTxtPType.TabIndex = 0;
			this.lblTxtPType.Text = "Printer Type:";
			// 
			// cmbPDuplex
			// 
			this.cmbPDuplex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPDuplex.DropDownWidth = 121;
			this.cmbPDuplex.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbPDuplex.Location = new System.Drawing.Point(160, 184);
			this.cmbPDuplex.Name = "cmbPDuplex";
			this.cmbPDuplex.TabIndex = 5;
			// 
			// lblAsterisk
			// 
			this.lblAsterisk.AutoSize = true;
			this.lblAsterisk.ForeColor = System.Drawing.Color.DarkRed;
			this.lblAsterisk.Location = new System.Drawing.Point(400, 88);
			this.lblAsterisk.Name = "lblAsterisk";
			this.lblAsterisk.Size = new System.Drawing.Size(11, 14);
			this.lblAsterisk.TabIndex = 11;
			this.lblAsterisk.Text = "*";
			// 
			// lblTxtPMan
			// 
			this.lblTxtPMan.AutoSize = true;
			this.lblTxtPMan.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTxtPMan.Location = new System.Drawing.Point(8, 56);
			this.lblTxtPMan.Name = "lblTxtPMan";
			this.lblTxtPMan.Size = new System.Drawing.Size(127, 14);
			this.lblTxtPMan.TabIndex = 0;
			this.lblTxtPMan.Text = "Printer Manufacturer:";
			// 
			// btnOK
			// 
			this.btnOK.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnOK.Location = new System.Drawing.Point(264, 392);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// grpBoxRPDiag
			// 
			this.grpBoxRPDiag.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.grpBoxRPDiag.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.lblAsterisk2,
																					   this.btnListDel,
																					   this.btnListAdd,
																					   this.pictureBox2,
																					   this.lblTxtPInfo,
																					   this.lstVPaperInfo,
																					   this.pictureBox1,
																					   this.lblAsterisk,
																					   this.cmbPDuplex,
																					   this.lblTxtDuplex,
																					   this.cmbPColor,
																					   this.lblTxtColor,
																					   this.cmbPType,
																					   this.lblTxtPType,
																					   this.txtPModel,
																					   this.lblTxtPModel,
																					   this.txtPManufacturer,
																					   this.lblTxtPMan,
																					   this.lblTxtPrinterCap});
			this.grpBoxRPDiag.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpBoxRPDiag.Location = new System.Drawing.Point(7, 0);
			this.grpBoxRPDiag.Name = "grpBoxRPDiag";
			this.grpBoxRPDiag.Size = new System.Drawing.Size(428, 384);
			this.grpBoxRPDiag.TabIndex = 0;
			this.grpBoxRPDiag.TabStop = false;
			// 
			// lblAsterisk2
			// 
			this.lblAsterisk2.AutoSize = true;
			this.lblAsterisk2.ForeColor = System.Drawing.Color.DarkRed;
			this.lblAsterisk2.Location = new System.Drawing.Point(184, 216);
			this.lblAsterisk2.Name = "lblAsterisk2";
			this.lblAsterisk2.Size = new System.Drawing.Size(11, 14);
			this.lblAsterisk2.TabIndex = 11;
			this.lblAsterisk2.Text = "*";
			// 
			// btnListDel
			// 
			this.btnListDel.Location = new System.Drawing.Point(224, 352);
			this.btnListDel.Name = "btnListDel";
			this.btnListDel.TabIndex = 17;
			this.btnListDel.Text = "&Delete";
			this.btnListDel.Click += new System.EventHandler(this.btnListDel_Click);
			// 
			// lblTxtPInfo
			// 
			this.lblTxtPInfo.AutoSize = true;
			this.lblTxtPInfo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTxtPInfo.Location = new System.Drawing.Point(56, 216);
			this.lblTxtPInfo.Name = "lblTxtPInfo";
			this.lblTxtPInfo.Size = new System.Drawing.Size(117, 15);
			this.lblTxtPInfo.TabIndex = 14;
			this.lblTxtPInfo.Text = "Paper Information";
			// 
			// lstVPaperInfo
			// 
			this.lstVPaperInfo.ContextMenu = this.ctxMnuPI;
			this.lstVPaperInfo.FullRowSelect = true;
			this.lstVPaperInfo.GridLines = true;
			this.lstVPaperInfo.Location = new System.Drawing.Point(9, 240);
			this.lstVPaperInfo.MultiSelect = false;
			this.lstVPaperInfo.Name = "lstVPaperInfo";
			this.lstVPaperInfo.Size = new System.Drawing.Size(408, 97);
			this.lstVPaperInfo.TabIndex = 13;
			this.lstVPaperInfo.View = System.Windows.Forms.View.Details;
			// 
			// ctxMnuPI
			// 
			this.ctxMnuPI.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mnuIGridLines});
			// 
			// mnuIGridLines
			// 
			this.mnuIGridLines.Checked = true;
			this.mnuIGridLines.Index = 0;
			this.mnuIGridLines.Text = "Enable Grid Lines";
			this.mnuIGridLines.Click += new System.EventHandler(this.mnuIGridLines_Click);
			// 
			// lblTxtColor
			// 
			this.lblTxtColor.AutoSize = true;
			this.lblTxtColor.Location = new System.Drawing.Point(8, 152);
			this.lblTxtColor.Name = "lblTxtColor";
			this.lblTxtColor.Size = new System.Drawing.Size(86, 14);
			this.lblTxtColor.TabIndex = 0;
			this.lblTxtColor.Text = "Color support:";
			// 
			// cmbPType
			// 
			this.cmbPType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPType.DropDownWidth = 121;
			this.cmbPType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbPType.Location = new System.Drawing.Point(160, 120);
			this.cmbPType.Name = "cmbPType";
			this.cmbPType.TabIndex = 3;
			// 
			// lblTxtPModel
			// 
			this.lblTxtPModel.AutoSize = true;
			this.lblTxtPModel.Location = new System.Drawing.Point(8, 88);
			this.lblTxtPModel.Name = "lblTxtPModel";
			this.lblTxtPModel.Size = new System.Drawing.Size(85, 14);
			this.lblTxtPModel.TabIndex = 0;
			this.lblTxtPModel.Text = "Printer Model:";
			// 
			// lblTxtPrinterCap
			// 
			this.lblTxtPrinterCap.AutoSize = true;
			this.lblTxtPrinterCap.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTxtPrinterCap.Location = new System.Drawing.Point(56, 24);
			this.lblTxtPrinterCap.Name = "lblTxtPrinterCap";
			this.lblTxtPrinterCap.Size = new System.Drawing.Size(121, 15);
			this.lblTxtPrinterCap.TabIndex = 0;
			this.lblTxtPrinterCap.Text = "Printer Capabilities";
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(352, 392);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// FrmRegisterPrinter
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 431);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancel,
																		  this.btnOK,
																		  this.grpBoxRPDiag});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmRegisterPrinter";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Register New Printer...";
			this.grpBoxRPDiag.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnListDel_Click(object sender, System.EventArgs e)
		{
			ListView.SelectedListViewItemCollection lstVSelColl 
						= new ListView.SelectedListViewItemCollection(lstVPaperInfo);

			lstVSelColl = lstVPaperInfo.SelectedItems;
	
			if (lstVSelColl.Count > 0 )
			{
				lstVPaperInfo.Items.Remove(lstVSelColl[0]);
			}

			if ( lstVPaperInfo.Items.Count <= 0)
			{
				btnListDel.Enabled = false;
			}

		}

		private void btnListAdd_Click(object sender, System.EventArgs e)
		{
			FrmRPRAddPaperInfo addPaperInfo	= new FrmRPRAddPaperInfo(this);
					addPaperInfo.ShowDialog();

			if (lstVPaperInfo.Items.Count > 0)
			{
				btnListDel.Enabled = true;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strPaperSize"></param>
		/// <param name="strPaperWidth"></param>
		/// <param name="strPaperHeight"></param>
		/// <returns>true - paper added, false otherwise</returns>
		public bool AddPaperInfo(string strPaperSize, string strPaperWidth, string strPaperHeight)
		{
			if ( checkPaperSize(strPaperSize) )
			{
				return false;
			}
			else
			{
				string[] strPaperInfo = new string[]{ 
													strPaperSize,
													strPaperWidth,
													strPaperHeight
													};

				lstVPaperInfo.Items.Add(new ListViewItem(strPaperInfo)); 
				return true;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strPaperSize"></param>
		/// <returns>True - paper exists. </returns>
		private bool checkPaperSize(string strPaperSize)
		{
			ListView.ListViewItemCollection lstViewItemColl = lstVPaperInfo.Items;
			bool bFoundItem = false;

			if (lstViewItemColl.Count > 0 )
			{
				for (int iCnt = 0 ; iCnt < lstViewItemColl.Count; iCnt++ )
				{
					ListViewItem lstItem = lstViewItemColl[iCnt];

					if ( lstItem.Text.Equals(strPaperSize))
					{
						bFoundItem = true;
						break;
					}
				}
			}

			return bFoundItem;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			// Check for atleast 1 PaperInfo.
			if ( txtPModel.Text.Trim().Equals("") )
			{
				MessageBox.Show(this,"Specify the Printer Model.",
					"Paper Information...", MessageBoxButtons.OK,MessageBoxIcon.Information);
				txtPModel.Focus();
			}
			else if (lstVPaperInfo.Items.Count == 0 )
			{
				MessageBox.Show(this,"Specify atleast one Paper Information.",
					"Paper Size Information...", MessageBoxButtons.OK,MessageBoxIcon.Information);
				btnListAdd.Focus();

			}
			else // Construct data objects and generate XML data.
			{
				ListView.ListViewItemCollection
								lstViewItemColl = lstVPaperInfo.Items;
			
				PaperInfo[] paperInfo = null;

				if (lstViewItemColl.Count > 0 )
				{
					int iNoOfPapers = lstViewItemColl.Count;

					paperInfo = new PaperInfo[iNoOfPapers];

					for (int iCnt = 0 ; iCnt < iNoOfPapers; iCnt++ )
					{
						ListViewItem lstItem = lstViewItemColl[iCnt];

						ListViewItem.ListViewSubItemCollection 
										lstVSIColl = lstItem.SubItems;

						paperInfo[iCnt] = new PaperInfo(lstVSIColl[0].Text,
													lstVSIColl[1].Text,
													lstVSIColl[2].Text );
					}
				}

				string strPType = null;
				switch( cmbPType.Text)
				{
					case EPTConstants.OPT_OTHERS :
							strPType = "0";
							break;

					case EPTConstants.OPT_INKJET :
							strPType = "1";
							break;

					case EPTConstants.OPT_LASER :
							strPType = "2";	
							break;
				}

				string strPColor = null;
				switch( cmbPColor.Text)
				{
					case EPTConstants.OPT_YES :
						strPColor = "1";
						break;

					case EPTConstants.OPT_NO :
						strPColor = "0";
						break;
				}

				string strPDuplex = null;
				switch( cmbPDuplex.Text)
				{
					case EPTConstants.OPT_YES :
						strPDuplex = "1";
						break;

					case EPTConstants.OPT_NO :
						strPDuplex = "0";
						break;
				}
				// Create the printer capabilties object.
				
				string[] strEptDetails = parentForm.getEPTDetails();
				PrinterCap printerCap = new PrinterCap(strEptDetails[0],
					strEptDetails[1],
					strEptDetails[2],
					txtPManufacturer.Text,
					txtPModel.Text, strPType, strPColor, strPDuplex, paperInfo);
	
				// Send the XML data to the parent.
				this.parentForm.sendRprRequest(
					EPTXmlRequest.GetRPRRequest(printerCap)
					);
				// Closes the form.
				this.Close();
			}
		}

		private void mnuIGridLines_Click(object sender, System.EventArgs e)
		{
			if ( lstVPaperInfo.GridLines == true)
			{
				lstVPaperInfo.GridLines = false;
				mnuIGridLines.Checked = false;	
			}
			else
			{
				lstVPaperInfo.GridLines = true;
				mnuIGridLines.Checked = true;
			}
				
		}

	}
}
