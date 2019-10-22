using DataStructures.Part1.SingleLinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Part1
{
    public class Queue<T>
    {
        LList<T> _items = new LList<T>();

        public Queue()
        {

        }

        public void Enqueue(T item)
        {
            _items.AddLast(item);
        }

        public T Dequeue()
        {
            if (_items.Count == 0) throw new InvalidOperationException("The queue is empty.");
            T item = _items.Head.Value;
            _items.RemoveFirst();
            return item;
        }

        public T Peek()
        {
            if (_items.Count == 0) throw new InvalidOperationException("The queue is empty.");
            return _items.Tail.Value;
        }

        public int Count => _items.Count;

    }
}
