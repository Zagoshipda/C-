using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace StreamWriter01
{
    class StreamWriter01
    {
        static void Main(string[] args)
        {
            Console.WriteLine("StreamWriter01\n");

            TcpListener tcpListener = new TcpListener(IPAddress.Any, 3000);
            tcpListener.Start();
            TcpClient tcpClient = tcpListener.AcceptTcpClient();

            // data
            bool yesNo = false;
            int val1 = 12;
            float pi = 3.14f;
            string message = "nice work!";

            NetworkStream stream = tcpClient.GetStream();
            using(StreamWriter writer = new StreamWriter(stream))
            {
                writer.AutoFlush = true;    // whether to flush its buffer or not
                
                // pass data one by one.
                writer.WriteLine(yesNo);
                writer.WriteLine(val1);
                writer.WriteLine(pi);
                writer.WriteLine(message);
            }

            stream.Close();
            tcpClient.Close();
            tcpListener.Stop();

            Console.WriteLine("Press any key to terminate... ");
            Console.ReadLine();

        }
    }
}
