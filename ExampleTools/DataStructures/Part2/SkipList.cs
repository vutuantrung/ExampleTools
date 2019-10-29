using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Part2.SkipList
{
    public class SkipList<T> : ICollection<T>
        where T : IComparable<T>
    {
        private readonly Random _rand = new Random();

        private Node<T> _head;

        private int _levels;

        private int _count;

        public SkipList()
        {
            _levels = 1;
            _count = 0;
        }

        public int Count => _count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            int level = PickRandomLevel();

            Node<T> newNode = new Node<T>(item, level + 1);
            Node<T> current = _head;

            for (int i = _levels - 1; i >= 0; i--)
            {
                while (current.Next[i] != null)
                {
                    if (current.Next[i].Value.CompareTo(item) > 0) break;
                    current = current.Next[i];
                }

                if (i <= level)
                {
                    newNode.Next[i] = current.Next[i];
                    current.Next[i] = newNode;
                }
            }

            _count++;
        }

        private int PickRandomLevel()
        {
            int rand = _rand.Next();
            int level = 0;

            // & operator
            while ((rand & 1) == 1)
            {
                if (level == _levels)
                {
                    _levels++;
                    break;
                }

                rand >>= 1;
                level++;
            }
            return level;
        }

        public void Clear()
        {
            _head = new Node<T>(default(T), 32 + 1);
            _count = 0;
        }

        public bool Contains(T item)
        {
            Node<T> current = _head;

            for (int level = _levels - 1; level >= 0; level--)
            {
                while(current.Next[level] != null)
                {
                    int compare = current.Next[level].Value.CompareTo(item);
                    if (compare == 0)
                    {
                        return true;
                    }

                    if (compare > 0)
                    {
                        break;
                    }

                    current = current.Next[level];
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("Array is null");

            int offset = 0;
            foreach(T item in this)
            {
                array[arrayIndex + offset++] = item;
            }
        }

        public bool Remove(T item)
        {
            Node<T> current = _head;

            bool removed = false;

            for (int level = _levels - 1; level >= 0; level--)
            {
                while (current.Next[level] != null)
                {
                    if (current.Next[level].Value.CompareTo(item) == 0)
                    {
                        current.Next[level] = current.Next[level].Next[level];
                        removed = true;
                        break;
                    }

                    if (current.Next[level].Value.CompareTo(item) > 0) break;

                    current = current.Next[level];
                }
            }

            if (removed)
            {
                _count--;
            }

            return removed;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _head;

            while(current != null)
            {
                yield return current.Value;
                current = current.Next[0];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal class Node<T>
    {
        /// <summary>
        /// Initialize Skip list node
        /// </summary>
        /// <param name="value">Value of the node</param>
        /// <param name="height">The level of sub-nodes</param>
        public Node(T value, int height)
        {
            Value = value;
            Next = new Node<T>[height];
        }

        /// <summary>
        /// The array of links. The number of items is the height of links.
        /// </summary>
        public Node<T>[] Next
        {
            get;
            private set;
        }

        /// <summary>
        /// The containing value.
        /// </summary>
        public T Value
        {
            get;
            private set;
        }
    }
}

/*  Illusion:
 *  Levels: 3   |------------------>|
 *          2   |---------->|------>|-->|
 *          1   |-->|-->|-->|-->|-->|-->|-->|
 *  Value:      1   2   3   4   5   6   7   8
 */

/*  "|" operator (OR operator)
 *  Using to turn certain bits on: Y OR 1 = 1 and Y OR 0 = Y
 *      10010101   10100101
 *  OR  11110000   11110000
 *  =   11110101   11110101
 */

/*  "&" operator (AND operator)
 *  Using to "mask off" bits: Y AND 0 = 0 and only 1 AND 1 = 1
 *      10010101   10100101
 *  AND 00001111   00001111
 *  =   00000101   00000101
 */
