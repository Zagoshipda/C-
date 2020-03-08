using System;
using System.Threading;

namespace Thread08
{
    class Thread08
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

            for(int i=0; i<10; ++i)
            {
                Console.Write($"{i} ");
                Thread.Sleep(200);

                if(i == 3)
                {
                    Console.WriteLine("ThreadProc1() terminate...");
                    try
                    {
                        // System.PlatformNotSupportedException : Thread abort is not supported on this platform ---> .NET Core only: This member is not supported.
                        // should make the console app based on .Net Framework, NOT based on .Net Core.
                        Thread.CurrentThread.Abort();
                    }
                    catch (ThreadAbortException e)
                    {
                        Console.WriteLine($"\nthis is NOT executed...! {e}\n");
                    }
                }
            }

        }

        static void ThreadProc2()
        {
            Console.WriteLine($"ThreadProc2 thread hashcode : {Thread.CurrentThread.GetHashCode()}");

            for(int i=0; i<10; ++i)
            {
                Console.Write($"{i*10} ");
                Thread.Sleep(200);
            }
            Console.WriteLine("ThreadProc2 terminate...");

        }
    }
}
