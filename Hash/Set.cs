using System;
using System.Collections.Generic;

namespace HashSet
{
    public class MyHashSet<TK> where TK : IComparable
    {
        private class Node
        {
            public TK Key { get; set; }
            public Node Next { get; set; }
            public override string ToString()
            {
                return $"{Key}";
            }
        }
        
        private const double _tresHolder = 0.75;
        private List<Node> slots;
        public int Count { private set; get; } = 0;
        public int Capacity { set; get; }

        public MyHashSet(int cap = 0)
        {
            Capacity = cap;
            slots = new List<Node>(cap);
            for (int i = 0; i < Capacity; i++)
            {
                slots.Add(null);
            }
        }
        public int GetIndexOfSlot(TK key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            return Math.Abs((key.GetHashCode()) % Capacity);

        }
        private void ReHash()
        {
            List<Node> oldSlots = slots;
            Capacity = Capacity > 0 ? Capacity * 2 : 1;
            slots = new List<Node>(Capacity);
            for (int i = 0; i < Capacity; i++)
            {
                slots.Add(null);
            }
            Count = 0;
            foreach (Node node in oldSlots)
            {
                Node current = node;
                while (current != null)
                {
                    Add(current.Key);
                    current = current.Next;
                }
            }
        }
        public void Add(TK key)
        {
            if (Capacity == 0 || (double)(Count + 1) / Capacity > _tresHolder)
            {
                ReHash();
            }
            int index = GetIndexOfSlot(key);
            Node cur = slots[index];
            while (cur != null)
            {
                if (MyContainsKey(key))
                {
                    Console.WriteLine("Already exists key");
                    return;
                }
                cur = cur.Next;
            }
            slots[index] = new Node
            {
                Next = slots[index],
                Key = key
            };
            Count++;
        }
        public bool Remove(TK key)
        {
            if (key == null || !MyContainsKey(key)) return false;
            int index = GetIndexOfSlot(key);
            Node cur = slots[index];
            Node prev = null;
            while (cur != null)
            {
                if (cur.Key.Equals(key))
                {
                    if (prev == null)
                    {
                        slots[index] = cur.Next;
                    }
                    else
                    {
                        prev.Next = cur.Next;
                    }

                    Count--;
                    return true;
                }
                prev = cur;
                cur = cur.Next;
            }
            return false;
        }
        public bool MyContainsKey(TK key)
        {
            if (key == null) return false;
            int index = GetIndexOfSlot(key);
            Node cur = slots[index];
            while (cur != null)
            {
                if (key.Equals(cur.Key))
                {
                    return true;
                }
                cur = cur.Next;
            }
            return false;
        }
        public void Display()
        {
            for (int i = 0; i < slots.Capacity; i++)
            {
                Node cur = slots[i];
                while (cur != null)
                {
                    Console.WriteLine(cur.ToString());
                    cur = cur.Next;
                }

            }
        }
    }

}
