using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace KeySpy_Client
{
    class Program
    {
        static Socket client = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static IPEndPoint iPEndPoint = new(IPAddress.Parse("127.0.0.1"), 1377);
        static void Main()
        {
            try {
                client.Connect(iPEndPoint);
                while (client.Connected)
                {
                    string s = Console.ReadLine();
                    client.Send(Encoding.ASCII.GetBytes(s));
                }
            }
            catch { }
            finally { client.Close(); }
        }
    }
}
