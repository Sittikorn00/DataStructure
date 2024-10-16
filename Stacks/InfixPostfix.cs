using System;
using Stacks;  // Ensure you have the correct namespaces or classes
using Lists;   // Ensure the LinkedList class is implemented
using LinkedLists;
using Collections;
using System.Collections.Generic;

namespace Stacks
{
    public class InfixPostfix
    {
        static int Prec(char c) //กำหนด Priority ของ Operators (precedence)
        {
            if (c == '^') return 3; //ยกกำลังสำคัญสูงสุด
            else if (c == '/' || c == '*') return 2;
            else if (c == '+' || c == '-') return 1;
            else return -1;
        }
        static char Asso(char c)
        {
            if (c == '^') return 'R'; //การคำนวนเลขยกกำลังจะเริ่มจากขวาไปซ้าย 
            return 'L';
        }
        public static void Converter(string s)
        {
            if (!ArrayStack.IsCorrectParentheses(s)) //ใช้ Method IsCorrectParentheses ตรวจสอบว่าใส่วงเล็บถูกต้องหรือไม่
            {
                Console.WriteLine("Error: Incorrect parentheses!"); return;
            }
            ArrayStack opt = new ArrayStack(s.Length); //ใช้ ArrayStack เก็บ Operators
            DoublyLinked result = new DoublyLinked();  //LinkedList ใส่ Operands แล้วค่อย pop operator ใน ArrayStack มาใส่อีกที
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i]; //c เป็น char ใน String s
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9')) result.add(c); //ถ้าเจอตัวแปร a-z หรือ 0-9 ให้ใส่ใน List
                else if (c == '(') opt.push(c);
                else if (c == ')')
                {
                    while (!opt.isEmpty() && (char)opt.peek() != '(') //หลุด loop เมื่อเจอวงเล็บเปิด
                    {
                        result.add((char)opt.pop());
                    }
                    opt.pop(); // Remove '('
                }
                else
                {
                    while (!opt.isEmpty() && (Prec(c) < Prec((char)opt.peek()) || (Prec(c) == Prec((char)opt.peek()) && Asso(c) == 'L')))
                    {
                        result.add((char)opt.pop());
                    }
                    opt.push(c);
                }
            }
            while (!opt.isEmpty()) //ถ้า Stack ยังเหลือเครื่องหมายให้ pop แล้ว add ไปใน List ด้วย
            {
                result.add(opt.pop());
            }
            Console.WriteLine("Infix: " + s);
            Console.WriteLine("Postfix: " + string.Join("", result));
        }
        public static string Calculator(string v)
        {
            ArrayStack exp = new ArrayStack(v.Length);  // Create a stack instance for use within the method
            int a, b, ans;
            for (int i = 0; i < v.Length; i++)
            {
                string c = v.Substring(i, 1); //ดึง String ทีละตัวอักษร
                if (c.Equals("*"))
                {
                    string sa = (string)exp.pop(); string sb = (string)exp.pop();
                    a = int.Parse(sb); b = int.Parse(sa);
                    exp.push((a * b).ToString());
                }
                else if (c.Equals("/"))
                {
                    string sa = (string)exp.pop(); string sb = (string)exp.pop();
                    a = int.Parse(sb); b = int.Parse(sa);
                    exp.push((a / b).ToString());
                }
                else if (c.Equals("+"))
                {
                    string sa = (string)exp.pop(); string sb = (string)exp.pop();
                    a = int.Parse(sb); b = int.Parse(sa);
                    exp.push((a + b).ToString());
                }
                else if (c.Equals("-"))
                {
                    string sa = (string)exp.pop(); string sb = (string)exp.pop();
                    a = int.Parse(sb); b = int.Parse(sa);
                    exp.push((a - b).ToString());
                }
                else
                {
                    exp.push(c);
                }
            }
            string answer = (string)exp.pop();
            Console.WriteLine("Input: " + v);
            Console.WriteLine("Result: " + answer);
            return answer;
        }



    }
}
