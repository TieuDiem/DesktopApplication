using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WEEK_6
{
    class Program
    {
        static Thread ClientMonitor;
		static CommInterface commSequence;
		private static string ipAdress = "127.0.0.1";
		private static int port = 8000;
		const int BUFLEN = 255;

		static Thread SendPLC;
		static void Main(string[] args)
        {
			commSequence = new CommInterface(ipAdress, port);
			ClientMonitor = new Thread(new ThreadStart(ClientMonitorSequence));
			ClientMonitor.Start();

			SendPLC = new Thread(new ThreadStart(() =>
			{
                while (true)
                {
					Console.WriteLine("Client >>>> PLC(Server):");
					string dataSend = Console.ReadLine();
					commSequence.WriteData(MakeDataSend(dataSend));
				}
			}));
			SendPLC.Start();
		}
		static byte[] MakeDataSend(string stringValue) 
		{
			byte[] data = new byte[BUFLEN];
			int headerSize = 0;
			for (int i = 0; i < stringValue.Length; i++)
			{
				data[headerSize++] = (byte)stringValue[i];

			}
			return data;
		}
        static void ClientMonitorSequence()
        {
            byte[] recvBuf = new byte[255];
			int nResult;
			while (true)
			{
				commSequence.Connect();
				if (commSequence.isConnected)
				{
					// State isConected = True
					Console.WriteLine("... Connect Sucessfull ...");
				}
				else
				{
					Console.WriteLine("... Can't Connnect ...");
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
						
					Console.WriteLine($"PLC (Server) >>>> Client : {dataReceive}");
					Array.Clear(recvBuf, 0, BUFLEN);
				}
				else if (nResult == 0)
				{
					//Connection closed by Controller
				}
			}
		}
    }
}
