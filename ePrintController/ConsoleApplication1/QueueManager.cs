using System;
using System.Messaging;
using System.Collections;
using System.Threading;
using System.Xml;
using System.IO;


namespace EAppService
{
	/// <summary>
	/// Summary description for QueueManager.
	/// </summary>
	public class QueueManager
	{
		private string strQueueName = null;

		/// <summary>
		/// Connects to the queue name specified and sends the messsages
		/// in the binary format.
		/// </summary>
		/// <param name="strQueueName">The full queue path</param>
		public QueueManager(String strQueueName)
		{
			this.strQueueName = strQueueName;
		}
		
		/// <summary>
		/// Places a message with the specified label into the queue.
		/// </summary>
		/// <param name="strMessage">the message to be transmitted</param>
		/// <param name="strLabel">the message label</param>
		public void sendMessage(string strMessage, string strLabel)
		{
			try
			{
				MessageQueue myQueue = new MessageQueue(this.strQueueName);
				myQueue.Formatter = new BinaryMessageFormatter();
				myQueue.Send(strMessage, strLabel);
				EASDebug.LogException("Queue Manager:SendMessage() QName: "+ this.strQueueName +" Label:"+ strLabel);
				myQueue.Close();
			}
			catch(MessageQueueException mqe)
			{
				EASDebug.LogException("Queue Manager:SendMessage() "+ mqe.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void purgeMessages()
		{
			try
			{
				MessageQueue myQueue = new MessageQueue(this.strQueueName);
				myQueue.Purge();
				EASDebug.LogException("Queue Manager:PurgeMessages() QName: "+ this.strQueueName );
				myQueue.Close();
			}
			catch(MessageQueueException mqe)
			{
				EASDebug.LogException("Queue Manager:PurgeMessages() "+ mqe.Message);
			}
		}

	}
}
