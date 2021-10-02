using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadPool
{
    class TaskQueue
    {
        private Queue<Thread> threadPool;
        private TaskDelegate taskDelegate;

        public TaskQueue(int count)
        {
            threadPool = new Queue<Thread>();
            InitPool(count);
        }

        private void InitPool(int count)
        {
            for(int i = 0; i < count; i++)
            {
                Thread thread = new Thread(Process);
                thread.Name = $"Thread {i}";
                thread.Start();
                threadPool.Enqueue(thread);
            }
        }

        public void EnqueueTask(TaskDelegate task)
        {
            lock (this)
            {
                taskDelegate += task;
            }
        }

        private void Process()
        {
            while (true)
            {
                lock (this)
                {
                    if (taskDelegate != null)
                    {
                        taskDelegate();
                        taskDelegate = null;
                    }
                }
            }
        }
    }
}
