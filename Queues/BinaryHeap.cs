using System;
using System.Collections.Generic;

namespace Queues
{
    public class BinaryHeap : PriorityQueue
    {
        private object[] data;
        private int SIZE;
        private int cap;

        public BinaryHeap(int cap)
        {
            data = new object[cap];
            this.cap = cap;
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
            return SIZE == 0;
        }

        public object peek()
        {
            throw new NotImplementedException();
        }

        public int size()
        {
            return SIZE;
        }
        private void reorderDown(int k)
        {

        }
        private void reorderUp(int k)
        {

        }
        private void swap(int i, int j)
        {

        }
        private bool isGreaterThan(int i, int j)
        {
            return (i > j);
        }
        private void ensureCapacity()
        {

        }
    }
}
