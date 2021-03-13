using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DemoChat_Server
{
    class Program
    {
        static void Main()
        {
            IPEndPoint eP = new(IPAddress.Parse("127.0.0.1"), 8081);
            Socket server = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(eP);
            server.Listen(1);
            Socket client = server.Accept();
            try
            {
                StringBuilder clientMsg = new();
                var buff = new byte[256];
                int bytes = 0;

                while (true)
                {
                    do
                    {
                        bytes = client.Receive(buff);
                        clientMsg.Append(Encoding.ASCII.GetString(buff, 0, bytes));
                    } while (client.Available > 0);

                    string Massege(Socket s, string msg)
                    {
                        var dtn = DateTime.Now;
                        return dtn.ToString("t")
                        + " from "
                        + $"[{s.LocalEndPoint}]"
                        + $" : {msg}";
                    }
                    
                    Console.WriteLine(Massege(client, clientMsg.ToString()));
                    clientMsg.Clear();

                    client.Send(Encoding.ASCII.GetBytes(Massege(client, "Message received")));
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
            finally
            {
                client.Close();
                server.Close();
            }
        }
    }
}
