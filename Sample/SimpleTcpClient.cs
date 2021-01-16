using System;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using SenderReciever;
namespace Sample
{
    class SimpleTcpClient
    {
        public static void Client()
        {
            int sent;
            byte[] data = new byte[1024];
            string input, stringData;

            IPEndPoint ipep = new IPEndPoint(
                IPAddress.Parse("127.0.0.1"), 9050);

            Socket server = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            
            try
            {

                server.Connect(ipep);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Unable to connect to server.");
                Console.WriteLine(e.ToString());
                return;
            }

            data = SenderReciever.SendRecieve.RecieveData(server);
            
            stringData = Encoding.ASCII.GetString(data);
            Console.WriteLine(stringData);

            string message1 = "First Message Check";
            sent = SendRecieve.SendData(server, Encoding.ASCII.GetBytes(message1));

            while (true)
            {
                string Message = Console.ReadLine();
                SendRecieve.SendData(server, Encoding.ASCII.GetBytes(Message));

                if (Message == "exit")
                {
                    break;
                }
            } 
            Console.WriteLine("Disconnecting from server...");
            server.Shutdown((SocketShutdown.Both));
            server.Close();

        }

        
        
    }
}