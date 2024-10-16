using System;
using Lists;

namespace Queues
{
    public class ArrayListQueue : Queue
    {
        private List list;
        public ArrayListQueue(int cap)
        {
            list = new Lists.ArrayList(cap);
        }
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
