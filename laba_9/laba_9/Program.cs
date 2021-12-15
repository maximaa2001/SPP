using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_9
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicList<int> list = new DynamicList<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);
            foreach(int el in list)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine();
            list.Remove(20);
            foreach (int el in list)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
