using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks
{
    public class ArrayStack : Stack
    {
        private object[] data;
        private int SIZE;
        private int cap;
        public ArrayStack(int cap)
        {
            data = new object[cap]; 
            this.cap = cap;
        }

        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public object peek()
        {
            if (isEmpty())
                throw new InvalidOperationException("Stack is empty.");
            return data[SIZE - 1];
        }

        public object pop()
        {
            if (isEmpty())
                throw new InvalidOperationException("Stack is empty.");
            object top = peek();
            data[--SIZE] = null; 
            return top;
        }

        public void push(object e)
        {
            ensureCapacity();
            data[SIZE++] = e;
        }

        public int size()
        {
            return SIZE;
        }
        private void ensureCapacity()
        {
            if (SIZE + 1 > data.Length)
            {
                object[] tempdata = new object[2 * SIZE];
                for (int i = 0; i < SIZE; i++)
                    tempdata[i] = data[i];
                data = tempdata;
            }
        }
        public static bool IsCorrectParentheses(string t)
        {
            string open = "({[<";
            string close = ")}]>";
            Stack<char> stack = new Stack<char>();

            foreach (char a in t)
            {
                if (open.Contains(a))
                {
                    stack.Push(a);
                }
                else if (close.Contains(a))
                {
                    if (stack.Count == 0)
                    {
                        return false;  // ถ้าไม่มีวงเล็บเปิดที่ตรงกันใน stack
                    }
                    char openChar = stack.Pop();
                    if (open.IndexOf(openChar) != close.IndexOf(a))
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }
    }
}
