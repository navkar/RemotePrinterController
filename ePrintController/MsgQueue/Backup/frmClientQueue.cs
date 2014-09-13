namespace MessageQueue
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
	using System.Threading;
	using System.Messaging;

    /// <summary>
    ///    Summary description for frmClientQueue.
    /// </summary>
    public class frmClientQueue : System.Windows.Forms.Form 
    {
		public delegate void ClientDelegate(object sender, int e);
		public event ClientDelegate ClientEvent;

		System.String  Path;
		int sqid;

        /// <summary>
        ///    Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components;
		private System.Windows.Forms.Button btnClose;

        public frmClientQueue()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager (typeof(frmClientQueue));
			this.components = new System.ComponentModel.Container ();
			this.btnClose = new System.Windows.Forms.Button ();
			//@this.TrayHeight = 90;
			//@this.TrayLargeIcon = false;
			//@this.TrayAutoArrange = true;
			btnClose.Location = new System.Drawing.Point (56, 24);
			btnClose.Size = new System.Drawing.Size (75, 23);
			btnClose.TabIndex = 0;
			//btnClose.Anchor = System.Windows.Forms.AnchorStyles.BottomRight;
			btnClose.Text = "Close";
			btnClose.Click += new System.EventHandler (this.btnClose_Click);
			this.Text = "Client Queue";
			this.AutoScaleBaseSize = new System.Drawing.Size (6, 16);
			this.Icon = (System.Drawing.Icon) resources.GetObject ("$this.Icon");
			this.ClientSize = new System.Drawing.Size (200, 87);
			this.Controls.Add (this.btnClose);
		}

		protected void btnClose_Click (object sender, System.EventArgs e)
		{
			this.ClientEvent(this, this.sqid);
			this.Close();
			Thread.CurrentThread.Abort();
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
		public void SendMsg()
		{
			this.Show();
			MessageQueue msgq = new MessageQueue();
			System.Messaging.Message msg = new System.Messaging.Message();
			msgq.Path = QueuePath;
			while (true)
			{
				try
				{
					for (int i=0; i<=10; i++)
					{
						msg.Label = "SQID" + SQID.ToString() + " - " + i.ToString();
						msgq.Send(msg);
					}
					System.Windows.Forms.Application.DoEvents();
					Thread.Sleep(500);
				}
				catch (Exception )
				{
					continue;
				}
				finally
				{
					this.Opacity = 75;
					this.Refresh();
					System.Windows.Forms.Application.DoEvents();
					Thread.Sleep(100);
					this.Opacity = 100;
				}
			} 
		}
    }
}
