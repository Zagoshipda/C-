using System;
using System.Net;

namespace IPHostEntry01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IPHostEntry HostInfo = Dns.GetHostEntry("www.naver.com");
            foreach(IPAddress ip in HostInfo.AddressList)
            {
                Console.WriteLine($"{ip}");
            }
            // 210.89.160.88
            // 125.209.222.142

            Console.WriteLine($"{HostInfo.HostName}");  // www.naver.com.nheos.com


        }
    }
}
