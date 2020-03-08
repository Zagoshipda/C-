using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Synchronization01
{
    class Test
    {
        // shared static data
        static int count;
        public void ThreadProc()
        {
            for(int i=0; i<10; ++i)
            {
                ++count;
                Console.WriteLine($"Thread ID : {Thread.CurrentThread.GetHashCode()} / result : {count}");
            }

        }
    }

    class Synchronization01
    {
        static void Main(string[] args)
        {
            // without synchronization
            Test test = new Test();
            Thread th1 = new Thread(new ThreadStart(test.ThreadProc));
            Thread th2 = new Thread(new ThreadStart(test.ThreadProc));
            th1.Start();
            th2.Start();

        }
    }
}
