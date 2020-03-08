using System;
using System.Threading;

namespace Thread01
{
    class Test
    {
        public void Print()
        {
            Console.WriteLine("Test!");
        }
    }

    class Thread01
    {
        static void Func()
        {
            Console.WriteLine("thread call");
        }

        // upcasting parameter (object type)
        static void ParameterizedFunc1(object obj)
        {
            // downcasting argument into int type
            for(int i=0; i<(int)obj; ++i)
            {
                Console.WriteLine($"parameterized <1> thred call {i}");
            }
        }
        static void ParameterizedFunc2(object obj)
        {
            // downcasting argument into int type
            for (int i = 0; i < (int)obj; ++i)
            {
                Console.WriteLine($"parameterized <2> thred call {i}");
            }
        }
        static void ParameterizedFunc3(object obj)
        {
            // downcasting argument into int type
            for (int i = 0; i < (int)obj; ++i)
            {
                Console.WriteLine($"parameterized <3> thred call {i}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Thread01...!\n");

            //ThreadStart thStart = new ThreadStart(Func);
            //Thread th = new Thread(thStart);
            Thread th = new Thread(new ThreadStart(Func));
            th.Start();
            // thread call : thread 자체는 지정해준 함수를 독립적으로 1번만 실행한다.
            // 쓰레드를 반복해주기 위해서는 함수 내부를 반복문을 통해 처리해주어야 한다.

            Thread th2 = new Thread(new ParameterizedThreadStart(ParameterizedFunc1));
            th2.Start(5);
            //parameterized <1> thred call 0
            //parameterized <1> thred call 1
            //parameterized <1> thred call 2
            //parameterized <1> thred call 3
            //parameterized <1> thred call 4

            // passing instance method
            Test test1 = new Test();
            Test test2 = new Test();
            Thread th3 = new Thread(new ThreadStart(test1.Print));
            Thread th4 = new Thread(new ThreadStart(test2.Print));
            th3.Start();
            th4.Start();

            Thread th5 = new Thread(new ParameterizedThreadStart(ParameterizedFunc1));
            Thread th6 = new Thread(new ParameterizedThreadStart(ParameterizedFunc2));
            Thread th7 = new Thread(new ParameterizedThreadStart(ParameterizedFunc3));
            th5.Start(5);
            th6.Start(5);
            th7.Start(5);

            Console.WriteLine("Main terminate...");

        }
    }
}
