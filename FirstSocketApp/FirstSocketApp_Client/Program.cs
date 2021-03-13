using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FirstSocketApp_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint eP = new(IPAddress.Parse("127.0.0.1"), 1337);
            Socket client = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            try
            {
                client.Connect(eP);
                Console.WriteLine("Connected: " + client.Connected);

                string msg = string.Empty;
                while (client.Connected)
                {
                    msg = Console.ReadLine();
                    if (msg == "/exit") break;

                    client.Send(Encoding.ASCII.GetBytes(msg));
                }

                Console.ReadKey();
                {
                    client.Close();
                    Console.WriteLine("Connected: " + client.Connected);
                }
                Console.ReadKey();
            }
            catch (Exception) { }
        }
    }
}
