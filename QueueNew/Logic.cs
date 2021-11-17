using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueNew
{
    class Logic
    {
        public Logic()
        {

        }
        public void Add(int value)
        {
            queue.Enqueue(value);
        }
        public string Delete(int amount)
        {
            if (amount <= 0)
                return "The amount of items you delete have to be greater than 0";
            else if (amount > queue.Count())
                return "Error: You're trying to delete numbers that aren't in the queue";
            else
            {
                for (int i = 0; i < amount; i++)
                {
                    queue.Dequeue();
                }
                return "Items deleted";
            }
        }
        public int Amount()
        {
            return queue.Count();
        }
        public string Max()
        {
            if (queue.Count() == 0)
                return "The queue is empty";
            else
                return $"The biggest number in the queue is {queue.Max()}";
        }
        public string Min()
        {
            if (queue.Count() == 0)
                return "The queue is empty";
            else
                return $"The smallest number in the queue is {queue.Min()}";
        }
        public string Find(int value)
        {
            if (queue.Contains(value))
                return value + " was found";
            else return value + " could not be found";
        }
        public Queue<int> PrintAll()
        {
            return queue;
        }
        private Queue<int> queue = new Queue<int>();
    }
}
