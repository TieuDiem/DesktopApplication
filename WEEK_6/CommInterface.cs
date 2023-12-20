using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WEEK_6
{
    class CommInterface
    {
        TcpClient tcpClient;
        public bool isConnected;
        private string ipAdress;
        private Stream stream;
        private int port;
        object senddata = new object();
        object readdata = new object();
        public CommInterface(string _ipAdress, int _port)
        {
            ipAdress = _ipAdress;
            port = _port;
        }
        public bool Connect()
        {
            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(ipAdress, port);
                stream = tcpClient.GetStream();
                isConnected = true;
                return true;
            }
            catch (Exception ex)
            {
                isConnected = false;
                stream = null;
                return false;
            }
        }
        public void CloseSocket()
        {
            try
            {
                stream.Dispose();
                stream = null;
                tcpClient.Close();
                tcpClient.Dispose();
            }
            catch { }
        }
        public int ReadData(ref byte[] data)
        {
            lock (readdata)
            {
                try
                {
                    if (stream != null && tcpClient.Connected)
                    {
                        byte[] buff = new byte[1024];
                        int length = stream.Read(buff, 0, 1024);
                        Array.Copy(buff, 0, data, 0, length);
                        string txtdebug = string.Format($"Port: {port}");
                        for (int i = 0; i < length; i++)
                        {
                            txtdebug += buff[i].ToString();// Logger TCP Client read Data
                        }
                        // Recevice Sucessfull ...
                        return length;
                    }
                    else
                    {
                        // Disconect
                    }
                }
                catch
                {
                    // Disconect
                }
                try
                {
                    if (stream != null)
                    {
                        stream.Dispose();
                        stream = null;
                        tcpClient.Close();
                        tcpClient.Dispose();
                    }
                }
                catch 
                { 
                    // Can't Close Stream 
                }
                return -1;
            }
        }
        public bool WriteData(byte[] buff)
        {
            lock (senddata)
            {
                try
                {
                    if (stream != null && tcpClient.Connected)
                    {
                        stream.Write(buff, 0, buff.Length);

                        string txtdebug = string.Format($"Port: {port}");
                        for (int i = 0; i < buff.Length; i++)
                        {
                            txtdebug += buff[i].ToString(); // Logger TCP Client send
                        }
                        return true;
                    }
                    else
                    {
                    }
                }
                catch
                {
                }
                try
                {
                    if (stream != null)
                    {
                        stream.Dispose();
                        stream = null;
                        tcpClient.Close();
                        tcpClient.Dispose();
                    }
                }
                catch { }
                return false;
            }
        }
    }
}
