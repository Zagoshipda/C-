using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkStreamServer
{
    class NetworkStreamServer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("NetworkStreamServer\n");

            // listener indicates that this program is a server.
            //TcpListener tcpListener = new TcpListener(7);   // constructor that only accepts the port number also exists -> this method has been deprecated.
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7);
            tcpListener.Start();

            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream stream = tcpClient.GetStream();

            // byte array for network stream between server and client.
            const int messageSize = 100;
            byte[] receiveMessage = new byte[messageSize];
            stream.Read(receiveMessage, 0, receiveMessage.Length);
            string strMessage = Encoding.ASCII.GetString(receiveMessage);
            Console.WriteLine($"received message : {strMessage}");

            string echoMessage = "Hello World...!";
            Console.WriteLine($"send message : {echoMessage}");
            byte[] sendMessage = Encoding.ASCII.GetBytes(echoMessage);
            stream.Write(sendMessage, 0, sendMessage.Length);

            stream.Close();
            tcpClient.Close();
            tcpListener.Stop();


            // custom practice
            //Console.Clear();    // clears the console buffer and corresponding console window of display information.
            DateTime dat = DateTime.Now;
            Console.WriteLine("\n\nToday is {0:d} at {0:T}.", dat);   // Today is 2020-03-07 at 오후 8:37:49
            Console.Write("\nPress any key to continue... ");
            Console.ReadLine();

        }
    }
}
