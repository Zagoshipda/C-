using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpNetworkStreamClient
{
    class TcpNetworkStreamClient
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TcpNetworkStreamClient\n");

            TcpClient tcpClient = new TcpClient("localhost", 7);
            NetworkStream stream = tcpClient.GetStream();

            Console.WriteLine("client...");
            const int size = 1024;
            byte[] buffer = new byte[size];
            byte[] sendMessage = Encoding.ASCII.GetBytes("hello world!");
            stream.Write(sendMessage, 0, sendMessage.Length);
            int totalCount = 0, readCount = 0;

            // echo server가 이미 되돌려 전송했지만 buffer 내부에 아직 머물러있을 경우를 고려하여 반복문을 통해 메세지 전체를 받을 수 있도록 조건을 추가해주어야 한다. data STREAM 의 특성을 고려하여 코드를 구성해야 한다.
            while(totalCount < sendMessage.Length)
            {
                readCount = stream.Read(buffer, 0, buffer.Length);
                totalCount += readCount;

                string receiveMessage = Encoding.ASCII.GetString(buffer);
                Console.WriteLine(receiveMessage);

            }
            Console.WriteLine($"received byte : {totalCount}");

            stream.Close();
            tcpClient.Close();

            Console.WriteLine("Press any key to terminate...");
            Console.ReadLine();

        }
    }
}
