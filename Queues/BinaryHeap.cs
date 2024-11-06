using System;

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
        public static void heapSort(object[] x) // Ascending
        {
            BinaryHeap h = new BinaryHeap(0);
            h.data = x;
            h.SIZE = x.Length;

            for (int k = h.size() - 1; k >= 0 ; k--)
            {
                h.reorderDown(k);
            }
            for (int k = h.size() - 1; k > 0; k--)
            {
                x[k] = h.dequeue();
            }
        }
        public object dequeue()
        {
            object e = peek();
            data[0] = data[--SIZE];
            data[SIZE] = null;

            if (SIZE > 1)
            {
                reorderDown(0);
            }
            return e;
        }
        public void enqueue(object e)
        {
            ensureCapacity();
            data[SIZE] = e;
            reorderUp(SIZE++);

        }
        public bool isEmpty()
        {
            return SIZE == 0;
        }
        public object peek()
        {
            if (SIZE > 0) return data[0];
            return data[0];
        }
        public int size()
        {
            return SIZE;
        }
        private void reorderDown(int k)
        {
            int child;
            while ((child = 2 * k + 1) < SIZE)
            {
                if (child + 1 < SIZE && isGreaterThan(child+1,child))
                {
                    child++;
                }
                if (!isGreaterThan(child,k))
                {
                    break;
                }

                swap(k,child);
                k = child;
            }
        }
        private void reorderUp(int k)
        {
            while (k > 0)
            {
                int parent = (k - 1) / 2;

                if (!isGreaterThan(k,parent))
                {
                    break;
                }

                swap(k,parent);
                k = parent;
            }
        }
        private void swap(int i, int j)
        {
            object t = data[i];
            data[i] = data[j];
            data[j] = t;
        }
        private bool isGreaterThan(int i, int j) // Max-Heap
        {
            return ((IComparable)data[i]).CompareTo(data[j]) > 0;
        }
        private bool isLesserThan(int i, int j) // Min-Heap
        {
            return ((IComparable)data[i]).CompareTo(data[j]) < 0;
        }
        private void ensureCapacity()
        {
            if (SIZE >= data.Length)
            {
                object[] tempdata = new object[2 * data.Length];
                Array.Copy(data, tempdata, SIZE); // คัดลอกข้อมูลไปยังอาร์เรย์ใหม่
                data = tempdata;
            }
        }
    }
}
