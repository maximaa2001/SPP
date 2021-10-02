using System;
using System.Threading;

namespace ThreadPool
{
    delegate void TaskDelegate();

    class Program
    {
        static void Main(string[] args)
        {
            TaskQueue taskQueue = new TaskQueue(10);

            taskQueue.EnqueueTask(TaskOne);
            Thread.Sleep(100);

            taskQueue.EnqueueTask(TaskTwo);
            Thread.Sleep(100);

            taskQueue.EnqueueTask(TaskThree);
            Thread.Sleep(100);

            taskQueue.EnqueueTask(TaskOne);
            Thread.Sleep(100);

            taskQueue.EnqueueTask(TaskTwo);
            Thread.Sleep(100);

            taskQueue.EnqueueTask(TaskThree);
            Thread.Sleep(100);

            taskQueue.EnqueueTask(TaskOne);
            Thread.Sleep(100);

            taskQueue.EnqueueTask(TaskTwo);
            Thread.Sleep(100);

            taskQueue.EnqueueTask(TaskThree);
            Thread.Sleep(100);

            Console.ReadLine();
        }

        private static void TaskOne()
        {
            Console.WriteLine($"TaskOne {Thread.CurrentThread.Name}");
        }
        private static void TaskTwo()
        {
            Console.WriteLine($"TaskTwo {Thread.CurrentThread.Name}");
        }
        private static void TaskThree()
        {
            Console.WriteLine($"TaskThree {Thread.CurrentThread.Name}");
        }
    }
}
