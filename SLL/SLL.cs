namespace LinkedList
{

    public sealed class MyListNode<T>
    {
        private MyListNode<T> _next;
        private T? _value;
        public T? Value
        {
            get => _value;
            //set
            //{
            //    _value = value;
            //}
        }
        public MyListNode(T val = default(T), MyListNode<T> next = null)
        {
            _value = val;
            _next = next;

        }

        public MyListNode<T> Next
        {

            get=> _next;
            set
            {
                _next = value;

            }
        }
        public override bool Equals(object? node)
        {

            if (node is MyListNode<T> other)
            {
                return EqualityComparer<T>.Default.Equals(other._value, this._value);
                //&&
                //    ((this._next == null && other._next == null) || (this._next != null
                //    && this._next.Equals(other._next)));
            }
            return false;
        }
        public override int GetHashCode()
        {
            return _value == null ? 0 : EqualityComparer<T>.Default.GetHashCode(_value);
        }
        public override string ToString()
        {
            return $"{Value}";
        }
    }
    public class MyLinkedList<T> 
    {

        public MyListNode<T>? head;
        public MyLinkedList() {
            head = new MyListNode<T>();
        }
        public MyLinkedList(IEnumerable<T> collection)
        {
            ArgumentNullException.ThrowIfNull(collection);

            foreach (T item in collection)
            {
                AddLast(item);
            }
        }
        //push_back
        public void AddLast(T val)
        {
            if (head == null)
            {
                head = new MyListNode<T>(val);
                return;
            }
            MyListNode<T> current = head;

            while (current.Next!=null)
            {
                current = current.Next;
            }
            current.Next = new MyListNode<T>(val);
        }
        //push_front
        public void AddFirst(T val)
        {
            if (head == null)
            {
                head = new MyListNode<T>(val);
                return;
            }
            Console.WriteLine("TTT");
            MyListNode<T> newNode = new MyListNode<T>(val, head.Next);
            head.Next = newNode;

        }
        //pop_front
        public void RemoveFirst()
        {
            if (head == null) return;
            head = head.Next;
        }
        //pop_back
        public void RemoveLast()
        {
            if (head == null) return;
            MyListNode<T> current = head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;
        }
        public void Display()
        {
            MyListNode<T> current = head.Next;
            if (current==null)
            {
                Console.WriteLine("Null ");
                return;

            }
            while (current != null)
            {
                
                Console.Write(current + "-> ");
                current = current.Next;
            }
            Console.Write("Null");
            Console.WriteLine();
        }
        //erase
        public void Remove(MyListNode<T> node)
        {
            if (head.Next == null)
            {
                Console.WriteLine("I ool");
                return;
            }
            MyListNode<T> current = head.Next;
            Console.WriteLine(current);
            while (current.Next != null)
            {

                if (current.Next.Equals(node)) {
                    Console.WriteLine("inside");
                    current.Next = current.Next.Next;
                    return;
                }
                current = current.Next;
            }

        }
        //insert 
        public void AddAfter(MyListNode<T> node,T val)
        {
            MyListNode<T> tmp = new MyListNode<T>(val);
            if (node == null) AddFirst(tmp.Value);
            MyListNode<T> current = head.Next;
            
           Console.WriteLine(current);
            while (current.Next != null)
            {

                if (current.Equals(node))
                {
                    Console.WriteLine("inside");
                    tmp.Next = current.Next;
                    current.Next = tmp;
                    return;
                }
                current = current.Next;
            }
            if(current.Equals(node))
            AddLast(tmp.Value);

        }
        public void AddBefore(MyListNode<T> node, T val)
        {
            MyListNode<T> tmp = new MyListNode<T>(val);
            if (node == null || node.Equals(head.Next))
            {
                AddFirst(tmp.Value);
                return;
            }
            MyListNode<T> current = head.Next;

            Console.WriteLine(current);
            while (current.Next != null)
            {

                if (current.Next.Equals(node))
                {
                    Console.WriteLine("inside");
                    tmp.Next = current.Next;
                    current.Next = tmp;
                    return;
                }
                current = current.Next;
            }
            if (current.Equals(node))
                AddLast(tmp.Value);

        }
        public MyListNode<T> GetMidElement()
        {
            if (head == null || head.Next == null) return head;
            MyListNode<T> fast = head;
            MyListNode<T> slow = head;
            while(fast!=null && fast.Next != null){
                fast = fast.Next.Next;
                slow = slow.Next;
            }
            return slow;
        }
        public bool HasCycle()
        {

            if (head == null || head.Next == null) return false;
            MyListNode<T> fast = head;
            MyListNode<T> slow = head;
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
                if (fast == slow) return true;
            }
            return false;
        }
        public MyListNode<T> Reverse()
        {
            MyListNode<T> dummy = null;
            if (head == null || head.Next == null) return head;
            MyListNode<T> current = head.Next;

            while (current!= null)
            {
                MyListNode<T> nextNode = current.Next;
                current.Next = dummy;
                dummy = current;
                current = nextNode;
            }
            head.Next = dummy;
            return head;
        }
    }
 
    
    internal class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<int> myList = new MyLinkedList<int>();
            myList.Display();
            myList.AddLast(10);
            myList.AddLast(5);
            myList.AddLast(6);
            myList.AddLast(7);
            myList.Display();
            //myList.RemoveLast();
            //myList.Display();
            //myList.AddFirst(2);
            //myList.Display();
            //myList.Remove(new MyListNode<int>(5));
            //myList.Display();
        //    myList.AddBefore(new MyListNode<int>(7),99);
         //   myList.Display();
            Console.WriteLine(myList.GetMidElement());
            Console.WriteLine(myList.HasCycle());
            myList.Reverse();
            myList.Display();


        }
    }
}
