using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueue
{
    public class CustomQueue<T> : IEnumerable<T>, ICloneable where T : class
    {
        private T[] queue;
        private int capacity, head, tail;
        private static int defaultCapacity = 8;

       
        public CustomQueue() : this(defaultCapacity) { }

        public CustomQueue(int n)
        {
            if (n > 0)
            {
                queue = new T[n];
                capacity = n;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
            head = 0;
            tail = 0;
        }

        public CustomQueue(params T[] arr)
            : this(arr.Length)
        {
            Array.Copy(arr, queue, capacity);
            tail = capacity - 1;
        }
        

        public void Enqueue(T element)
        {
            if ((tail + 1) % capacity == head % capacity)
            {
                T[] wideQueue = new T[capacity * 2];

                for (int i = head, j = 0; j < capacity; j++)
                {
                    wideQueue[j] = queue[i];
                    i = ++i % capacity;
                }
                wideQueue[capacity] = element;
                tail = capacity;
                head = 0;
                capacity *= 2;
                queue = wideQueue;
            }
            else
            {
                queue[++tail % capacity] = element;
                tail = tail % capacity;
            }

        }


        public T Dequeue()
        {
            if (IsEmpty())
            {
                T returnValue = Peek();
                DeleteHead();
                return returnValue;
            }
            else
                throw new ArgumentException();
        }

        public T Peek()
        {
            if (IsEmpty())
                return queue[head];
            else
                throw new ArgumentException();
        }

        public void Clear()
        {
            for (int i = head, j = 0; j < capacity; j++)
            {
                queue[i] = null;
                i = ++i % capacity;
            }
            head = tail = 0;
        }

        public bool Contain(T str)
        {
            foreach (var variable in queue)
            {
                if (variable == str)
                    return true;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueIterator<T>(queue, tail, head);
        }

        public CustomQueue<T> Clone()
        {
            return new CustomQueue<T>(queue);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        private void DeleteHead()
        {
            queue[head] = null;
            head = ++head % capacity;
        }

        private bool IsEmpty()
        {
            if (tail % capacity == head % capacity)
                return false;
            else
                return true;
        }
    }
}
