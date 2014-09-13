using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using EAppService;

namespace JobQueueController
{
	/// <summary>
	/// Sends New Job Messages to the EPT.
	/// </summary>
	class TCPClient
	{
		/// <summary>
		/// Holds the name of the host.
		/// </summary>
		private string strServer = null;

		/// <summary>
		/// Holds the port no.
		/// </summary>
		private int iPortNo = 0;
        		
		/// <summary>
		/// the constructor of the class.
		/// </summary>
		/// <param name="strServer">The server name to connect to.</param>
		/// <param name="iPortNo">The Port No</param>
		public TCPClient(string strServer, int iPortNo)
		{
			this.strServer = strServer;
			this.iPortNo = iPortNo;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="strXMLMessage">The message to be sent.</param>
		/// <returns>The reply from the server.</returns>
		public string sendMessageToEPT(string strXMLMessage)
		{
			try
			{
				//Set up variables and String to write to the server
				Encoding ASCII = Encoding.ASCII;
				Byte[] byteData = ASCII.GetBytes(strXMLMessage);
				String strRetPage = null;
 
				// IPAddress and IPEndPoint represent the endpoint that will
				// receive the request.
				// Get first IPAddress in list return by DNS
				IPAddress hostAddr = Dns.Resolve(this.strServer).AddressList[0];
				IPEndPoint epHost = new IPEndPoint(hostAddr, this.iPortNo);
 
				//Create the Socket for sending data over TCP
				Socket sock 
				= new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
 				
				// Connect to host using IPEndPoint
				sock.Connect(epHost);

				if (!sock.Connected)
				{
					throw new Exception("Unable to establish connection with the server");
				}
 
				// Sent the POST text to the host
				sock.Send(byteData, byteData.Length, 0);
				EASDebug.LogException("Sent message to " + strServer + ":)" + strXMLMessage);

				Byte[] bRecvBytes = new Byte[1024];
				Int32 bytes = 0;
				Int32 totalBytes = 0;
 
				do
				{
					bytes = sock.Receive(bRecvBytes, bRecvBytes.Length, 0);
					totalBytes += bytes;
					strRetPage = strRetPage + ASCII.GetString(bRecvBytes, 0, bytes);
				}
				while (bytes > 0);
			
				EASDebug.LogException("No of bytes received: " + totalBytes);

				return strRetPage;
			}
			catch (System.Net.Sockets.SocketException se)
			{
				EASDebug.LogException("Exception Occurred: " + se.ToString() );
				throw se;
			}
		}

	}
}
