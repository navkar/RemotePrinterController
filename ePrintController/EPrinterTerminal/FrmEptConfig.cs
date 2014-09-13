using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace EPrinterTerminal
{
	/// <summary>
	/// Summary description for FrmEptConfig.
	/// </summary>
	public class FrmEptConfig : System.Windows.Forms.Form
	{
		// 
		private Hashtable htConfigData = null;
		private string strConfigFileName 
				= EPTConstants.APP_CONFIG_PATH + EPTConstants.APP_CONFIG_NAME;
		private FrmEPrinterTerminal parentForm = null;
		//
		private System.Windows.Forms.GroupBox grpBoxConfig;
		private System.Windows.Forms.Label lblEPTConfig;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtHostName;
		private System.Windows.Forms.TextBox txtPortNo;
		private System.Windows.Forms.PictureBox pictBox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmEptConfig(FrmEPrinterTerminal parentForm, Hashtable htConfigData)
		{
			this.htConfigData = htConfigData;
			this.parentForm = parentForm;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			txtHostName.Text = (string) htConfigData["HostName"];
			txtPortNo.Text = (string) htConfigData["PortNo"];
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmEptConfig));
			this.txtHostName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblEPTConfig = new System.Windows.Forms.Label();
			this.grpBoxConfig = new System.Windows.Forms.GroupBox();
			this.pictBox = new System.Windows.Forms.PictureBox();
			this.txtPortNo = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.grpBoxConfig.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtHostName
			// 
			this.txtHostName.Location = new System.Drawing.Point(144, 64);
			this.txtHostName.MaxLength = 50;
			this.txtHostName.Name = "txtHostName";
			this.txtHostName.Size = new System.Drawing.Size(240, 21);
			this.txtHostName.TabIndex = 1;
			this.txtHostName.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 66);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "Host Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 98);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 14);
			this.label2.TabIndex = 0;
			this.label2.Text = "Port No:";
			// 
			// lblEPTConfig
			// 
			this.lblEPTConfig.AutoSize = true;
			this.lblEPTConfig.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblEPTConfig.Location = new System.Drawing.Point(80, 24);
			this.lblEPTConfig.Name = "lblEPTConfig";
			this.lblEPTConfig.Size = new System.Drawing.Size(196, 15);
			this.lblEPTConfig.TabIndex = 1;
			this.lblEPTConfig.Text = "EPrinterTerminal Configuration";
			// 
			// grpBoxConfig
			// 
			this.grpBoxConfig.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.pictBox,
																					   this.txtPortNo,
																					   this.txtHostName,
																					   this.label2,
																					   this.label1,
																					   this.lblEPTConfig});
			this.grpBoxConfig.Location = new System.Drawing.Point(1, -4);
			this.grpBoxConfig.Name = "grpBoxConfig";
			this.grpBoxConfig.Size = new System.Drawing.Size(424, 132);
			this.grpBoxConfig.TabIndex = 0;
			this.grpBoxConfig.TabStop = false;
			// 
			// pictBox
			// 
			this.pictBox.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictBox.Image")));
			this.pictBox.Location = new System.Drawing.Point(8, 15);
			this.pictBox.Name = "pictBox";
			this.pictBox.Size = new System.Drawing.Size(40, 40);
			this.pictBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictBox.TabIndex = 11;
			this.pictBox.TabStop = false;
			// 
			// txtPortNo
			// 
			this.txtPortNo.Location = new System.Drawing.Point(144, 96);
			this.txtPortNo.MaxLength = 5;
			this.txtPortNo.Name = "txtPortNo";
			this.txtPortNo.Size = new System.Drawing.Size(48, 21);
			this.txtPortNo.TabIndex = 2;
			this.txtPortNo.Text = "";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(344, 136);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(256, 136);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// FrmEptConfig
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(426, 167);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.grpBoxConfig,
																		  this.btnOK,
																		  this.btnCancel});
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmEptConfig";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "EPrinterTerminal Configuration";
			this.grpBoxConfig.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			string strHostName = txtHostName.Text;
			string strPortNo = txtPortNo.Text;
			
			try
			{

				if (strPortNo != String.Empty)
				{
					int iPortNo = System.Int32.Parse(strPortNo);

					if ( iPortNo < 0 || iPortNo > 65535)
					{
						MessageBox.Show("Specify a valid port no.","EPrinterTerminal Configuration",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
						txtPortNo.Focus();
					}
				}

				if (strHostName == String.Empty)
				{
					MessageBox.Show("Specify a host name.","EPrinterTerminal Configuration",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					txtHostName.Focus();
				}
				else if (strPortNo == String.Empty)
				{
					MessageBox.Show("Specify a port no.","EPrinterTerminal Configuration",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					txtPortNo.Focus();
				}
				else
				{
					htConfigData.Remove("HostName");
					htConfigData.Add("HostName", strHostName);

					htConfigData.Remove("PortNo");
					htConfigData.Add("PortNo", strPortNo);

					XmlFileReaderWriter xfrw 
						= new XmlFileReaderWriter(this.strConfigFileName);

					xfrw.WriteXmlFile(htConfigData,"Configuration");
					parentForm.SetStatusBarText("Configuration information was saved successfully.");
					parentForm.SetConfigHashtable(htConfigData);
					this.Close();
				}
			}
			catch(Exception)
			{
				MessageBox.Show("Specify a valid port no.","EPrinterTerminal Configuration",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				txtPortNo.Focus();
			}

		}
	}
}
