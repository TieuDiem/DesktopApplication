using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WEEK_6_Server
{
    class CommInterface
    {
        public bool isConnected;
        private string ipAdress;
        Socket socket;
        private int port;
        TcpListener listener;

        object senddata = new object();
        object readdata = new object();

        public const int BUFFER_SIZE = 255;

        static ASCIIEncoding encoding = new ASCIIEncoding();
        public CommInterface(string _ipAdress, int _port)
        {
            ipAdress = _ipAdress;
            port = _port;

            IPAddress address = IPAddress.Parse(ipAdress);
            listener = new TcpListener(address, port);
            listener.Start();
            Console.WriteLine("Server started on " + listener.LocalEndpoint);
            Console.WriteLine("Waiting for a connection...");
            isListen();
        }

        public bool isListen()
        {
            socket = listener.AcceptSocket();
            if (socket.Connected)
            {
                Console.WriteLine("... Connect Sucessfull ...");
                isConnected = true;
                return true;
            }
            Console.WriteLine("... Can't Connect ...");
            isConnected = false;
            return false;
        }

        public void CloseSever()
        {
            try
            {
                socket.Dispose();
                socket.Close();
                listener.Stop();
            }
            catch { }
        }
        public int ReadData(ref byte [] recvBuf)
        {
            lock (readdata)
            {
                try
                {
                    if (socket.Connected) {
                        socket.Receive(recvBuf);
                        string str = encoding.GetString(recvBuf);
                        return recvBuf.Length;
                    }
                }
                catch (Exception)
                {
                    CloseSever();
                }
            }
            return -1;
        }
        public void WriteData(byte [] buff)
        {
            lock (senddata)
            {
                try
                {
                    if (socket.Connected)
                    {
                        socket.Send(buff);
                    }
                }
                catch (Exception)
                {
                    CloseSever();
                }
            }
        }
    }
}
