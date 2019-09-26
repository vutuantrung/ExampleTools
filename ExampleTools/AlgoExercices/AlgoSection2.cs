﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoExercices
{
    public class Ex1_2
    {
        public static void RemoveDuplicate(Node list)
        {
            if (list != null)
            {
                Node iterator1 = list;
                while (iterator1._next != null)
                {
                    Node iterator2 = iterator1.Next;
                    while (iterator2.Next != null)
                    {
                        Node prevNode = null;

                        if (IsDuplicate(iterator1, iterator2))
                        {
                            if (iterator2 == iterator1.Next)
                            {
                                prevNode = iterator1;
                            }
                            // Detele node
                            prevNode.Next = iterator2.Next;
                        }
                        else
                        {
                            prevNode = iterator2;
                        }
                        iterator2 = iterator2.Next;
                    }
                    iterator1 = iterator1.Next;
                }
            }
        }

        public static bool IsDuplicate(Node e1, Node e2)
        {
            return e1._value == e2._value;
        }

        public static void RemoveDuplicateWithBuffer(Node list)
        {
            int count = 0;
            List<int> intList = new List<int>();
            Node iterator = list;
            while (iterator != null)
            {
                if (intList.Contains(iterator.Value))
                {
                    LinkedListHelper.DeleteNodeAtIndex(ref list, count);
                }
                else
                {
                    intList.Add(iterator.Value);
                    count++;
                }
                iterator = iterator.Next;
            }
        }
    }

    public class Ex2_2
    {
        public static int GetValueIntAtv1(Node head, int idx)
        {
            Node ref1 = head;
            if (idx < LinkedListHelper.GetLinkedListLength(head))
            {
                for (int i = 0; i < idx; i++) ref1 = ref1.Next;
                Node ref2 = head;
                while (ref1 != null)
                {
                    ref1 = ref1.Next;
                    ref2 = ref2.Next;
                }
                return ref2.Value;
            }
            return 0;
        }

        public static int GetValueIntAtv2(Node head, int idx)
        {
            int listLength = LinkedListHelper.GetLinkedListLength(head);
            if (idx < LinkedListHelper.GetLinkedListLength(head))
            {
                Node iterator = head;

                int count = listLength - idx;
                for (int i = 0; i < count; i++)
                {
                    iterator = iterator.Next;
                }
                return iterator.Value;
            }
            return 0;
        }
    }

    public class Ex3_2
    {
        public static void Removev1(Node item)
        {
            while (item.Next.Next != null)
            {
                item.Value = item.Next.Value;
                item = item.Next;
            }

            item.Value = item.Next.Value;
            item.Next = null;
        }

        public static void Removev2(ref Node head, int value)
        {
            int idx = 0;
            Node iterator = head;
            while (iterator != null)
            {
                if (iterator.Value == value)
                {
                    LinkedListHelper.DeleteNodeAtIndex(ref head, idx);
                }
                else
                {
                    idx++;
                }
                iterator = iterator.Next;
            }
        }
    }

    public class Ex4_2
    {
        public static void Partition(ref Node list, int pivot)
        {
            List<int> lowerValuesList = new List<int>();
            List<int> greaterValuesList = new List<int>();
            List<int> resultList = new List<int>();
            if (list != null)
            {
                Node iterator = list;
                int count = 0;
                while (iterator != null)
                {
                    if (iterator.Value >= pivot)
                    {
                        greaterValuesList.Add(iterator.Value);
                    }
                    else
                    {
                        lowerValuesList.Add(iterator.Value);
                    }
                    iterator = iterator.Next;
                }
                resultList = lowerValuesList.Concat(greaterValuesList).ToList();
                list = null;
                Node iterator2 = list;
                while (count < resultList.Count)
                {
                    if (iterator2 == null)
                    {
                        iterator2 = new Node(resultList[count]);
                        list = iterator2;
                    }
                    else
                    {
                        iterator2.Next = new Node(resultList[count]);
                        iterator2 = iterator2.Next;
                    }
                    count++;
                }
            }
        }
    }

    public class Ex5_2
    {
        public static Node Addition1(Node list1, Node list2)
        {
            Node result = null;
            Node iterator = result;
            int[] arr1 = LinkedListHelper.ToIntArray(list1);
            int[] arr2 = LinkedListHelper.ToIntArray(list2);
            int resultInt = ConvertToIntV1(arr1) + ConvertToIntV1(arr2);

            char[] intArr = resultInt.ToString().ToCharArray();

            for (int i = intArr.Length - 1; i >= 0; i--)
            {
                if (iterator == null)
                {
                    iterator = new Node(int.Parse(intArr[i].ToString()));
                    result = iterator;
                }
                else
                {
                    iterator.Next = new Node(int.Parse(intArr[i].ToString()));
                    iterator = iterator.Next;
                }
            }
            return result;
        }

        public static Node Addition2(Node list1, Node list2)
        {
            Node result = null;
            Node iterator = result;
            int[] arr1 = LinkedListHelper.ToIntArray(list1);
            int[] arr2 = LinkedListHelper.ToIntArray(list2);
            int resultInt = ConvertToIntV2(arr1) + ConvertToIntV2(arr2);

            char[] intArr = resultInt.ToString().ToCharArray();

            for (int i = 0; i < intArr.Length; i++)
            {
                if (iterator == null)
                {
                    iterator = new Node(int.Parse(intArr[i].ToString()));
                    result = iterator;
                }
                else
                {
                    iterator.Next = new Node(int.Parse(intArr[i].ToString()));
                    iterator = iterator.Next;
                }
            }
            return result;
        }

        public static int ConvertToIntV1(int[] arr)
        {
            if (arr.Length > 0)
            {
                string value = string.Empty;
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    value += arr[i];
                }
                return int.Parse(value);
            }
            return 0;
        }

        public static int ConvertToIntV2(int[] arr)
        {
            if (arr.Length > 0)
            {
                string value = string.Empty;
                for (int i = 0; i < arr.Length; i++)
                {
                    value += arr[i];
                }
                return int.Parse(value);
            }
            return 0;
        }
    }

    public class Ex6_2
    {
        public static bool IsPalindrome(Node list)
        {
            if (list != null)
            {
                if (list.Next == null)
                {
                    return true;
                }
                else
                {
                    Node iterator = list;
                    int linkedListLength = LinkedListHelper.GetLinkedListLength(list);
                    //Stack<int> intStack = new Stack<int>();
                    int[] intStack = new int[linkedListLength / 2];
                    int count = 0, i = -1;
                    bool paired = linkedListLength % 2 == 0;
                    if (paired)
                    {
                        while (iterator != null)
                        {
                            if (count >= linkedListLength / 2)
                            {
                                if (intStack[i] != iterator.Value)
                                {
                                    return false;
                                }
                                else
                                {
                                    i--;
                                }
                            }
                            else
                            {
                                intStack[count] = iterator.Value;
                                count++;
                                i++;
                            }
                            iterator = iterator.Next;
                        }
                        return true;
                    }
                    else
                    {
                        bool first = true;
                        while (iterator != null)
                        {
                            if (count >= linkedListLength / 2)
                            {
                                if (first)
                                {
                                    first = false;
                                }
                                else
                                {
                                    if (intStack[i] != iterator.Value)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        i--;
                                    }
                                }
                            }
                            else
                            {
                                intStack[count] = iterator.Value;
                                count++;
                                i++;
                            }
                            iterator = iterator.Next;
                        }
                        return true;
                    }
                }
            }
            return false;
        }
    }

    public class Ex7_2
    {
        public static Node GetIntersection(Node list1, Node list2)
        {
            if (list1 != null && list2 != null)
            {
                int length1 = LinkedListHelper.GetLinkedListLength(list1);
                int length2 = LinkedListHelper.GetLinkedListLength(list2);
                Node iterator1 = list1;
                Node iterator2 = list2;
                Node result = null;
                Node iterator3 = result;
                if (length1 <= length2)
                {
                    while (iterator1 != null)
                    {
                        iterator2 = list2;
                        while (iterator2 != null)
                        {
                            if (iterator1.Value == iterator2.Value)
                            {
                                if (iterator3 == null)
                                {
                                    iterator3 = new Node(iterator1.Value);
                                    result = iterator3;
                                }
                                else
                                {
                                    iterator3.Next = new Node(iterator1.Value);
                                    iterator3 = iterator3.Next;
                                }
                                iterator2 = iterator2.Next;
                                list1 = iterator1;
                                list2 = iterator2;
                                break;
                            }
                            iterator2 = iterator2.Next;
                        }
                        iterator1 = iterator1.Next;
                    }
                    return result;
                }
                else
                {
                    while (iterator2 != null)
                    {
                        iterator1 = list1;
                        while (iterator1 != null)
                        {
                            if (iterator1.Value == iterator2.Value)
                            {
                                if (iterator3 == null)
                                {
                                    iterator3 = new Node(iterator1.Value);
                                    result = iterator3;
                                }
                                else
                                {
                                    iterator3.Next = new Node(iterator1.Value);
                                    iterator3 = iterator3.Next;
                                }
                                iterator1 = iterator1.Next;
                                list1 = iterator1;
                                list2 = iterator2;
                                break;
                            }
                            iterator1 = iterator1.Next;
                        }
                        iterator2 = iterator2.Next;
                    }
                    return result;
                }
            }
            return null;
        }
    }
}