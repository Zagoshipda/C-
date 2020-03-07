using System;
using System.Net;

namespace IPAddress01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string Address = Console.ReadLine();
            IPAddress IP = IPAddress.Parse(Address);
            Console.WriteLine($"ip : {IP.ToString()}");

        }
    }
}
