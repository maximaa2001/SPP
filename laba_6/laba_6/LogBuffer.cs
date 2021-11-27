using System.Collections.Concurrent;
using System.Threading;
using System.IO;

namespace laba_6
{
    class LogBuffer
    {
        private ConcurrentQueue<string> MagazineMessage;
        private ConcurrentQueue<string> Buffer;
        private int LimitBuffer;
        private System.Timers.Timer Timer;
        private StreamWriter StreamWriter;

        public LogBuffer(int LimitBuffer, int LimitTimer, string FilePath)
        {
            this.LimitBuffer = LimitBuffer;
            StreamWriter = new StreamWriter(FilePath, true);
            MagazineMessage = new ConcurrentQueue<string>();
            Buffer = new ConcurrentQueue<string>();
            Timer = new System.Timers.Timer(LimitTimer);
            Timer.Elapsed += TimerActivity;
            Timer.AutoReset = true;
            Timer.Enabled = true;
        }

        public void Add(string Item)
        {
            MagazineMessage.Enqueue(Item);
            Buffer.Enqueue(Item);
            if (Buffer.Count >= LimitBuffer)
            {
                SaveMessage();
            }
        }

        private void SaveMessage()
        {
            while(Buffer.TryDequeue(out var message))
            {
                StreamWriter.WriteLineAsync(message);
            }
        }

        private void TimerActivity(object obj, System.Timers.ElapsedEventArgs e)
        {
           if(Buffer.Count != 0)
            {
                SaveMessage();
            }
        }
        public void Close()
        {
            StreamWriter.Close();
        }
    }
}
