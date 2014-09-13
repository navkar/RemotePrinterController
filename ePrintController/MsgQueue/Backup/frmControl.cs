namespace MessageQueue
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Data;
	using System.Net;
	using System.Messaging;
	using System.Text;
	using System.Threading;

    /// <summary>
    ///    Summary description for frmControl.
    /// </summary>
    public class frmControl : System.Windows.Forms.Form
    {
		frmServerQueue[] sq = new frmServerQueue[5];
		Thread[] tsq = new Thread[5];
		int sqi = 0;
		frmClientQueue[] cq = new frmClientQueue[5];
		Thread[] tcq = new Thread[5];
		int cqi = 0;

        /// <summary>
        ///    Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components;
		private System.Windows.Forms.Button btnClient;
		private System.Windows.Forms.Button btnServer;
		private System.Windows.Forms.Button btnCreateQ;
		private System.Windows.Forms.TextBox tbQueueName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbServerName;
		private System.Windows.Forms.Label label1;

        public frmControl()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            tbServerName.Text = System.Net.Dns.GetHostName();
			btnCreateQ.Enabled = (!(MessageQueue.Exists(tbServerName.Text + @"\private$\" + tbQueueName.Text)));
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager (typeof(frmControl));
			this.components = new System.ComponentModel.Container ();
			this.btnClient = new System.Windows.Forms.Button ();
			this.label2 = new System.Windows.Forms.Label ();
			this.btnServer = new System.Windows.Forms.Button ();
			this.tbServerName = new System.Windows.Forms.TextBox ();
			this.btnCreateQ = new System.Windows.Forms.Button ();
			this.label1 = new System.Windows.Forms.Label ();
			this.tbQueueName = new System.Windows.Forms.TextBox ();
			//@this.TrayHeight = 90;
			//@this.TrayLargeIcon = false;
			//@this.TrayAutoArrange = true;
			btnClient.Location = new System.Drawing.Point (248, 112);
			btnClient.Size = new System.Drawing.Size (104, 23);
			btnClient.TabIndex = 6;
			//btnClient.Anchor = System.Windows.Forms.AnchorStyles.BottomRight;
			btnClient.Text = "Spawn Client";
			btnClient.Click += new System.EventHandler (this.btnClient_Click);
			label2.Location = new System.Drawing.Point (24, 72);
			label2.Text = "Queue Name";
			label2.Size = new System.Drawing.Size (100, 23);
			label2.TabIndex = 2;
			btnServer.Location = new System.Drawing.Point (128, 112);
			btnServer.Size = new System.Drawing.Size (104, 24);
			btnServer.TabIndex = 5;
			btnServer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnServer.Text = "Spawn Server";
			btnServer.Click += new System.EventHandler (this.btnServer_Click);
			tbServerName.Location = new System.Drawing.Point (136, 24);
			tbServerName.Text = "CaoServer";
			tbServerName.TabIndex = 1;
			tbServerName.Size = new System.Drawing.Size (144, 23);
			btnCreateQ.Location = new System.Drawing.Point (8, 112);
			btnCreateQ.Size = new System.Drawing.Size (104, 24);
			btnCreateQ.TabIndex = 4;
			btnCreateQ.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnCreateQ.Text = "Create Queue";
			btnCreateQ.Click += new System.EventHandler (this.btnCreateQ_Click);
			label1.Location = new System.Drawing.Point (24, 32);
			label1.Text = "Local Machine";
			label1.Size = new System.Drawing.Size (100, 23);
			label1.TabIndex = 0;
			tbQueueName.Location = new System.Drawing.Point (136, 72);
			tbQueueName.Text = "PepaQueue";
			tbQueueName.TabIndex = 3;
			tbQueueName.Size = new System.Drawing.Size (144, 23);
			this.Text = "Message Queue Control";
			this.AutoScaleBaseSize = new System.Drawing.Size (6, 16);
			this.Icon = (System.Drawing.Icon) resources.GetObject ("$this.Icon");
			this.ClientSize = new System.Drawing.Size (368, 159);
			this.Controls.Add (this.btnClient);
			this.Controls.Add (this.btnServer);
			this.Controls.Add (this.btnCreateQ);
			this.Controls.Add (this.tbQueueName);
			this.Controls.Add (this.label2);
			this.Controls.Add (this.tbServerName);
			this.Controls.Add (this.label1);
		}

		protected void btnServer_Click (object sender, System.EventArgs e)
		{
			if (sqi <= 4)
			{
				sq[sqi] = new frmServerQueue();
				sq[sqi].SQID = sqi;
				sq[sqi].QueuePath = (tbServerName.Text + @"\private$\" + tbQueueName.Text);
				sq[sqi].ServerEvent += new frmServerQueue.ServerDelegate(EventServer);
				tsq[sqi] = new Thread(new ThreadStart(sq[sqi].RetrieveMsg));
				((frmServerQueue)sq[sqi]).Activate();
				tsq[sqi].Start();
				sqi++;
			}
		}
		protected void EventServer(object sender, int sqid)
		{
			sq[sqid] = null;
		}

		protected void btnClient_Click (object sender, System.EventArgs e)
		{
			if (cqi <= 4)
			{
				cq[cqi] = new frmClientQueue();
				cq[cqi].SQID = cqi;
				cq[cqi].QueuePath = (tbServerName.Text + @"\private$\" + tbQueueName.Text);
				cq[cqi].ClientEvent += new frmClientQueue.ClientDelegate(EventClient);
				tcq[cqi] = new Thread(new ThreadStart(cq[cqi].SendMsg));
				((frmClientQueue)cq[cqi]).Activate();
				tcq[cqi].Start();
				cqi++;
			}
		}
		protected void EventClient(object sender, int sqid)
		{
			cq[sqid] = null;
		}

		protected void btnCreateQ_Click (object sender, System.EventArgs e)
		{
			try
			{
				if (!(MessageQueue.Exists(tbServerName.Text + @"\private$\" + tbQueueName.Text)))
				{
					MessageQueue msgq = MessageQueue.Create(tbServerName.Text + @"\private$\" + tbQueueName.Text);
					MessageBox.Show("Message Queue " + tbServerName.Text + " was created in " + tbServerName.Text + " server.");
				}
				else
				{
					MessageBox.Show(tbQueueName.Text + " Already Exist");
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Exception Occurred while creating queue: " + tbQueueName.Text + "\n" + ex.ToString());
			}

		}

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main() 
        {
            Application.Run(new frmControl());
        }
    }
}
