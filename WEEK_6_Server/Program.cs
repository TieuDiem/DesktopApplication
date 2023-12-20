using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace WEEK_6_Server
{
    class Program
    {
        static Thread ServerMonitor;
        static CommInterface commSequence;
		public static int BUFFER_SIZE = 255;


		static Thread SendPLC;
        static void Main(string[] args)
        {
            commSequence = new CommInterface("127.0.0.1", 9000);
            ServerMonitor = new Thread(new ThreadStart(ServerMonitorSequence));
            ServerMonitor.Start();

            SendPLC = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    Console.WriteLine("Server >>>> PLC(Client):");
					string dataSend = Console.ReadLine();
					commSequence.WriteData(MakeDataSend(dataSend));
                }
            }));
			SendPLC.Start();
		}
		static byte[] MakeDataSend(string stringValue)
		{
			byte[] data = new byte[BUFFER_SIZE];
			int headerSize = 0;
			for (int i = 0; i < stringValue.Length; i++)
			{
				data[headerSize++] = (byte)stringValue[i];

			}
			return data;
		}
		static void ServerMonitorSequence()
		{
			byte[] recvBuf = new byte[255];
			int nResult;
			while (true)
			{
				
				if (commSequence.isConnected)
				{
					// State isConected = True

				}
				else
				{
					//Console.WriteLine("... Can't Connnect ...");
					// State isConected = False
					continue;
				}

				recvBuf = new byte[255];
				nResult = commSequence.ReadData(ref recvBuf);
				if (nResult > 0)
				{
					Thread.Sleep(5);
					int headerLength = 100;
					string dataReceive = "";
					for (int i = 0; i < headerLength; i++)
					{
						dataReceive += Convert.ToChar(recvBuf[i]);
					}

					Console.WriteLine($"PLC (Client) >>>> Server : {dataReceive}");
					Array.Clear(recvBuf, 0, BUFFER_SIZE);
				}
				else if (nResult == 0)
				{
					//Connection closed by Controller
				}
			}
		}
    }
}
