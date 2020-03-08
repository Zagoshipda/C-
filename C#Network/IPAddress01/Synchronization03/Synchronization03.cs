using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Synchronization03
{
    class ThisLock
    {
        public void IncreaseCount(ref int count)
        {
            count++;
        }
    }

    class Test
    {
        ThisLock lockObject = new ThisLock();
        int count1 = 0;
        int count2 = 0;

        public void ThreadProc()
        {
            // 1. without synchronization
            for (int i = 0; i < 5; ++i)
            {
                //lockObject.IncreaseCount(count);
                lockObject.IncreaseCount(ref count1);
                Console.WriteLine($"1 ID : {Thread.CurrentThread.GetHashCode()} / result : {count1}");
            }

            // 2. synchronization by lock
            lock (lockObject)
            {
                for (int i = 0; i < 5; ++i)
                {
                    lockObject.IncreaseCount(ref count2);
                    Console.WriteLine($"2 ID : {Thread.CurrentThread.GetHashCode()} / result : {count2}");
                }
            }
        }
    }

    class Synchronization03
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Thread[] threads = new Thread[3];
            for(int i=0; i<3; ++i)
            {
                threads[i] = new Thread(new ThreadStart(test.ThreadProc)); 
            }
            for(int i=0; i<3; ++i)
            {
                threads[i].Start();
            }


        }
    }
}
