using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace StreamRead
{
    class StreamRead
    {
        static void Main(string[] args)
        {
            Console.WriteLine("StreamRead\n");

            const int size = 100;
            char[] buffer = new char[size];

            TcpClient tcpClient = new TcpClient("localhost", 3000);
            NetworkStream stream = tcpClient.GetStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                string str = reader.ReadLine();
                Console.WriteLine(str);
                str = reader.ReadLine();
                Console.WriteLine(str);
                str = reader.ReadLine();
                Console.WriteLine(str);
                str = reader.ReadLine();
                Console.WriteLine(str);
            }

            stream.Close();
            tcpClient.Close();


        }
    }
}
