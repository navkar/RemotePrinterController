using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CharacterCounterApp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class CharacterCounter : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textArea;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCharCnt;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CharacterCounter()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			this.btnClear = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textArea = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtCharCnt = new System.Windows.Forms.TextBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnClear
			// 
			this.btnClear.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnClear.Location = new System.Drawing.Point(324, 18);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(128, 27);
			this.btnClear.TabIndex = 1;
			this.btnClear.Text = "Clear Text";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(18, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Character Count :";
			// 
			// textArea
			// 
			this.textArea.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textArea.Multiline = true;
			this.textArea.Name = "textArea";
			this.textArea.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textArea.Size = new System.Drawing.Size(474, 252);
			this.textArea.TabIndex = 0;
			this.textArea.Text = "";
			this.textArea.WordWrap = false;
			this.textArea.TextChanged += new System.EventHandler(this.textArea_TextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.txtCharCnt,
																					this.label1,
																					this.btnClose,
																					this.btnClear});
			this.groupBox1.Location = new System.Drawing.Point(6, 252);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(468, 88);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// txtCharCnt
			// 
			this.txtCharCnt.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtCharCnt.Location = new System.Drawing.Point(144, 36);
			this.txtCharCnt.Name = "txtCharCnt";
			this.txtCharCnt.ReadOnly = true;
			this.txtCharCnt.Size = new System.Drawing.Size(72, 22);
			this.txtCharCnt.TabIndex = 5;
			this.txtCharCnt.Text = "";
			// 
			// btnClose
			// 
			this.btnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnClose.Location = new System.Drawing.Point(324, 54);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(128, 27);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// CharacterCounter
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(476, 343);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox1,
																		  this.textArea});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.Name = "CharacterCounter";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Character Counter Ver 1.0 - Naveen.K";
			this.TopMost = true;
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new CharacterCounter());
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			textArea.Text = "";
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void textArea_TextChanged(object sender, System.EventArgs e)
		{
			txtCharCnt.Text = textArea.Text.Length.ToString();
		}
	}
}
