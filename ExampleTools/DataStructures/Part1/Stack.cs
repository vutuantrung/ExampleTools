using DataStructures.Part1.DoubleLinkedList;
using System;
using System.Text;

namespace DataStructures.Part1
{
    public class Stack<T>
    {
        LList<T> _items = new LList<T>();

        public Stack()
        {
        }

        public void Push(T value)
        {
            _items.AddLast(value);
        }

        public T Pop()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }
            T item = _items.Tail.Value;
            _items.RemoveLast();
            return item;
        }

        public T Peek()
        {
            if(_items.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }
            return _items.Tail.Value;
        }

        public int Count => _items.Count;
    }
}
