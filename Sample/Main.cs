using System;

using System.Security.Cryptography.X509Certificates;

namespace Sample
{
    class StartUp{
        public static void Main()
        {
            System.Console.WriteLine("Choose Server or Client");
            string Config = Console.ReadLine();
            if (Config!="Server" && Config!="Client")
            {
                System.Console.WriteLine("Please Choose Client or Server Configuration");
                return;
            }
            else
            {
                if (Config=="Server")
                {
                    Sample.SimpleTcpSrvr.Srv();
                }

                if (Config == "Client")
                {
                    Sample.SimpleTcpClient.Client();
                }
            }

        }

    }
}
