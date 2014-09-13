using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO; 
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace EPTDummy
{
	/// <summary>
	/// The dummy that is used to test the EPT. 
	/// </summary>
	public class EPrinterDummy : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblHost;
		private System.Windows.Forms.TextBox txtHost;
		private System.Windows.Forms.Label lblPort;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label lblRequest;
		private System.Windows.Forms.ComboBox cmbRequest;
		private System.Windows.Forms.Label lblReq;
		private System.Windows.Forms.TextBox txtAreaRequest;
		private System.Windows.Forms.Label lblRes;
		private System.Windows.Forms.TextBox txtAreaResponse;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Button btnClear;
		private string BOUNDARY = "12345PQXYZ";	
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EPrinterDummy()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.cmbRequest.SelectedIndex = 0;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EPrinterDummy));
            this.cmbRequest = new System.Windows.Forms.ComboBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtAreaResponse = new System.Windows.Forms.TextBox();
            this.lblRequest = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblRes = new System.Windows.Forms.Label();
            this.lblReq = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtAreaRequest = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbRequest
            // 
            this.cmbRequest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRequest.DropDownWidth = 88;
            this.cmbRequest.Items.AddRange(new object[] {
            "Select",
            "RPR",
            "DPR",
            "GJF",
            "NJS",
            "NPS",
            "NWJ"});
            this.cmbRequest.Location = new System.Drawing.Point(404, 8);
            this.cmbRequest.Name = "cmbRequest";
            this.cmbRequest.Size = new System.Drawing.Size(88, 22);
            this.cmbRequest.TabIndex = 4;
            this.cmbRequest.SelectedIndexChanged += new System.EventHandler(this.cmbRequest_SelectedIndexChanged);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(240, 8);
            this.txtPort.MaxLength = 5;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(48, 22);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "80";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(160, 424);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "&Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtAreaResponse
            // 
            this.txtAreaResponse.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAreaResponse.Location = new System.Drawing.Point(0, 232);
            this.txtAreaResponse.Multiline = true;
            this.txtAreaResponse.Name = "txtAreaResponse";
            this.txtAreaResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAreaResponse.Size = new System.Drawing.Size(504, 184);
            this.txtAreaResponse.TabIndex = 8;
            this.txtAreaResponse.WordWrap = false;
            // 
            // lblRequest
            // 
            this.lblRequest.AutoSize = true;
            this.lblRequest.Location = new System.Drawing.Point(304, 12);
            this.lblRequest.Name = "lblRequest";
            this.lblRequest.Size = new System.Drawing.Size(97, 14);
            this.lblRequest.TabIndex = 3;
            this.lblRequest.Text = "Request Type:";
            // 
            // txtHost
            // 
            this.txtHost.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHost.Location = new System.Drawing.Point(93, 8);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(64, 22);
            this.txtHost.TabIndex = 1;
            this.txtHost.Text = "localhost";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(168, 11);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(59, 14);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port No:";
            // 
            // lblRes
            // 
            this.lblRes.AutoSize = true;
            this.lblRes.Location = new System.Drawing.Point(8, 213);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(74, 14);
            this.lblRes.TabIndex = 7;
            this.lblRes.Text = "Response:";
            // 
            // lblReq
            // 
            this.lblReq.AutoSize = true;
            this.lblReq.Location = new System.Drawing.Point(8, 37);
            this.lblReq.Name = "lblReq";
            this.lblReq.Size = new System.Drawing.Size(64, 14);
            this.lblReq.TabIndex = 5;
            this.lblReq.Text = "Request:";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHost.Location = new System.Drawing.Point(5, 11);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(81, 14);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "Host Name:";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(264, 424);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "&Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtAreaRequest
            // 
            this.txtAreaRequest.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAreaRequest.Location = new System.Drawing.Point(0, 56);
            this.txtAreaRequest.Multiline = true;
            this.txtAreaRequest.Name = "txtAreaRequest";
            this.txtAreaRequest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAreaRequest.Size = new System.Drawing.Size(504, 152);
            this.txtAreaRequest.TabIndex = 6;
            this.txtAreaRequest.WordWrap = false;
            // 
            // EPrinterDummy
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 15);
            this.ClientSize = new System.Drawing.Size(510, 455);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtAreaResponse);
            this.Controls.Add(this.lblRes);
            this.Controls.Add(this.lblReq);
            this.Controls.Add(this.lblRequest);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.txtAreaRequest);
            this.Controls.Add(this.cmbRequest);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtHost);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EPrinterDummy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Printer Terminal Dummy";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new EPrinterDummy());
		}

		private void cmbRequest_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbRequest.SelectedIndex == 0 )
			{
				txtAreaRequest.Text =  "Select a request type from the list.";
			}
			else
			{
				txtAreaRequest.Text = readXMLfile(cmbRequest.SelectedItem.ToString() + ".xml" );
			}
		}


		/// <summary>
		/// Reads data from the .xml file.
		/// </summary>
		/// <param name="strFileName">The XML file name.</param>
		/// <returns>The file data.</returns>
		private string readXMLfile(string strFileName)
		{
			StringBuilder strBuf = new StringBuilder();
			try
			{

				FileStream fs = new FileStream(strFileName,FileMode.Open,FileAccess.Read);
				StreamReader streamReader = new StreamReader(fs);

				string strLine = "";
				while ( ( strLine = streamReader.ReadLine()) != null)
				{
					strBuf.Append (strLine);
					strBuf.Append ("\r\n");
				}
			}
			catch(System.IO.FileNotFoundException fnfe)
			{
				strBuf.Append(fnfe.Message );
			}

			return strBuf.ToString ();
		}

		private void btnSend_Click(object sender, System.EventArgs e)
		{
			string strRequest = appendBoundaryToRequest(txtAreaRequest.Text);
			txtAreaResponse.Text = DoSocketPost(txtHost.Text, System.Int32.Parse(txtPort.Text), strRequest);
		}

		/// <summary>
		/// Adds starting and ending boundarty to the request.
		/// </summary>
		/// <param name="strRequestData">The XML request data.</param>
		/// <returns>Returns the request data with boundary appended.</returns>
		private string appendBoundaryToRequest(string strRequestData)
		{
				return "--" + BOUNDARY + "\r\n" + strRequestData + "--" + BOUNDARY + "--" + "\r\n";
		}

		/// <summary>
		/// Sends a POST request to the server.
		/// </summary>
		/// <param name="server"></param>
		/// <param name="portNo"></param>
		/// <param name="strFormData"></param>
		/// <returns></returns>
		public string DoSocketPost(string server, int portNo, string strFormData)
		{
			try
			{
				//Set up variables and String to write to the server
				Encoding ASCII = Encoding.ASCII;
				string Post = 

					"POST /eas/eas.aspx HTTP/1.0\r\n" +
					"Host: " + server + "\r\n" +
					"Content-type: multipart/form-data; charset=ISO-8859-1; boundary=" + BOUNDARY + "\r\n" +
					"Content-length: " + strFormData.Length + "\r\n" +  
					"Connection: close\r\n\r\n" +
					strFormData;

				Byte[] ByteGet = ASCII.GetBytes(Post);
				String strRetPage = null;
 
				// IPAddress and IPEndPoint represent the endpoint that will
				// receive the request.
				// Get first IPAddress in list return by DNS
				IPAddress hostadd = Dns.GetHostEntry(server).AddressList[0];
				IPEndPoint EPhost = new IPEndPoint(hostadd, portNo);
 
				//Create the Socket for sending data over TCP
				Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
					ProtocolType.Tcp );
 
				// Connect to host using IPEndPoint
				s.Connect(EPhost);
				if (!s.Connected)
				{
					strRetPage = "Unable to connect to host";
					return strRetPage;
				}
 
				// Sent the POST text to the host
				s.Send(ByteGet, ByteGet.Length, 0);
 
				// Receive the page, loop until all bytes are received
				// The server must tell the client in advance the size of the
				// file before the file download. It will enable the client
				// to reserve the buffer space for the file storage.
				Byte[] RecvBytes = new Byte[305212];
				Int32 bytes = 0;
				Int32 totalBytes = 0;
 
				do
				{
					bytes = s.Receive(RecvBytes, RecvBytes.Length, 0);
					totalBytes += bytes;
					strRetPage = strRetPage + ASCII.GetString(RecvBytes, 0, bytes);
				}
				while (bytes > 0);

				Console.WriteLine("No of bytes: " + totalBytes);

				bool bNewLineFlag = false;
				int i = 0;
				for ( i = 0 ; i < totalBytes; i++)
				{
					if ( RecvBytes[i] == '\r' )
					{

					}
					else if ( RecvBytes[i] == '\n' )
					{
						if ( bNewLineFlag)
							break;

						bNewLineFlag = true;		
					}
					else
					{
						bNewLineFlag = false;
					}

				}

				Console.WriteLine("i = "+ i);
				i++;
	
				// The file stream is written to the file.
				FileStream fs = new FileStream("response.txt", 
										FileMode.Create, 
										FileAccess.Write);

				BinaryWriter bw = new BinaryWriter(fs);
							bw.Write(RecvBytes, i, totalBytes - i);
							bw.Flush();
							bw.Close();
				
				return strRetPage;
			}
			catch (System.Net.Sockets.SocketException se)
			{
				return se.Message;
			}

		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			txtAreaRequest.Text ="";
			txtAreaResponse.Text = "";
			cmbRequest.SelectedIndex = 0;
		}
	}
}
