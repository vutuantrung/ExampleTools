using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Part1.DoubleLinkedList
{
    public class LList<T> : ICollection<T>
    {
        int _count;

        Node<T> _head;

        Node<T> _tail;

        public Node<T> Head => _head;

        public Node<T> Tail => _tail;

        public int Count => _count;

        public bool IsReadOnly => false;

        public LList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (_count == 0)
            {
                _head = newNode;
                _tail = _head;
            }
            else
            {
                newNode.Next = _head;
                _head.Previous = newNode;
                _head = newNode;
            }
            _count++;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (_count == 0)
            {
                _head = newNode;
                _tail = _head;
            }
            else
            {
                _tail.Next = newNode;
                newNode.Previous = _tail;
                _tail = newNode;
            }
            _count++;
        }


        public void Add(T item)
        {
            AddLast(item);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public void RemoveFirst(T item)
        {
            if (_count == 0) return;
            if (_count == 1)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                _head = _head.Next;
                _head.Previous = null;
            }
            _count--;
        }

        public void RemoveLast(T item)
        {
            if (_count == 0) return;
            if (_count == 1)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                _tail = _tail.Previous;
                _tail.Next = null;
            }
            _count--;
        }

        public bool Remove(T item)
        {
            Node<T> iterator = _head;

            if (_count == 0) return false;

            if (_count == 1)
            {
                if (iterator.Value.Equals(item))
                {
                    _head = null;
                    _tail = null;
                    return true;
                }
                return false;
            }

            while (iterator != null)
            {
                if (iterator.Value.Equals(item))
                {
                    if (iterator.Previous == null)
                    {
                        // Remove first
                        _head = _head.Next;
                        _head.Previous = null;
                    }
                    else
                    {
                        if (iterator.Next == null)
                        {
                            // Remove last
                            _tail = _tail.Previous;
                            _tail.Next = null;
                        }
                        else
                        {
                            // Remove in middle
                            Node<T> prev = iterator.Previous;
                            iterator = iterator.Next;
                            prev.Next = iterator;
                            iterator.Previous = prev;
                        }
                    }
                    _count--;
                    return true;
                }

                iterator = iterator.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> iterator = _head;
            while (iterator != null)
            {
                yield return iterator.Value;
                iterator = iterator.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class Node<T>
    {
        T _value;

        public Node<T> Next { get; internal set; }

        public Node<T> Previous { get; internal set; }

        public T Value => _value;

        public Node(T value)
        {
            _value = value;
            Next = null;
            Previous = null;
        }

        public void UpdateData(T value)
        {
            _value = value;
        }
    }
}
