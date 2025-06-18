using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Node;
namespace LinkedList
{
    public class MyLinkedList<T>
    {

        public Node<T>? Head { get; private set; }
        public Node<T>? Tail { get; private set; }
        public MyLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        public MyLinkedList(T val)
        {
            Head = new Node<T>(val);
            Tail = Head;
            Count = 1;
        }


        public int Count { get; private set; }
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
            if (Head == null)
            {
                Head = new Node<T>(val);
                Tail = Head;
                Count++;
                return;
            }
            Node<T> current = new Node<T>(val);
            Tail.Next = current;
            current.Prev = Tail;
            Tail = Tail.Next;
            Count++;
        }
        //push_front
        public void AddFirst(T val)
        {
            if (Head == null)
            {
                Head = new Node<T>(val);
                Count++;
                return;
            }
            Node<T> newNode = new Node<T>(val);
            newNode.Next = Head;
            Head = newNode;
            Count++;

        }
        //pop_front
        public void RemoveFirst()
        {
            if (Head == null) return;
            Head = Head.Next;
            Count--;
        }
        //pop_back
        public void RemoveLast()
        {
            if (Tail == null) return;
            Count--;
            Tail=Tail.Prev;
            Tail.Next = null;
        }
        public void Display()
        {
            Node<T> current = Head;
            if (current == null)
            {
                Console.WriteLine("Null ");
                return;

            }
            while (current != null)
            {

                Console.Write(current.Value + "-> ");
                current = current.Next;
            }
            Console.Write("Null");
            Console.WriteLine();
        }
        //erase
        public void Remove(Node<T> node)
        {
            if (Head == null)
            {
                return;
            }
            Node<T> current = Head;
            while (current.Next != null)
            {

                if (current.Next.Equals(node))
                {
                    current.Next = current.Next.Next;
                    Count--;
                    return;
                }
                current = current.Next;
            }
            Count--;

        }
        //insert 
        public void AddAfter(Node<T> node, T val)
        {
            Node<T> tmp = new Node<T>(val);
            if (node == null) AddFirst(tmp.Value);
            Node<T> current = Head;
            while (current.Next != null)
            {

                if (current.Equals(node))
                {
                    tmp.Next = current.Next;
                    current.Next = tmp;
                    Count++;
                    return;
                }
                current = current.Next;
            }
            if (current.Equals(node))
                AddLast(tmp.Value);
            Count++;

        }
        public void AddBefore(Node<T> node, T val)
        {
            Node<T> tmp = new Node<T>(val);
            if (node == null || node.Equals(Head))
            {
                AddFirst(tmp.Value);
                return;
            }
            Node<T> current = Head;

            while (current.Next != null)
            {
                if (current.Next.Equals(node))
                {
                    tmp.Next = current.Next;
                    current.Next = tmp;
                    Count++;
                    return;
                }
                current = current.Next;
            }
            if (current.Equals(node))
                AddLast(tmp.Value);
            Count++;

        }
        public Node<T> GetMidElement()
        {
            if (Head == null || Head.Next == null) return Head;
            Node<T> fast = Head.Next;
            Node<T> slow = Head;
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }
            return slow;
        }
        public bool HasCycle()
        {

            if (Head == null || Head.Next == null) return false;
            Node<T> fast = Head;
            Node<T> slow = Head;
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
                if (fast == slow) return true;
            }
            return false;
        }
        public Node<T> Reverse()
        {
            Node<T> dummy = null;
            if (Head == null || Head.Next == null) return Head;
            Node<T> current = Head;

            while (current.Next != null)
            {
                Node<T> nextNode = current.Next;
                Head = current.Next;
                current.Next = dummy;
                dummy = current;
                current = nextNode;
            }
            Head.Next = dummy;
            return Head;
        }
    }
}
