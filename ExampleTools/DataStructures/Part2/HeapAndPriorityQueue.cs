using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Part2.HeapAndPriorityQueue
{
    /*  Behaviors:
     *  1.  Allow values to be added to the collection*
     *  2.  Return max or min value in the collection, depending on whether it is a "min" or "max" heap
     *  
     *  Rules:
     *  1.  The child values of any node are less than the node's value.
     *  2.  The tree will be complete tree, it means ndoes will be filled from left to right of each level of tree.
     *  
     *      6           6                     8
     *    /   \           \                /     \
     *   /     \           \              /       \
     *  5       8           5           6           5
     *                                /   \       /   \
     *                               /     \     /     \
     *                              3       4
     *   invalid     invalid                valid
     * 
     *  Structural overview:
     *              h
     *            /   \
     *           /     \
     *         x         x     =>   |h|x|x|y|y|y|y|_|_|_|
     *       /   \     /   \
     *      /     \   /     \
     *     y       y y       y
     */

    public class Heap<T>
        where T : IComparable<T>
    {
        T[] _items;
        int _count;
        const int DEFAULT_LENGTH = 100;

        public Heap()
            : this(DEFAULT_LENGTH)
        {
        }

        public Heap(int length)
        {
            _count = 0;
            _items = new T[length];
        }

        public void Add(T item)
        {
            /*  Step:
             *  1.  Add to item to the last idx of array.
             *  2.  Create a loop to compare if at Index<item> and Index<Parent(item)>.
             *      If value item is bigger than its parent. We'll swap these 2 items.
             */

            // Growing array if it is necessary
            if (_count >= _items.Length)
            {
                GrowingBackingArray();
            }

            _items[_count] = item;
            int idx = _count;

            // Loop to compare value at 2 indexs (item and Parent(item))
            while (idx > 0 && _items[idx].CompareTo(_items[Parent(idx)]) > 0)
            {
                Swap(idx, Parent(idx));
                idx = Parent(idx);
            }

            _count++;
        }

        private void GrowingBackingArray()
        {
            T[] newItems = new T[_items.Length * 2];
            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
        }

        public T Peek()
        {
            if (_count == 0) throw new InvalidOperationException();
            return _items[0];
        }

        public T RemoveMax()
        {
            if (_count <= 0)
            {
                throw new InvalidOperationException();
            }

            T max = _items[0];

            _items[0] = _items[_count - 1];
            _count--;

            int idx = 0;

            while (idx < _count)
            {
                int left = (2 * idx) + 1;
                int right = (2 * idx) + 2;

                // If index reach the array's length, it break the loop. 
                // We just verify the left node, because left not exist => right not exist
                if (left >= _count) break;

                int maxChildIndex = IndexOfMaxChild(left, right);

                if (_items[idx].CompareTo(_items[maxChildIndex]) > 0)
                {
                    break;
                }

                Swap(idx, maxChildIndex);

                // Set index the max in order to continue verify the subtree
                idx = maxChildIndex;
            }

            return max;
        }

        private int IndexOfMaxChild(int left, int right)
        {
            int maxChildIdx = -1;
            if (right >= _count)
            {
                maxChildIdx = left;
            }
            else
            {
                maxChildIdx = _items[left].CompareTo(_items[right]) > 0 ? left : right;
            }
            return maxChildIdx;
        }

        public int Count => _count;

        public void Clear()
        {
            _count = 0;
            _items = new T[DEFAULT_LENGTH];
        }

        private int Parent(int idx) => (idx - 1) / 2;

        private void Swap(int left, int right)
        {
            T temp = _items[left];
            _items[left] = _items[right];
            _items[right] = temp;
        }
    }

    public class PriorityQueue<T> 
        where T : IComparable<T>
    {
        Heap<T> _heap = new Heap<T>();

        public void Enqueue(T value)
        {
            _heap.Add(value);
        }

        public T Dequeue() => _heap.RemoveMax();

        public void Clear()
        {
            _heap.Clear();
        }

        public int Count => _heap.Count;
    }


    // Todo: Add usage example to UNITTEST
}
