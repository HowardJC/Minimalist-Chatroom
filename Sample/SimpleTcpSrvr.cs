using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using SenderReciever;
namespace Sample
{
    class SimpleTcpSrvr
    {
        public static void Srv()
        {
            int recv;
            
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any,
                9050);

            Socket newsock = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            newsock.Bind(ipep);
            newsock.Listen(10);
            Console.WriteLine("Waiting for a user");
            Socket client = newsock.Accept();
            IPEndPoint clientep = (IPEndPoint) client.RemoteEndPoint;
            Console.WriteLine("Connected with {0} at port {1}", clientep.Address, clientep.Port);
            string welcome = "Server is active";
            data = Encoding.ASCII.GetBytes(welcome);
            int sent = SendRecieve.SendData(client, data);
            while (true)
            {
                data = SendRecieve.RecieveData(client);
                Console.WriteLine(Encoding.ASCII.GetString(data));
                if (Encoding.ASCII.GetString(data) == "exit")
                {
                   
                    break;
                }
            }

            Console.WriteLine("Disconnected from {0}", clientep.Address);
            client.Close();
            newsock.Close();
        }
    }
}