using Lists;
using LinkedLists;

namespace Queues
{
    public class LinkedListQueue : Queue
    {
        private List list = new DoublyLinked();
        public object dequeue()
        {
            object first = list.get(0); // ดึงค่าตัวแรกในลิสต์
            list.remove(0); // ลบค่าตัวแรกออกจากลิสต์
            return first;
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
            return list.get(0);
        }

        public int size()
        {
            return list.size();
        }
    }
}
