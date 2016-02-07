using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomQueue;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomQueue<object> queue = new CustomQueue<object>();
            queue.Enqueue("My name is Nataly");
            queue.Enqueue("Something else");
            queue.Enqueue(312);
            CustomQueue<object> queue2 = queue.Clone();
            CustomQueue<object> queue3 = queue;
            queue.Enqueue(new List<int>());
            queue.Enqueue(new DateTime());
            foreach (var variable in queue)
            {
                Console.WriteLine(variable);
            }
            Console.WriteLine('\n');
            foreach (var variable in queue2)
            {
                Console.WriteLine(variable);
            }
            Console.WriteLine('\n');
            foreach (var variable in queue3)
            {
                Console.WriteLine(variable);
            }
            Console.WriteLine('\n');
            Console.ReadLine();
        }
    }
}
