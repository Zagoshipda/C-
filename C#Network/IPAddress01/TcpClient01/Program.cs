using System;
using System.Net;
using System.Net.Sockets;

namespace TcpClient01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string ip = "192.168.219.103";
            int port = 7;
            TcpClient tcpClient = new TcpClient(ip, port);
            if (tcpClient.Connected)
            {
                Console.WriteLine("connected");
            }
            else
            {
                Console.WriteLine("Failed");
            }

            tcpClient.Close();
            Console.ReadKey();
        }
    }
}
