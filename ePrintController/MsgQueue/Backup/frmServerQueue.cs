namespace MessageQueue
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
	using System.Messaging;
	using System.Threading;

    /// <summary>
    ///    Summary description for ServerQueue.
    /// </summary>
    public class frmServerQueue : System.Windows.Forms.Form
    {
		public delegate void ServerDelegate(object sender, int e);
		public event ServerDelegate ServerEvent;

		string  Path;
		int sqid;
        /// <summary>
        ///    Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components;
		private System.Windows.Forms.PictureBox pbGo;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.PictureBox pbWait;
		private System.Windows.Forms.Button btnEndServer;
		private System.Windows.Forms.ListBox listBox1;

		public frmServerQueue()
		{
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }
		public int SQID
		{
			get
			{
				return this.sqid;
			}
			set
			{
				this.sqid = value;
			}
		}
		public string QueuePath
		{
			get
			{
				return this.Path;
			}
			set
			{
				this.Path = value;
			}
		}
		public void RetrieveMsg()
		{
			this.Show();
			MessageQueue msgq = new MessageQueue();
			System.Messaging.Message msg = new System.Messaging.Message();
			msgq.Path = QueuePath;
			while (true)
			{
				try
				{
					msg = msgq.Receive(new TimeSpan(0,0,0,1));
					listBox1.Items.Add(("Message:" + msg.Label + ",  Time:" + msg.SentTime.ToLongTimeString()));
				}
				catch (Exception )
				{
					continue;
				}
				finally
				{
					this.pbGo.Visible = !this.pbGo.Visible;
					this.pbWait.Visible = !this.pbWait.Visible;
					pbWait.Invalidate();
					System.Windows.Forms.Application.DoEvents();
					Thread.Sleep(100);
				}
			} 
		}

        /// <summary>
        ///    Clean up any resources being used.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            components.Dispose();
        }

        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager (typeof(frmServerQueue));
			this.components = new System.ComponentModel.Container ();
			this.btnEndServer = new System.Windows.Forms.Button ();
			this.pbWait = new System.Windows.Forms.PictureBox ();
			this.pbGo = new System.Windows.Forms.PictureBox ();
			this.listBox1 = new System.Windows.Forms.ListBox ();
			this.btnClear = new System.Windows.Forms.Button ();
			//@this.TrayHeight = 0;
			//@this.TrayLargeIcon = false;
			//@this.TrayAutoArrange = true;
			btnEndServer.Location = new System.Drawing.Point (8, 256);
			btnEndServer.Size = new System.Drawing.Size (64, 23);
			btnEndServer.TabIndex = 1;
			btnEndServer.Text = "End";
			btnEndServer.Click += new System.EventHandler (this.btnEndServer_Click);
			pbWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pbWait.Location = new System.Drawing.Point (264, 248);
			pbWait.Size = new System.Drawing.Size (32, 32);
			pbWait.TabIndex = 2;
			pbWait.TabStop = false;
			pbWait.Image = (System.Drawing.Image) resources.GetObject ("pbWait.Image");
			pbGo.Visible = false;
			pbGo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pbGo.Location = new System.Drawing.Point (264, 248);
			pbGo.Size = new System.Drawing.Size (32, 32);
			pbGo.TabIndex = 5;
			pbGo.TabStop = false;
			pbGo.Image = (System.Drawing.Image) resources.GetObject ("pbGo.Image");
			listBox1.Location = new System.Drawing.Point (8, 16);
			listBox1.Size = new System.Drawing.Size (352, 228);
			listBox1.TabIndex = 0;
			btnClear.Location = new System.Drawing.Point (88, 256);
			btnClear.Size = new System.Drawing.Size (72, 23);
			btnClear.TabIndex = 3;
			btnClear.Text = "Clear";
			btnClear.Click += new System.EventHandler (this.btnClear_Click);
			this.Text = "ServerQueue";
			this.AutoScaleBaseSize = new System.Drawing.Size (6, 16);
			this.Icon = (System.Drawing.Icon) resources.GetObject ("$this.Icon");
			this.ClientSize = new System.Drawing.Size (368, 287);
			this.Controls.Add (this.pbGo);
			this.Controls.Add (this.btnClear);
			this.Controls.Add (this.pbWait);
			this.Controls.Add (this.btnEndServer);
			this.Controls.Add (this.listBox1);
		}

		protected void btnClear_Click (object sender, System.EventArgs e)
		{
			listBox1.Items.Clear();
		}

		protected void btnEndServer_Click (object sender, System.EventArgs e)
		{
			this.ServerEvent(this,this.sqid);
			this.Close();
			Thread.CurrentThread.Abort();
		}
    }
}
