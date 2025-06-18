using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Node
{
    public sealed class Node<T>
    {
        public Node<T> Next { set; get; }
        public Node<T> Prev { set; get; }
        private T? _value = default(T);
        public T? Value
        {
            get => _value;
            set
            {
                if (value != null)
                    _value = value;
            }
        }
        public Node(T val)
        {
            Value = val;
        }


        public override bool Equals(object? node)
        {

            if (node is Node<T> other)
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
}
