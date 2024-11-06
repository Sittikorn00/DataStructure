﻿using System;
using Queues;

namespace Trees
{
    public class HuffmanTree : BinaryTree, IComparable
    {
        public HuffmanTree(int f, Node left, Node right)
        { root = new Node(f, left, right); }
        public int CompareTo(object x)
        { return Frequency() - ((HuffmanTree)x).Frequency(); }
        public int Frequency()
        { return (int)root.e; }
        public static HuffmanTree encode(int[] f)
        {
            BinaryMinHeap h = new BinaryMinHeap(0);
            for (int i = 0; i < f.Length; i++)
                h.enqueue(new HuffmanTree(f[i], null, null));
            for (int i = 0; i < f.Length - 1; i++)
            {
                HuffmanTree t1 = (HuffmanTree)h.dequeue();
                HuffmanTree t2 = (HuffmanTree)h.dequeue();
                int sumf = t1.Frequency() + t2.Frequency();
                h.enqueue(new HuffmanTree(sumf, t1.root, t2.root));
            }
            return (HuffmanTree)h.dequeue();
        }
        public int[] ToFrequencyArray(string traversalType)
        {
            // Get the frequency values in the specified traversal order
            object[] frequencyObjects = toArray(traversalType);

            // Convert the object array to an int array of frequencies
            int[] frequencies = Array.ConvertAll(frequencyObjects, item => (int)item);

            return frequencies;
        }
    }
}