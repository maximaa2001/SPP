using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_9
{
    class DynamicList<T> : IEnumerable<T>
    {
        private T[] array;
   
        public DynamicList()
        {
            array = new T[0];
        }

        public int Count()
        {
            return array.Length;
        }

        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }

        public void Add(T element)
        {
            T[] current = array;
            array = new T[array.Length + 1];
            current.CopyTo(array, 0);
            array[array.Length - 1] = element;
        }

        public void Remove(T element)
        {
            int index = Array.IndexOf(array, element);
            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 || index < array.Length)
            {
                for (int i = index + 1; i < array.Length; i++)
                {
                    array[i - 1] = array[i];
                }
                T[] temp = array;
                array = new T[array.Length - 1];
                Array.Copy(temp, array, array.Length);
            }
            else
            {
                Console.WriteLine("Неверный индекс");
            }
        }

        public void Clear()
        {
            array = new T[array.Length];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }
    }
}
