using Node;
using LinkedList; 
namespace Program {   
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
            myList.RemoveLast();
            myList.Display();
            myList.AddFirst(2);
            myList.Display();
            myList.Remove(new Node<int>(5));
            myList.Display();
            myList.AddBefore(null, 99);
            myList.Display();
            Console.WriteLine(myList.GetMidElement().Value);
            Console.WriteLine(myList.HasCycle());
            myList.Reverse();
            myList.Display();


        }
    }
}

