using System;

namespace Trees
{
    public class BinaryTree
    {
        public class Node
        {
            public object e;
            public Node left, right;
            public Node(object e, Node left, Node right)
            {
                this.e = e;
                this.left = left;
                this.right = right;
            }
            public bool isLeaf()
            {
                return left == null && right == null;
            }
        }
        protected Node root;
        public int numNodes()
        {
            return numNodes(root); //เริ่มนับที่ราก

        }
        private int numNodes(Node node)
        {
            if (node == null) return 0;
            return 1 + numNodes(node.left) + numNodes(node.right); //นับรากและนับลูกซ้ายขวา
        }
        public int depth()
        {
            return depth(root);
        }
        private int depth(Node node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(depth(node.left), depth(node.right)); //คำนวน depth ซ้ายขวาแล้วเลือกค่ามากสุด
        }
        public const string Preorder = "Preorder";
        public const string Inorder = "Inorder";
        public const string Postorder = "Postorder";
        //public object[] toArray()
        //{
        //    object[] array = new object[numNodes()]; //สร้าง Array ที่มีขนาดเท่ากับจำนวน node
        //    toArrayPreorder(root,array,0); //เริ่มที่ root node ของ object array และเริ่มจาก index 0
        //    toArrayInorder(root, array, 0);
        //    toArrayPostorder(root, array, 0);
        //    return array;
        //}
        public object[] toArray(string type)
        {
            object[] array = new object[numNodes()]; // สร้าง Array ที่มีขนาดเท่ากับจำนวน node
            switch (type)
            {
                case Preorder:
                    toArrayPreorder(root, array, 0);
                    break;
                case Inorder:
                    toArrayInorder(root, array, 0);
                    break;
                case Postorder:
                    toArrayPostorder(root, array, 0);
                    break;
                default:
                    throw new ArgumentException("Invalid traversal type");
            }
            return array;
        }
        private static int toArrayPreorder(Node x, object[] a, int k) //k = index
        {
            if (x == null) return k; //ถ้า node เป็น null ให้คืนค่า index ปัจจุบัน
            a[k] = x.e; //ใส่ object ของ node ลงไปใน array
            k++;
            //recursive ซ้ายขวา
            k = toArrayPreorder(x.left, a, k);
            k = toArrayPreorder(x.right, a, k);
            return k;
        }
        protected static int toArrayInorder(Node x, object[] a, int k) // k = index
        {
            if (x == null) return k; // ถ้า node เป็น null ให้คืนค่า index ปัจจุบัน

            // recursive ซ้าย
            k = toArrayInorder(x.left, a, k);
            a[k] = x.e; // ใส่ object ของ node ลงไปใน array
            k++;
            // recursive ขวา
            k = toArrayInorder(x.right, a, k);
            return k;
        }
        private static int toArrayPostorder(Node x, object[] a, int k) // k = index
        {
            if (x == null) return k; // ถ้า node เป็น null ให้คืนค่า index ปัจจุบัน

            // recursive ซ้าย
            k = toArrayPostorder(x.left, a, k);
            // recursive ขวา
            k = toArrayPostorder(x.right, a, k);
            a[k] = x.e; // ใส่ object ของ node ลงไปใน array
            k++;
            return k;
        }
    }
}