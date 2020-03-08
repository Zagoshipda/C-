using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Thread08_2
{
    class Thread08_2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Thread08...!\n");

            // foreground thread
            Thread th = new Thread(new ThreadStart(ThreadProc1));
            th.Start();

            Console.WriteLine($"Main Thread hashcode : {Thread.CurrentThread.GetHashCode()}");
            Console.WriteLine("Main Thread terminate...");

        }

        private static void ThreadProc1()
        {
            Console.WriteLine($"ThreadProc1 Thread hashcode : {Thread.CurrentThread.GetHashCode()}");
            // nested foreground thread
            Thread th = new Thread(new ThreadStart(ThreadProc2));
            th.Start();

            for (int i = 0; i < 10; ++i)
            {
                Console.Write($"{i} ");
                Thread.Sleep(200);

                if (i == 4)
                {
                    Console.WriteLine("ThreadProc1 terminate...");
                    Thread.CurrentThread.Abort();
                    Console.WriteLine($"this is NOT executed...!\n");
                }
            }

        }

        static void ThreadProc2()
        {
            Console.WriteLine($"ThreadProc2 thread hashcode : {Thread.CurrentThread.GetHashCode()}");

            for (int i = 0; i < 10; ++i)
            {
                Console.Write($"{i * 10} ");
                Thread.Sleep(200);
            }
            Console.WriteLine("ThreadProc2 terminate...");

        }
    }
}
