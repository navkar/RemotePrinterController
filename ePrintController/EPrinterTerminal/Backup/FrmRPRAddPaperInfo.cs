using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace EPrinterTerminal
{
	/// <summary>
	/// Summary description for FrmRPRAddPaperInfo.
	/// </summary>
	public class FrmRPRAddPaperInfo : System.Windows.Forms.Form
	{
		private FrmRegisterPrinter frmParent;
		private System.Windows.Forms.Label lblTxtPSize;
		private System.Windows.Forms.Label lblTxtPWidth;
		private System.Windows.Forms.Label lblTxtPHeight;
		private System.Windows.Forms.ComboBox cmbBoxPSize;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnPIAdd;
		private System.Windows.Forms.Button btnPICancel;
		private System.Windows.Forms.TextBox txtPHeight;
		private System.Windows.Forms.TextBox txtPWidth;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmRPRAddPaperInfo(FrmRegisterPrinter frmParent)
		{
			this.frmParent = frmParent;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			cmbBoxPSize.SelectedIndex = 0;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FrmRPRAddPaperInfo));
			this.lblTxtPHeight = new System.Windows.Forms.Label();
			this.btnPICancel = new System.Windows.Forms.Button();
			this.lblTxtPSize = new System.Windows.Forms.Label();
			this.cmbBoxPSize = new System.Windows.Forms.ComboBox();
			this.txtPWidth = new System.Windows.Forms.TextBox();
			this.lblTxtPWidth = new System.Windows.Forms.Label();
			this.txtPHeight = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnPIAdd = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblTxtPHeight
			// 
			this.lblTxtPHeight.AutoSize = true;
			this.lblTxtPHeight.Location = new System.Drawing.Point(8, 112);
			this.lblTxtPHeight.Name = "lblTxtPHeight";
			this.lblTxtPHeight.Size = new System.Drawing.Size(83, 14);
			this.lblTxtPHeight.TabIndex = 2;
			this.lblTxtPHeight.Text = "Paper Height:";
			// 
			// btnPICancel
			// 
			this.btnPICancel.Location = new System.Drawing.Point(112, 152);
			this.btnPICancel.Name = "btnPICancel";
			this.btnPICancel.TabIndex = 9;
			this.btnPICancel.Text = "Cancel";
			this.btnPICancel.Click += new System.EventHandler(this.btnPICancel_Click);
			// 
			// lblTxtPSize
			// 
			this.lblTxtPSize.AutoSize = true;
			this.lblTxtPSize.Location = new System.Drawing.Point(8, 48);
			this.lblTxtPSize.Name = "lblTxtPSize";
			this.lblTxtPSize.Size = new System.Drawing.Size(69, 14);
			this.lblTxtPSize.TabIndex = 0;
			this.lblTxtPSize.Text = "Paper Size:";
			// 
			// cmbBoxPSize
			// 
			this.cmbBoxPSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBoxPSize.DropDownWidth = 121;
			this.cmbBoxPSize.Items.AddRange(new object[] {
															 "A3",
															 "A4",
															 "B4",
															 "Envelope",
															 "Letter",
															 "Custom"});
			this.cmbBoxPSize.Location = new System.Drawing.Point(104, 48);
			this.cmbBoxPSize.Name = "cmbBoxPSize";
			this.cmbBoxPSize.Size = new System.Drawing.Size(96, 21);
			this.cmbBoxPSize.TabIndex = 3;
			// 
			// txtPWidth
			// 
			this.txtPWidth.Location = new System.Drawing.Point(104, 80);
			this.txtPWidth.MaxLength = 4;
			this.txtPWidth.Name = "txtPWidth";
			this.txtPWidth.Size = new System.Drawing.Size(96, 21);
			this.txtPWidth.TabIndex = 6;
			this.txtPWidth.Text = "";
			// 
			// lblTxtPWidth
			// 
			this.lblTxtPWidth.AutoSize = true;
			this.lblTxtPWidth.Location = new System.Drawing.Point(8, 80);
			this.lblTxtPWidth.Name = "lblTxtPWidth";
			this.lblTxtPWidth.Size = new System.Drawing.Size(79, 14);
			this.lblTxtPWidth.TabIndex = 1;
			this.lblTxtPWidth.Text = "Paper Width:";
			// 
			// txtPHeight
			// 
			this.txtPHeight.Location = new System.Drawing.Point(104, 112);
			this.txtPHeight.MaxLength = 4;
			this.txtPHeight.Name = "txtPHeight";
			this.txtPHeight.Size = new System.Drawing.Size(96, 21);
			this.txtPHeight.TabIndex = 7;
			this.txtPHeight.Text = "";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(40, 40);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// btnPIAdd
			// 
			this.btnPIAdd.Location = new System.Drawing.Point(24, 152);
			this.btnPIAdd.Name = "btnPIAdd";
			this.btnPIAdd.TabIndex = 8;
			this.btnPIAdd.Text = "OK";
			this.btnPIAdd.Click += new System.EventHandler(this.btnPIAdd_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(48, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(167, 15);
			this.label1.TabIndex = 5;
			this.label1.Text = "Specify Paper Information";
			// 
			// FrmRPRAddPaperInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(228, 185);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnPICancel,
																		  this.btnPIAdd,
																		  this.txtPHeight,
																		  this.txtPWidth,
																		  this.label1,
																		  this.lblTxtPHeight,
																		  this.lblTxtPWidth,
																		  this.lblTxtPSize,
																		  this.pictureBox1,
																		  this.cmbBoxPSize});
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmRPRAddPaperInfo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Paper Info...";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnPIAdd_Click(object sender, System.EventArgs e)
		{
			bool bAdded = frmParent.AddPaperInfo((string)cmbBoxPSize.SelectedItem, txtPWidth.Text, txtPHeight.Text);

			if (bAdded == false)
			{
				MessageBox.Show(this,"Specified Paper Size already exists! Please specify another.",
				"Duplicate Paper Size", MessageBoxButtons.OK,MessageBoxIcon.Information);
				cmbBoxPSize.Focus();
			}
			else
			{
				this.Close();
			}
		}

		private void btnPICancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
