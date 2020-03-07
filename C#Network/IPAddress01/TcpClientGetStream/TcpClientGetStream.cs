using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpClientGetStream
{
    class TcpClientGetStream
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TcpClientGetStream\n");

            TcpClient tcpClient = new TcpClient("127.0.0.1", 7);

            if (tcpClient.Connected)
            {
                Console.WriteLine("server connected...");
                NetworkStream stream = tcpClient.GetStream();
                string message = "bye world...?";
                byte[] sendMessage = Encoding.ASCII.GetBytes(message);
                stream.Write(sendMessage, 0, sendMessage.Length);

                const int size = 100;
                byte[] receiveMessage = new byte[size];
                stream.Read(receiveMessage, 0, receiveMessage.Length);
                string strMessage = Encoding.ASCII.GetString(receiveMessage);
                Console.WriteLine(strMessage);
                stream.Close();

            }
            else
            {
                Console.WriteLine("Failed connection...");
            }

            tcpClient.Close();
            Console.WriteLine("\nPress any key to terminate...");
            Console.ReadLine();


        }
    }
}
