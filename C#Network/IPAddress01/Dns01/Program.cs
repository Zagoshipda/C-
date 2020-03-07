using System;
using System.Net;

namespace Dns01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IPAddress[] IP = Dns.GetHostAddresses("www.naver.com");
            foreach(IPAddress HostIP in IP)
            {
                Console.WriteLine($"{HostIP}");
            }
            // 125.209.222.142
            // 125.209.222.141

            // 210.89.164.90
            // 210.89.160.88




            // Custom practice

            Console.WriteLine(Dns.GetHostName());   // breaker-pc
            // GetHostByName is obsoleted fot this type, please use GetHostEntry instead.
            IPHostEntry host1 = Dns.GetHostByName(Dns.GetHostName());
            string myip1 = host1.AddressList[0].ToString();
            Console.WriteLine(myip1);

            IPHostEntry host2 = Dns.GetHostEntry(Dns.GetHostName());
            string myip2 = host2.AddressList[0].ToString();
            Console.WriteLine(myip2);



        }
    }
}
