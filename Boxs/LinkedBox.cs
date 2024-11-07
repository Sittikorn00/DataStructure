using Boxs;
using System;

public class LinkedBox : Box
{
    int SIZE;
    LinkedNode first = new LinkedNode(0, null);
    int sum;

    private class LinkedNode
    {
        public int e;
        public LinkedNode next;
        public LinkedNode(int e, LinkedNode next)
        {
            this.e = e; this.next = next;
        }
    }

    public void add(int e)
    {
        sum += e;
        LinkedNode CurrentNode = first; 
        while (CurrentNode.next != null)
        {
            CurrentNode = CurrentNode.next;
        }
        CurrentNode.next = new LinkedNode(e + sum - e, null);
        SIZE++;
    }

    public void remove(int e)
    {
        LinkedNode CurrentNode = first;
        while (CurrentNode.next != null)
        {
            if (CurrentNode.next.e - (CurrentNode.e) == e)
            {
                sum -= e;
                CurrentNode.next = CurrentNode.next.next;
                while (CurrentNode.next != null)
                {
                    CurrentNode.next.e -= e;
                    CurrentNode = CurrentNode.next;
                }
                SIZE--;
                return;
            }
            CurrentNode = CurrentNode.next;
        }
    }

    public bool isEmpty()
    {
        return SIZE == 0;
    }

    public int size()
    {
        return SIZE;
    }

    public void view()
    {
        if (isEmpty())
        {
            Console.WriteLine("Empty");
            return;
        }
        LinkedNode node = first.next;
        while (node != null)
        {
            Console.Write(node.e + " ");
            node = node.next;
        }
        Console.WriteLine();
    }
}