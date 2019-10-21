using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Part1.SingleLinkedList
{
    public class LList<T> : ICollection<T>
    {
        int _count;

        private Node<T> _head;

        private Node<T> _tail;

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

        public void Add(Node<T> node)
        {
            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Next = node;
                _tail = _tail.Next;
            }

            _count++;
        }

        public void Add(T item)
        {
            this.Add(new Node<T>(item));
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public bool Contains(T item)
        {
            Node<T> iterator = _head;
            while (iterator != null)
            {
                if (iterator.Value.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T> iterator = _head;
            while(iterator != null)
            {
                array[arrayIndex++] = iterator.Value;
                iterator = iterator.Next;
            }
        }

        public bool Remove(T item)
        {
            Node<T> currNode = _head;
            Node<T> prevNode = null;

            while(currNode != null)
            {
                if (!currNode.Value.Equals(item))
                {
                    currNode = currNode.Next;
                    prevNode = currNode;
                }
            }

            if (currNode == null) return false;

            if (currNode != null)
            {
                if(prevNode == null)
                {
                    _head = _head.Next;
                    if (_head == null) _tail = null;
                }
                else
                {
                    prevNode.Next = currNode.Next;

                    if (currNode.Next == null) _tail = prevNode;
                }
            }

            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> iterator = _head;
            while(iterator != null)
            {
                yield return iterator.Value;
                iterator = iterator.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class Node<T>
    {
        private T _value;

        public Node<T> Next { get; internal set; }

        public Node(T value)
        {
            _value = value;
            Next = null;
        }

        public void UpdateData(T value)
        {
            _value = value;
        }

        public T Value => _value;
    }
}
