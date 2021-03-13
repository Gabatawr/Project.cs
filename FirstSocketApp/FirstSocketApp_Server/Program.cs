using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstSocketApp_Server
{
    class Program
    {
        static List<Socket> clients = new();
        static void UpdateOnlineCounter()
        {
            int x = Console.CursorTop, y = Console.CursorLeft;
            Console.SetCursorPosition(8, 0);
            Console.Write(clients.Count.ToString().PadRight(3, ' '));
            Console.SetCursorPosition(y, x);
        }

        static void Message(string msg)
        {
            var d = DateTime.Now;
            Console.WriteLine(d.ToString("T") + ' ' + msg);
        }
        static void Connection(Socket client)
        {
            Message("New connect");
            clients.Add(client);
            UpdateOnlineCounter();
        }
        static void Disconnection(Socket client)
        {
            Message("Disconnect");
            clients.Remove(client);
            UpdateOnlineCounter();
        } 

        static void Main(string[] args)
        {
            Console.WriteLine("Online: 0\n");

            IPEndPoint eP = new(IPAddress.Parse("127.0.0.1"), 1337);
            Socket server = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(eP);
            server.Listen(10);
            try
            {
                CancellationTokenSource tSource = new();

                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        Socket c = server.Accept();
                        Connection(c);

                        Task.Factory.StartNew(() =>
                        {
                            StringBuilder sb = new();
                            var buff = new byte[1024];
                            int bytes = 0;

                            while (true)
                            {
                                while (c.Available == 0);

                                lock (block) bytes = c.Receive(buff);
                                sb.Append(Encoding.ASCII.GetString(buff, 0, bytes));

                                Message(sb.ToString());
                                sb.Clear();
                            }

                            Disconnection(c);
                        });
                    }
                }, tSource.Token);

                Console.ReadKey();
                tSource.Cancel();
            }
            catch (Exception) { }
            finally { server.Close(); }
        }
        static readonly object block = new();
    }
}
