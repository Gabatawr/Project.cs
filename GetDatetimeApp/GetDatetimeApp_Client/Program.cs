using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GetDatetimeApp_Client
{
    class Program
    {
        static void Main()
        {
            IPEndPoint eP = new(IPAddress.Parse("127.0.0.1"), 8081);
            Socket client = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                StringBuilder sb = new();
                var buff = new byte[256];
                int bytes = 0;

                client.Connect(eP);
                while (true)
                {
                    Console.Write("date/time/exit : ");
                    string msg = Console.ReadLine();

                    if (msg == "exit") break;
                    else if (msg == "date" || msg == "time")
                    {
                        client.Send(Encoding.ASCII.GetBytes(msg));
                        do
                        {
                            bytes = client.Receive(buff);
                            sb.Append(Encoding.ASCII.GetString(buff, 0, bytes));
                        } while (client.Available > 0);

                        Console.WriteLine(sb);
                        sb.Clear();
                    }
                    else Console.WriteLine("Invalid command..");
                    Console.WriteLine();
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
            finally { client.Close(); }

            Console.ReadKey();
        }
    }
}
