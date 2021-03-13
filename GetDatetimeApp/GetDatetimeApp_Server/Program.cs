using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GetDatetimeApp_Server
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
                StringBuilder sb = new();
                var buff = new byte[256];
                int bytes = 0;

                while (true)
                {
                    do
                    {
                        bytes = client.Receive(buff);
                        sb.Append(Encoding.ASCII.GetString(buff, 0, bytes));
                    } while (client.Available > 0);

                    var dtn = DateTime.Now;
                    string response = sb.ToString() switch
                    {
                        "date" => dtn.ToString("D"),
                        "time" => dtn.ToString("T"),
                        _ => string.Empty
                    };
                    sb.Clear();

                    if (string.IsNullOrEmpty(response) is false)
                    {
                        client.Send(Encoding.ASCII.GetBytes(response));
                        Console.WriteLine("Send : " + response);
                    }
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
