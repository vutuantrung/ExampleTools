using DataStructures.Part1.DoubleLinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Part1
{
    public class Deque<T>
    {
        LList<T> _items = new LList<T>();

        public Deque()
        {

        }

        public void EnqueueFirst(T item)
        {
            _items.AddFirst(item);
        }

        public void EnqueueLast(T item)
        {
            _items.AddLast(item);
        }

        public T DequeueFirst()
        {
            if (_items.Count == 0) throw new InvalidOperationException("The Deque is empty. Can not dequeue at first element.");
            T value = _items.Head.Value;
            _items.RemoveFirst();
            return value;
        }

        public T DequeueLast()
        {
            if (_items.Count == 0) throw new InvalidOperationException("The Deque is empty. Can not dequeue at last element.");
            T value = _items.Tail.Value;
            _items.RemoveLast();
            return value;
        }

        public T PeekFirst()
        {
            if (_items.Count == 0) throw new InvalidOperationException("The Deque is empty. Can not peek the first element.");
            return _items.Head.Value;
        }

        public T PeekLast()
        {
            if (_items.Count == 0) throw new InvalidOperationException("The Deque is empty. Can not peek the last element.");
            return _items.Tail.Value;
        }

        public int Count => _items.Count;
    }
}
