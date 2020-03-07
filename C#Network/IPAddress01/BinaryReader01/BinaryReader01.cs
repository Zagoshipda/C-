using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BinaryReader01
{
    class BinaryReader01
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BinaryReader01...!\n");

            // read data
            bool yesNo;
            int num;
            float pi;
            double dd;
            string message;

            TcpClient tcpClient = new TcpClient("localhost", 3000);
            NetworkStream ns = tcpClient.GetStream();
            using (BinaryReader br = new BinaryReader(ns))
            {
                yesNo = br.ReadBoolean();
                num = br.ReadInt32();
                pi = br.ReadSingle();
                dd = br.ReadDouble();
                message = br.ReadString();
            }

            ns.Close();
            tcpClient.Close();

            Console.WriteLine(yesNo);
            Console.WriteLine(num);
            Console.WriteLine(pi);
            Console.WriteLine(dd);
            Console.WriteLine(message);

        }
    }
}
