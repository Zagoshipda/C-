using System;
using System.Net;

namespace IPEndPoint01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IPAddress IPInfo = IPAddress.Parse("127.0.0.1");
            int Port = 13;
            IPEndPoint EndPointInfo = new IPEndPoint(IPInfo, Port);

            Console.WriteLine($"ip : {EndPointInfo.Address} / port : {EndPointInfo.Port}");     // ip : 127.0.0.1 / port : 13 
            Console.WriteLine(EndPointInfo.ToString());     // 127.0.0.1:13 주소와 포트번호에 대한 정보를 모두 출력
            Console.ReadKey();
        }
    }
}
