using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BinaryWrite01
{
    class BinaryWrite01
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BinaryWrite...!\n");

            TcpListener tcpListener = new TcpListener(IPAddress.Any, 3000);
            tcpListener.Start();

            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream ns = tcpClient.GetStream();
            using (BinaryWriter bw = new BinaryWriter(ns))
            {
                // write data
                bool yesNo = true;
                int num = 12;
                float pi = 3.14f;
                double dd = 2.71;
                string message = "good job...!";

                bw.Write(yesNo);
                bw.Write(num);
                bw.Write(pi);
                bw.Write(dd);
                bw.Write(message);
            }

            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();
        }
    }
}
