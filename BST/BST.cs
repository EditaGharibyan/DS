
namespace BinSearch
{
    public class BST<T> where T : IComparable
    {
        private class Node {
            public T Value { set; get; }
            public Node left { set; get; }
            public Node right{ set; get; }
        }
        private Node root;
        public void Insert(T val)
        {

            root = InsertHelperIterative(root, val);            
        }
        private Node InsertHelperIterative(Node root,T val)
        {
            Node node = root;
            if (node == null) return new Node { Value = val };
            Node prev = null;
            int cmp = val.CompareTo(node.Value);
            while (node != null)
            {
                cmp = val.CompareTo(node.Value);
                if (cmp < 0 )
                {
                    prev = node;
                    node = node.left;
                }
                if (cmp > 0)
                {
                    prev = node;
                    node = node.right;
                }
            }
            if(val.CompareTo(prev.Value) < 0)
            {
                prev.left = new Node { Value = val };
            }
            else
            {
                prev.right = new Node { Value = val };
            }
                return root;
        } 
        private Node InsertHelper(Node node ,T val)
        {
            if(node == null)
            {
                return new Node
                {
                    Value = val,
                };
            }
            int cmp = val.CompareTo(node.Value);
            if (cmp<0)
            {
                node.left = InsertHelper(node.left,val);
            }
            else if (cmp > 0)
            {
                node.right = InsertHelper(node.right, val);
            }
                return node;
        }
        public bool Search(T val)
        {   
            return SearchHelperIterative(root,val);
        }
        private bool SearchHelper(Node node,T val)
        {
            if (node== null) return false;
            int cmp = val.CompareTo(node.Value);
            if (cmp == 0) return true;
            if (cmp < 0)
            {
                return SearchHelper(node.left,val);
            }
            if (cmp > 0) return SearchHelper(node.right,val);
            return false;
        }
        private bool SearchHelperIterative(Node root, T val)
        {
            Node node = root;
            if (node == null) return false;
            Node prev = null;
            int cmp = val.CompareTo(node.Value);
            while (node != null)
            {
                cmp = val.CompareTo(node.Value);
                if (cmp == 0) return true;
                if (cmp < 0)
                {
                    prev = node;
                    node = node.left;
                }
                if (cmp > 0)
                {
                    prev = node;
                    node = node.right;
                }
            }
            return false;
        }

        public void Print()
        {
            Action<string> p = Console.WriteLine;
            InOrderTraversal(root,p);
            //PostOrderTraversal(root,p);
            //PreOrderTraversal(root,p);
        }

        private void InOrderTraversal(Node root,Action<string> func)
        {
            if (root == null) return;
            InOrderTraversal(root.left,func);
            func($"{root.Value}");
            InOrderTraversal(root.right,func);
        }
        private void PostOrderTraversal(Node root, Action<string> func)
        {
            if (root == null) return;
            PostOrderTraversal(root.left, func);
            PostOrderTraversal(root.right, func);
            func($"{root.Value}");
        }
        private void PreOrderTraversal(Node root, Action<string> func)
        {
            if (root == null) return;
            func($"{root.Value}");
            PreOrderTraversal(root.left, func);
            PreOrderTraversal(root.right, func);
        }

    }
}
