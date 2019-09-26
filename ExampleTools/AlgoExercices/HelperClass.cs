using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoExercices
{
    public static class StringHelper
    {
        public static Dictionary<char, int> Frequency(string s)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();
            foreach (char c in s)
            {
                int n;
                if (result.TryGetValue(c, out n)) result[c] = n + 1;
                else result[c] = 1;
            }
            return result;
        }
    }

    public static class LinkedListHelper
    {
        public static Node CreateIntLinkedList(int[] datas)
        {
            Node list = null;
            Node iterator = null;
            if (datas.Length > 0)
            {
                for (int i = 0; i < datas.Length; i++)
                {
                    Node newN = new Node(datas[i]);
                    if (i == 0)
                    {
                        list = newN;
                        iterator = list;
                    }
                    else
                    {
                        iterator.Next = newN;
                        iterator = iterator.Next;
                    }
                }
            }
            return list;
        }

        public static Node SearchNode(Node list, int value)
        {
            while (list.Next != null && list.Value != value)
            {
                list = list.Next;
            }

            return list;
        }

        public static Node InsertHeadNode(Node list, Node node)
        {
            node.Next = list;
            list = node;
            return list;
        }

        public static Node InsertHeadNode(Node list, int value)
        {
            Node newHead = new Node(value);
            newHead.Next = list;
            list = newHead;
            return list;
        }

        public static Node InsertLastNode(Node list, Node node)
        {
            Node iterator = list;
            if (iterator == null)
            {
                list = node;
            }
            else
            {
                while (iterator.Next != null)
                {
                    iterator = iterator.Next;
                }
                iterator.Next = node;
            }
            return list;
        }

        public static Node InsertLastNode(Node list, int value)
        {
            Node node = new Node(value);
            Node iterator = list;
            if (iterator == null)
            {
                list = node;
            }
            else
            {
                while (iterator.Next != null)
                {
                    iterator = iterator.Next;
                }
                iterator.Next = node;
            }
            return list;
        }

        public static void DeleteFirstNode(ref Node list)
        {
            Node iterator = list;
            if (list.Next != null)
            {
                list = list.Next;
            }
            else
            {
                list = null;
            }
            iterator.Next = null;
        }

        public static void DeleteLastNode(ref Node list)
        {
            Node iterator = list;
            if (iterator.Next != null)
            {
                while (iterator.Next.Next != null)
                {
                    iterator = iterator.Next;
                }
                iterator.Next = null;
            }
        }

        public static void DeleteNodeAt(ref Node list, int index)
        {
            int count = 0;
            Node iterator = list;
            while (count < index - 1)
            {
                iterator = iterator.Next;
                count++;
            }
            iterator.Next = iterator.Next.Next;
        }

        public static void DeleteNodeAtIndex(ref Node list, int index)
        {
            int linkedListLength = GetLinkedListLength(list);
            if (list != null && index < linkedListLength)
            {
                if (index == 0)
                {
                    DeleteFirstNode(ref list);
                }
                else if (index == linkedListLength - 1)
                {
                    DeleteLastNode(ref list);
                }
                else
                {
                    DeleteNodeAt(ref list, index);
                }
            }
        }

        public static int GetLinkedListLength(Node list)
        {
            int count = 1;
            while (list.Next != null)
            {
                count++;
                list = list.Next;
            }

            return count;
        }

        public static int[] ToIntArray(Node list)
        {
            if (list != null)
            {
                List<int> listReturn = new List<int>();
                Node iterator = list;
                while (iterator != null)
                {
                    listReturn.Add(iterator.Value);
                    iterator = iterator.Next;
                }
                return listReturn.ToArray();
            }
            return null;
        }
    }
}
