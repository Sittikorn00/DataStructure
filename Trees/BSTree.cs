using System;

namespace Trees
{
    public class BSTree : BinaryTree
    {
        private int SIZE;
        
        public int size() { return SIZE; }
        public bool isEmpty() { return SIZE == 0; }

        public bool contains(object e)
        {
            return getNode(root, e) != null;
        }

        public object getMin()
        {
            if (root == null) throw new InvalidOperationException("Tree is empty");
            Node current = root;
            while (current.left != null)
            {
                current = current.left;
            }
            return current.e;
        }

        public object getMax()
        {
            if (root == null) throw new InvalidOperationException("Tree is empty");
            Node current = root;
            while (current.right != null)
            {
                current = current.right;
            }
            return current.e;
        }

        public void add(object e)
        {
            root = add(root, e);
            SIZE++;
        }

        public void remove(object e)
        {
            root = remove(root, e);
        }

        protected int compareTo(object a, object b)
        {
            return ((IComparable)a).CompareTo(b);
        }

        private Node getNode(Node r, object e)
        {
            if (r == null) return null;

            int cmp = compareTo(e, r.e);
            if (cmp < 0) return getNode(r.left, e);
            else if (cmp > 0) return getNode(r.right, e);
            else return r;
        }

        private Node add(Node r, object e)
        {
            if (r == null) return new Node(e, null, null);

            int cmp = compareTo(e, r.e);
            if (cmp < 0)
            {
                r.left = add(r.left, e);
            }
            else if (cmp > 0)
            {
                r.right = add(r.right, e);
            }
            return r;
        }

        private Node remove(Node r, object e)
        {
            if (r == null) return null;

            int cmp = compareTo(e, r.e);
            if (cmp < 0)
            {
                r.left = remove(r.left, e);
            }
            else if (cmp > 0)
            {
                r.right = remove(r.right, e);
            }
            else
            {
                // Node with only one child or no child
                if (r.left == null) return r.right;
                if (r.right == null) return r.left;

                // Node with two children: Get the inorder successor (smallest in the right subtree)
                Node minRight = r.right;
                while (minRight.left != null)
                {
                    minRight = minRight.left;
                }
                r.e = minRight.e;
                r.right = remove(r.right, minRight.e);
            }
            return r;
        }
        public static void treeSort(ref object[] x)
        {
            if (x == null) return; // No sorting needed for a null array

            BSTree tree = new BSTree();
            foreach (var item in x)
            {
                tree.add(item);
            }

            object[] sortedArray = tree.toArray(BSTree.Inorder);
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = sortedArray[i];
            }
        }
    }
}