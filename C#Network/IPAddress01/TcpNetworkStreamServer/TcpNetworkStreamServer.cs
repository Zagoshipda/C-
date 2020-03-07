using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpNetworkStreamServer
{
    class TcpNetworkStreamServer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TcpNetworkStreamServer\n");

            TcpListener tcpListener = new TcpListener(IPAddress.Any, 7);
            tcpListener.Start();

            const int size = 1024;
            byte[] buffer = new byte[size];
            int totalByteCount = 0, readByteCount = 0;

            Console.WriteLine("Echo server example...");

            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream stream = tcpClient.GetStream();

            while (true)
            {
                readByteCount = stream.Read(buffer, 0, buffer.Length);
                if(readByteCount == 0)
                {
                    break;
                }
                totalByteCount += readByteCount;
                stream.Write(buffer, 0, readByteCount); // echo server : send back the same thing
                Console.WriteLine(Encoding.ASCII.GetString(buffer));
            }

            stream.Close();
            tcpClient.Close();
            tcpListener.Stop();

            Console.WriteLine("Press any key to terminate...");
            Console.ReadLine();

        }
    }
}
