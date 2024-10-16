using System;
using Lists;
using LinkedLists;

namespace Queues
{
    public class LinkedListQueue : Queue
    {
        private List list = new DoublyLinked();
        public object dequeue()
        {
            throw new NotImplementedException();
        }

        public void enqueue(object e)
        {
            throw new NotImplementedException();
        }

        public bool isEmpty()
        {
            return list.isEmpty();
        }

        public object peek()
        {
            throw new NotImplementedException();
        }

        public int size()
        {
            return list.size();
        }
    }
}
