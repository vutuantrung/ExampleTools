using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Part1
{
    public class Sort<T> where T : IComparable<T>
    {
        T[] _items;

        public Sort(T[] items)
        {
            _items = items;
        }

        /*  Bubble Sort
         *  Complexity:
         *            Best case       Average case        Worst case
         *  Time         O(n)            O(n^2)              O(n^2)
         *  Space        O(1)            O(1)                O(1)
         * 
         *  Illusion:
         *  
         *  Step 1:
         *  3   7   4   4   6   5   8   =>  3   7   4   4   6   5   8
         *  |   |
         *  -----
         *  
         *  Step 2:
         *  3   7   4   4   6   5   8   =>  3   4   7   4   6   5   8
         *      |   |
         *      -----
         *      
         *  Step 3:
         *  3   4   7   4   6   5   8   =>  3   4   4   7   6   5   8
         *          |   |
         *          -----
         *          
         *  Step 4:
         *  3   4   4   7   6   5   8   =>  3   4   4   6   7   5   8
         *              |   |
         *              -----
         *  continue until: 3   4   4   6   5   7   8
         */
        #region Bubble Sort
        public T[] BubbleSort(T[] items)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < items.Length; i++)
                {
                    if (items[i - 1].CompareTo(items[i]) > 0)
                    {
                        Swap(items, i - 1, i);
                        swapped = true;
                    }
                }
            } while (swapped != false);

            return items;
        }

        private void Swap(T[] items, int left, int right)
        {
            if (left != right)
            {
                T temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }
        #endregion


        /*  Insertion Sort
         *  Complexity:
         *            Best case       Average case        Worst case
         *  Time         O(n)            O(n^2)              O(n^2)
         *  Space        O(1)            O(1)                O(1)
         *  
         *  Illusion:
         *  a: Index insert at;
         *  f: Index insert from;
         *  
         *  Step 1:
         *  a       f
         *  5   6   3   1   8   7   2   4 => Insert 3 to 5, then replace 5, 6 to the the right
         *  |       |
         *  ---------
         *  3   5   6   1   8   7   2   4
         *  -------->
         *  
         *  Step 2:
         *  a           f
         *  3   5   6   1   8   7   2   4 => Insert 1 to 3, then replace 3, 5, 6 to the right
         *  |           |
         *  -------------
         *  1   3   5   6   8   7   2   4
         *  ------------>
         *  
         *  Step 3:
         *                  a   f   
         *  1   3   5   6   8   7   2   4 => Insert 7 to 8, then replace 8 to the right
         *                  |   |
         *                  -----
         *  1   3   5   6   7   8   2   4
         *                  ---->
         *       
         *  Step 4:
         *      a                   f
         *  1   3   5   6   7   8   2   4 => Insert 2 to 3, then repalce 3, 5, 6, 7, 8 to the right
         *      |                   |
         *      ---------------------
         *  1   2   3   4   5   6   8   4
         *      -------------------->
         * **/
        #region Insertion Sort
        public T[] InsertionSort(T[] items)
        {
            int sortedRangeEndIndex = 1;
            while (sortedRangeEndIndex < items.Length)
            {
                if (items[sortedRangeEndIndex].CompareTo(items[sortedRangeEndIndex - 1]) < 0)
                {
                    int insertIdx = FindInsertionIndex(items, items[sortedRangeEndIndex]);
                    Insert(items, insertIdx, sortedRangeEndIndex);
                }
                sortedRangeEndIndex++;
            }
            return items;
        }

        private int FindInsertionIndex(T[] items, T valueToInsert)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].CompareTo(valueToInsert) > 0)
                {
                    return i;
                }
            }

            throw new InvalidOperationException("The insertion index was not found.");
        }

        private void Insert(T[] itemArr, int idxInsertingAt, int idxInsertingFrom)
        {
            T temp = itemArr[idxInsertingAt];

            itemArr[idxInsertingAt] = itemArr[idxInsertingFrom];

            for (int i = idxInsertingAt + 1; i <= idxInsertingFrom; i++)
            {
                itemArr[i + 1] = itemArr[i];
            }

            itemArr[idxInsertingAt + 1] = temp;
        }
        #endregion


        /*  Selection Sort
         *  Complexity:
         *            Best case       Average case        Worst case
         *  Time         O(n)            O(n^2)              O(n^2)
         *  Space        O(1)            O(1)                O(1)
         * 
         *  Illusion:
         *  i: Current index
         *  s: Smallest value
         *  
         *  i-----------s--------------->
         *  |           |
         *  5   6   3   1   8   7   2   4   =>  From i to items.Length, smallest value s is 1, swap s and i
         *  1   6   3   5   8   7   2   4   =>  Increment i
         *  
         *      i-------------------s--->
         *      |                   |
         *  1   6   3   5   8   4   2   4   =>  From i to items.Length, smallest value s is 2, swap s and i
         *  1   2   3   5   8   4   6   4   =>  Increment i
         *  
         *          i------------------->
         *          |
         *  1   2   3   5   8   4   6   4   =>  From i to items.Length, smallest value s is already at index i
         *  
         *              i-------s------->
         *              |       |
         *  1   2   3   5   8   4   6   4   =>  From i to items.Length, smallest value s is 2, swap s and i
         *  1   2   3   4   8   5   6   4   =>  Increment i
         *  
         *                  i-----------s
         *                  |           |
         *  1   2   3   4   8   5   6   4   =>  From i to items.Length, smallest value s is 4, swap s and i
         *  1   2   3   4   4   5   6   8   =>  Increment i
         *  
         *  continue and we do not change all items because it is sorted
         * **/
        #region Selection Sort
        public T[] SelectionSort(T[] items)
        {
            int sortedRangeEnd = 0;

            while(sortedRangeEnd < items.Length)
            {
                int nextIndex = FindIndexOfSamaillestValue(items, sortedRangeEnd);
                Swap(items, sortedRangeEnd, nextIndex);

                sortedRangeEnd++;
            }
            return items;
        }

        private int FindIndexOfSamaillestValue(T[] items, int sortedRangeEnd)
        {
            T smallestValue = items[sortedRangeEnd];
            int smallestValueIdx = sortedRangeEnd;

            for(int i = 0; i < items.Length; i++)
            {
                if(smallestValue.CompareTo(items[i]) < 0)
                {
                    smallestValue = items[i];
                    smallestValueIdx = i;
                }
            }

            return smallestValueIdx;
        }
        #endregion


        /*  Merge Sort
         *  Complexity:
         *            Best case       Average case        Worst case
         *  Time         O(nlog(n))     O(nlog(n))          O(nlog(n))
         *  Space        O(n)           O(n)                O(n)
         * 
         * 
         * 
         * 
         * 
         * **/

        #region Merge Sort


        #endregion

    }
}
