using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Synchronization02
{
    class Test
    {
        // object for synchronization. Used as a key for the critical section.
        static object obj = new object();
        static int count;

        public void ThreadProc()
        {
            lock (obj)
            { 
                // critical section
                for(int i=0; i<10; ++i)
                {
                    ++count;
                    Console.WriteLine($"Thread ID : {Thread.CurrentThread.GetHashCode()} / result : {count}");
                }
            }
        }
    }


    class Synchronization02
    {
        static void Main(string[] args)
        {
            // synchronization by lock
            Test test = new Test();
            Thread th1 = new Thread(new ThreadStart(test.ThreadProc));
            Thread th2 = new Thread(new ThreadStart(test.ThreadProc));
            th1.Start();
            th2.Start();

        }
    }
}
