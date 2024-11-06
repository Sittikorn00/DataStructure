using System;

namespace Queues
{
    public class BinaryMinHeap : BinaryHeap
    {
        private object[] data;
        private int SIZE;
        private int cap;
        public BinaryMinHeap(int cap) : base(cap) { } // เรียกใช้ตัวสร้างของ BinaryHeap

        private bool isLesserThan(int i, int j) // Min-Heap
        {
            return ((IComparable)data[i]).CompareTo(data[j]) < 0;
        }
    }
}