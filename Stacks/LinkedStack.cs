namespace Stacks
{
    public class LinkedStack : Stack
    {
        private int SIZE;
        private LinkedNode first;
        private class LinkedNode
        {
            public object e;
            public LinkedNode next;
            public LinkedNode(object e, LinkedNode next) //Constructor
            {
                this.e = e;
                this.next = next;
            }
        }
        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public object peek()
        {
            return first.e;
        }

        public object pop()
        {
            object top = peek();  // เก็บค่าบนสุดของ Stack
            first = first.next;    // ย้ายตัวชี้ไปยังโหนดถัดไป
            SIZE--;                // ลดขนาดของ stack ลง
            return top;            // คืนค่าข้อมูลที่ถูกลบออก
        }

        public void push(object e)
        {
            first = new LinkedNode(e, first); //สร้าง LinkedNode ต่อจาก First 
            SIZE++;
        }

        public int size()
        {
            return SIZE;
        }
    }
}
