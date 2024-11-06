using System;
using LinkedLists;
using Lists;

namespace Queues
{
    public class LinkedListPriorityQueue : PriorityQueue
    {
        private List list = new DoublyLinked();
        public object dequeue()
        {
            int i = HighestPriority();
            object e = list.get(i);
            list.remove(i);
            return e;
        }

        public void enqueue(object e)
        {
            list.add(e);
        }

        public bool isEmpty()
        {
            return list.isEmpty();
        }

        public object peek()
        {
            return list.get(HighestPriority());
        }

        public int size()
        {
            return list.size();
        }
        private int HighestPriority()
        {
            int j = 0;
            for (int i = 1; i < list.size(); i++)
            {
                IComparable I = (IComparable)list.get(i);
                if (I.CompareTo(list.get(j)) > 0) j = i;
            }
            return j;
        }
    }
}