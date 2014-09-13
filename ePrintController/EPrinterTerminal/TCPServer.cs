using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace EPTServer
{
	/// <summary>
	/// 
	/// </summary>
	class EPTTCPServer
	{
		private const int PORT_NO = 7777;
		
		EPTTCPServer()
		{
			try
			{
				Thread x = new Thread( new ThreadStart(this.Run));
				// Background threads do not prevent a process from terminating.
				// TODO: Set this to TRUE in production.
				x.IsBackground = false;
				x.Start();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.ToString() );
			}
		}

		private void Run()
		{
			while(true)
			{
				try
				{
					this.StartTCPServer();
				}
				catch(Exception e)
				{
					Console.WriteLine(e.ToString() );			
				}
			}
		}


		/// <summary>
		/// Starts the TCP Server which listens on a port...
		/// </summary>
		private void StartTCPServer()
		{
			TcpListener tcpListener = null;

			try
			{
				//Creates an instance of the TcpListener class by providing a local IP address and port number.
				IPAddress ipAddress = Dns.Resolve("localhost").AddressList[0];
				tcpListener = new TcpListener(ipAddress, PORT_NO);    
				tcpListener.Start();
				Console.Write("Waiting for requests...");

				// Accepts the pending client connection and returns a socket for communciation.
				Socket socket = null;

				while( (socket = tcpListener.AcceptSocket()) != null )
				{
					Console.WriteLine("Connection accepted...");
		
					// NOTE: The server will not accept more than 1MB of data.
					byte[] bData = new byte[1024];
					int iBytes = 0;
					string strCliReq = null;
										
					iBytes = socket.Receive(bData, bData.Length, 0);

					strCliReq = Encoding.ASCII.GetString(bData, 0, iBytes);
					Console.WriteLine("#" + strCliReq + "#");
					// Handle Check Printer Status and NWJ requests.
					// Log the requests and responses.

					string responseString = "<ServerResponse>" + strCliReq + "</ServerResponse>";
					//Forms and sends a response string to the connected client.
					Byte[] sendBytes = Encoding.ASCII.GetBytes(responseString);
					int i = socket.Send(sendBytes);
					socket.Close();
					Console.WriteLine("Message Sent to client: " + responseString);
					Console.Write("Waiting for requests...");
				}
	
			}
			catch (Exception err)
			{
				Console.WriteLine( err.ToString());

				if ( tcpListener != null)
				{
					tcpListener.Stop();
					tcpListener = null;
				}
				
				throw err;
			}

		}
		
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			new EPTTCPServer();
			Console.WriteLine("Main ended");
		}
	}
}
