using System;
using System.Net;
using System.Linq;
using System.Net.Sockets;

namespace FirstSocketApp_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress iP = IPAddress.Parse("127.0.0.1");
            IPEndPoint eP = new(iP, 1337);

            Socket s = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            s.Bind(eP);
            s.Listen(10);

            try
            {
                Socket s2 = s.Accept();
                Console.WriteLine("Connect");

                s2.Close();
                Console.ReadKey();
            }
            catch (Exception) { }
            finally { s.Close(); }
        }
    }
}
