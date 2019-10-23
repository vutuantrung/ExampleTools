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

        Node<T> _head;

        public BinaryTree()
        {
            _count = 0;
        }

        public void Add(T value)
        {
            if (_count == 0)
            {
                _head = new Node<T>(value);
            }
            else
            {
                Node<T> currIter = _head;
                Node<T> prevIter = null;
                while (currIter != null)
                {
                    prevIter = currIter;
                    if (currIter.Value.CompareTo(value) > 0)
                    {
                        currIter = currIter.Left;
                    }
                    else
                    {
                        currIter = currIter.Right;
                    }
                }

                if (prevIter.Right == null)
                {
                    prevIter.Left = new Node<T>(value);
                }
                else if (prevIter.Left == null)
                {
                    prevIter.Right = new Node<T>(value);
                }
                else
                {
                    if (value.CompareTo(prevIter.Value) > 0)
                    {
                        prevIter.Right = new Node<T>(value);
                    }
                    else
                    {
                        prevIter.Left = new Node<T>(value);
                    }
                }
            }
            _count++;
        }

        public bool Contains(T value)
        {
            Node<T> parent;
            return FindWidthParent(value, out parent) != null;
        }

        private Node<T> FindWidthParent(T value, out Node<T> parent)
        {
            Node<T> currIter = _head;
            parent = null;

            while (currIter != null)
            {
                int compare = currIter.Value.CompareTo(value);
                if (compare > 0)
                {
                    parent = currIter;
                    currIter = currIter.Left;
                }
                else if (compare < 0)
                {
                    parent = currIter;
                    currIter = currIter.Right;
                }
                else
                {
                    break;
                }
            }

            return currIter;
        }

        public bool Remove(T value)
        {
            Node<T> currIter = null;
            Node<T> prevIter = null;

            if (currIter == null) return false;

            if (currIter.Right == null)
            {
                if (prevIter == null)
                {
                    _head = currIter.Left;
                }
                else
                {
                    int compare = prevIter.Value.CompareTo(currIter.Value);
                    if (compare > 0)
                    {
                        // If parent value is greater than current value,
                        // make the current left child a left child of parent.
                        prevIter.Left = currIter.Left;
                    }
                    else
                    {
                        // If parent value is less than current value
                        // make the current left child a right child of parent.
                        prevIter.Right = currIter.Left;
                    }
                }
            }
            else if (currIter.Left.Right == null)
            {
                currIter.Right.Left = currIter.Left;

                if (prevIter == null)
                {
                    _head = currIter.Right;
                }
                else
                {
                    int compare = prevIter.Value.CompareTo(currIter.Value);
                    if (compare > 0)
                    {
                        // If parent value is greater than current value, 
                        // make the current right child a left child of parent.
                        prevIter.Left = currIter.Right;
                    }
                    else if (compare < 0)
                    {
                        // If parent value is less than current value,
                        // make the current right child a right child of parent.
                        prevIter.Right = currIter.Right;
                    }
                }
            }
            else
            {
                Node<T> leftMostCurr = currIter.Right.Left;
                Node<T> leftMostPrev = currIter.Right;

                while(leftMostCurr.Left != null)
                {
                    leftMostPrev = leftMostCurr;
                    leftMostCurr = leftMostCurr.Left;
                }

                leftMostPrev.Left = leftMostCurr.Right;

                leftMostCurr.Left = currIter.Right;
                leftMostCurr.Right = currIter.Right;

                if(prevIter == null)
                {
                    _head = leftMostCurr;
                }
                else
                {
                    int compare = prevIter.Value.CompareTo(currIter.Value);
                    if(compare > 0)
                    {
                        // If parent value is greater than current value,
                        // make leftmost the parent's left child.
                        prevIter.Left = leftMostCurr;
                    }
                    else
                    {
                        // If parent value is less than current value,
                        // make leftmost the parent's right child.
                        prevIter.Right = leftMostCurr;
                    }
                }
            }
            _count--;
            return true;
        }

        public void PreOrderTraversal(Action<T> action) => PreOrderTraversal(action, _head);
        private void PreOrderTraversal(Action<T> action, Node<T> node)
        {
            if(node != null)
            {
                action(node.Value);
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
            }
        }

        public void PostOrderTraversal(Action<T> action) => PostOrderTraversal(action, _head);
        private void PostOrderTraversal(Action<T> action, Node<T> node)
        {
            if (node != null)
            {
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
                action(node.Value);
            }
        }

        public void InOrderTraversal(Action<T> action) => InOrderTraversal(action, _head);
        private void InOrderTraversal(Action<T> action, Node<T> node)
        {
            if (node != null)
            {
                PreOrderTraversal(action, node.Left);
                action(node.Value);
                PreOrderTraversal(action, node.Right);
            }
        }

        private IEnumerator<T> InOrderTraversal()
        {
            if (_head != null)
            {
                Stack<Node<T>> stack = new Stack<Node<T>>();
                Node<T> iterator = _head;

                bool goLeftNext = true;

                stack.Push(iterator);

                while(stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while(iterator.Left != null)
                        {
                            stack.Push(iterator);
                            iterator = iterator.Left;
                        }
                    }

                    yield return iterator.Value;

                    if(iterator.Right != null)
                    {
                        iterator = iterator.Right;
                        goLeftNext = true;
                    }
                    else
                    {
                        iterator = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        public int Count => _count;

        public IEnumerator<T> GetEnumerator() => InOrderTraversal();

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
