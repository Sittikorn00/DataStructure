using System;
using Lists;

namespace LinkedLists
{
    public class SinglyLinked : List
    {
        private class LinkedNode
        {
            public object e;
            public LinkedNode next;

            public LinkedNode(object e, LinkedNode next)
            {
                this.e = e;
                this.next = next;
            }
        }

        private LinkedNode first = new LinkedNode(null, null);
        private int SIZE;

        public void add(int index, object e)
        {
            if (index < SIZE)
            {
                LinkedNode node = nodeAt(index - 1);
                node.next = new LinkedNode(e, node.next);
                SIZE++;
            }
        }

        public void add(object e)
        {
            add(SIZE, e);
        }

        public bool contains(object e)
        {
            return indexOf(e) != -1;
        }

        public int indexOf(object e)
        {
            LinkedNode node = first.next; // เริ่มต้นที่โหนดแรก
            for (int i = 0; i < SIZE; i++)
            {
                if ((e == null && node.e == null) || (e != null && e.Equals(node.e)))
                {
                    return i; // หากพบค่า ให้ส่งคืน index
                }
                node = node.next; // ไปยังโหนดถัดไป
            }
            return -1; // หากไม่พบ ให้คืนค่า -1 (Header)
        }

        public bool isEmpty()
        {
            return first.next == null;
        }

        public void remove(int index)
        {
            LinkedNode node = nodeAt(index - 1);
            removeAfter(node);
        }

        public void remove(object e)
        {

        }

        public object get(int index)
        {
            return nodeAt(index).e;
        }

        public void set(int index, object e)
        {
            nodeAt(index).e = e;
        }

        public int size()
        {
            return SIZE;
        }

        private void removeAfter(LinkedNode node)
        {
            if (node.next != null)
            {
                node.next = node.next.next;
                SIZE--;
            }
        }

        private LinkedNode nodeAt(int index)
        {
            LinkedNode node = first;
            for (int i = -1; i < index; i++)
            {
                node = node.next;
            }
            return node;
        }
    }
}
