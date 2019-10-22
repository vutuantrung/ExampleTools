using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Part1
{
    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        int _count;

        public BinaryTree()
        {
            _count = 0;
        }

        public void Add(T value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T value)
        {
            throw new NotImplementedException();
        }

        public void PreOrderTraversal(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public void PostOrderTraversal(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public void InOrderTraversal(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public int Count => _count;

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    class Node<TNode> : IComparable<TNode>
        where TNode : IComparable<TNode>
    {
        public TNode Value { get; private set; }

        public Node<TNode> Left { get; set; }

        public Node<TNode> Right { get; set; }


        public Node(TNode value)
        {
            Value = value;
        }

        public int CompareTo(TNode other) => other.CompareTo(Value);
    }
}
