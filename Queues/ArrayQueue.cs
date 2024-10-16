using System;
using System.Collections.Generic;

namespace Queues
{
    public class ArrayQueue : Queue
    {
        private object[] data;
        private int SIZE;
        private int firstindex;

        public ArrayQueue(int cap)
        {
            data = new object[cap];
            this.SIZE = 0; // เริ่มต้น SIZE ที่ 0
            this.firstindex = 0; // เริ่มต้น firstindex ที่ 0
        }

        public void enqueue(object e)
        {
            ensureCapacity();
            data[(firstindex + SIZE) % data.Length] = e;
            SIZE++; // เพิ่ม SIZE หลังจากเพิ่มสมาชิกใหม่
        }

        public object dequeue()
        {
            if (isEmpty())
                throw new InvalidOperationException("Queue is empty.");
            object first = peek();
            data[firstindex] = null;
            firstindex = (firstindex + 1) % data.Length; // เลื่อนตำแหน่ง firstindex ไปยัง index ถัดไป
            SIZE--; // ลด SIZE หลังจากนำข้อมูลออก
            return first;
        }
        public bool isEmpty()
        {
            return SIZE == 0;
        }
        public object peek()
        {
            if (isEmpty())
                throw new InvalidOperationException("Queue is empty."); // ข้อผิดพลาดเมื่อคิวว่าง
            return data[firstindex];
        }
        public int size()
        {
            return SIZE;
        }
        private void ensureCapacity()
        {
            if (SIZE >= data.Length) // เปลี่ยนเป็น >= เพื่อให้เพิ่มได้เมื่อเต็ม
            {
                object[] tempdata = new object[2 * data.Length]; // ขยายความจุเป็นสองเท่า
                for (int i = 0; i < SIZE; i++)
                    tempdata[i] = data[(firstindex + i) % data.Length]; // เทข้อมูลจากถังใบเก่าไปใบใหม่
                data = tempdata; // โยนข้อมูลจากถังเก่าทิ้งไป
                firstindex = 0; // รีเซ็ต firstindex ให้กลับไปที่ 0
            }
        }
        public static void RadixSort(int[] numbers)
        {
            Console.WriteLine("Before sorting: " + string.Join(", ", numbers));
            // แยกจำนวนเต็มบวกลบ
            List<int> positiveNumbers = new List<int>();
            List<int> negativeNumbers = new List<int>();
            foreach (var num in numbers) //บันทึกจำนวน + และ - เพื่อเรียงลำดับ
            {
                if (num < 0) negativeNumbers.Add(-num);
                else positiveNumbers.Add(num);
            }

            // เรียงลำดับจำนวนบวก
            ArrayQueue[] queues = new ArrayQueue[10]; // ใช้ 10 คิวสำหรับเลขฐาน 10 (0-9)
            for (int i = 0; i < 10; i++)
            {
                queues[i] = new ArrayQueue(5); // ขนาดของแต่ละคิว
            }
            int maxPositive = FindMax(positiveNumbers.ToArray()); // ค้นหาค่ามากสุดในจำนวนดต็มบวก
            int exp = 1; //เริ่มจากหลักหน่วย
            while (maxPositive / exp > 0)
            {
                foreach (var num in positiveNumbers)
                {
                    int digit = (num / exp) % 10; // คำนวณหลักที่ต้องการ (0-9)
                    queues[digit].enqueue(num); // ใส่ตัวเลขลงในคิวที่ตรงกับหลัก
                }
                int index = 0;
                for (int i = 0; i < 10; i++)
                {
                    while (!queues[i].isEmpty()) //แต่ละคิวต้องมีตัวเลข
                        positiveNumbers[index++] = (int)queues[i].dequeue(); // นำตัวเลขกลับมาใส่ใน array
                }
                exp *= 10; // เปลี่ยนไปยังหลักถัดไป
            }
            // ไม่ต้องย้อนกลับจำนวนลบ เพียงแค่แปลงกลับเป็นค่าลบก่อนรวม
            for (int i = 0; i < negativeNumbers.Count; i++)
            {
                negativeNumbers[i] = -negativeNumbers[i];
            }
            // แสดงผลลัพธ์
            int[] sortedArray = new int[numbers.Length]; //สร้าง sortedArray ซึ่งมีขนาดเท่ากับ numbers Array
            Array.Copy(negativeNumbers.ToArray(), sortedArray, negativeNumbers.Count); //แปลง list negativeNumbers เป็น Array แล้ว copy ไปที่ sortedArray ด้วยจำนวนที่มีทั้งหมด(negativeNumbers.Count)
            Array.Copy(positiveNumbers.ToArray(), 0, sortedArray, negativeNumbers.Count, positiveNumbers.Count); //copy เริ่มต้นที่ index 0 ไป sortedArray ต่อจาก negativeNumbers ด้วยจำนวนที่มีทั้งหมด(positiveNumbers.Count)
            Console.WriteLine("After sorting: " + string.Join(", ", sortedArray)); // แสดงผลลัพธ์หลังการเรียงลำดับ
        }
        public static int FindMax(int[] array)
        {
            int max = array[0]; //สมมติให้ตัวแรกมีค่ามากสุด
            foreach (var num in array)
                if (num > max) max = num; //อัปเดต max ถ้าเจอค่ามากกว่า
            return max;
        }

    }
}
