using System;
using System.Net.Sockets;
using System.Text;

namespace SenderReciever
{
    public class SendRecieve
    {
        public static int SendData(Socket s, byte[] data)
        {
            int total = 0;
            int size = data.Length;
            int dataleft = size;
            int sent;
            byte[] datasize = new byte[4];
            datasize = BitConverter.GetBytes(size);
            s.Send(datasize);


            s.Send(data, total, dataleft, SocketFlags.None);

            return total;
        }

        public static byte[] RecieveData(Socket s)
        {
            int total = 0;
            int recv;
            byte[] datasize = new byte[4];

            s.Receive(datasize, 0, 4, 0);
            int size = BitConverter.ToInt32(datasize, 0);
            int dataleft = size;
            byte[] data = new byte[size];
            
            recv = s.Receive(data, total, dataleft, 0);
            if (recv == 0)
            {
                data = Encoding.ASCII.GetBytes("exit");
                    
                    
            }
                
                


            return data;
        }
    }
}