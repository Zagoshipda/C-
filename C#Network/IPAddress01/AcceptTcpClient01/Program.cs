using System;
using System.Net;
using System.Net.Sockets;

namespace AcceptTcpClient01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TcpListener tcpListener = new TcpListener(IPAddress.Parse("192.168.219.103"), 7);
            tcpListener.Start();

            Console.WriteLine("Start");
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            Console.WriteLine("Finish");

            tcpClient.Close();
            tcpListener.Stop();
        }
    }
}
