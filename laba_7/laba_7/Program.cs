using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace laba_7
{
    delegate void Task();
    class Program
    {
        static void Main(string[] args)
        {
            Task[] Tasks = new Task[3];
            Tasks[0] = Task_1;
            Tasks[1] = Task_2;
            Tasks[2] = Task_3;

            Parallel.WaitAll(Tasks);
            Console.WriteLine("Main ended");
            Console.ReadLine();
        }

        public static void Task_1()
        {
            for(int i = 0; i < 20; i++)
            {
                Console.WriteLine("Thread:" + Thread.CurrentThread.ManagedThreadId + "   " + i);
            }
        }

        public static void Task_2()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Thread:" + Thread.CurrentThread.ManagedThreadId + "   " + i);
            }
        }

        public static void Task_3()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Thread:" + Thread.CurrentThread.ManagedThreadId + "   " + i);
            }
        }
    }
}
