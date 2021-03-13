using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DemoChat_Client
{
    class Program
    {
        static void Main()
        {
            IPEndPoint eP = new(IPAddress.Parse("127.0.0.1"), 8081);
            Socket client = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                StringBuilder serverMsg = new();
                var buff = new byte[256];
                int bytes = 0;

                client.Connect(eP);
                while (true)
                {
                    Console.Write("Message : ");
                    string msg = Console.ReadLine();

                    if (string.IsNullOrEmpty(msg) is false)
                    {
                        client.Send(Encoding.ASCII.GetBytes(msg));
                        do
                        {
                            bytes = client.Receive(buff);
                            serverMsg.Append(Encoding.ASCII.GetString(buff, 0, bytes));
                        } while (client.Available > 0);

                        Console.WriteLine(serverMsg);
                        serverMsg.Clear();
                    }
                    else Console.WriteLine("Massage empty..");
                    Console.WriteLine();
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
            finally { client.Close(); }

            Console.ReadKey();
        }
    }
}

