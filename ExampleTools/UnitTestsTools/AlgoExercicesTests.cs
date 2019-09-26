using AlgoExercices;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestsTools
{
    class TestsAlgoSect1
    {
        [TestCase("abadsadf", false)]
        [TestCase("abcde", true)]
        [TestCase("", true)]
        [TestCase("   ", false)]
        public void TestEx1_1(string input, bool expected)
        {
            Assert.That(Ex1_1.Checkv1(input), Is.EqualTo(expected));
            Assert.That(Ex1_1.Checkv2(input), Is.EqualTo(expected));
        }

        [TestCase("abcdef", "fedcba", true)]
        [TestCase("abcdef", "fedacbedcba", false)]
        [TestCase("abcde", "adfgasd", false)]
        [TestCase("", "  ", false)]
        [TestCase(" ", " ", true)]
        [TestCase("", "", true)]
        [TestCase("asdfasdf", "dfgh", false)]
        [TestCase("abcd", "abcddd", false)]
        public void TestEx2_1(string input1, string input2, bool expected)
        {
            Assert.That(Ex2_1.IsPermutationv1(input1, input2), Is.EqualTo(expected));
            Assert.That(Ex2_1.IsPermutationv2(input1, input2), Is.EqualTo(expected));
        }

        [TestCase("abc d efg h i j")]
        [TestCase("xyz abcd efg")]
        public void TestEx3_1(string input)
        {
            string expected = input.Replace(" ", "%20");
            char[] chars = new char[expected.Length];
            input.CopyTo(0, chars, 0, input.Length);

            Ex3_1.Urlify(chars);

            CollectionAssert.AreEqual(chars, expected);
        }

        [TestCase("aaaagbhhgb.", true)]
        [TestCase("aaahfihif", true)]
        [TestCase(".", true)]
        [TestCase("a.", true)]
        [TestCase("aasgbxdf.", false)]
        [TestCase("aasdhad.", false)]
        [TestCase("atzfcfbsfg.", false)]
        public void TestEx4_1(string input, bool expected)
        {
            Assert.That(Ex4_1.IsPalindromPermutationv1(input), Is.EqualTo(expected));
            Assert.That(Ex4_1.IsPalindromPermutationv2(input), Is.EqualTo(expected));
            Assert.That(Ex4_1.IsPalindromPermutationv3(input), Is.EqualTo(expected));
        }

        [TestCase("abcd", "abcd", true)]
        [TestCase("abcd", "abcdx", true)]
        [TestCase("abcd", "abc", true)]
        [TestCase("abcd", "abcdss", false)]
        [TestCase("abcd", "abcs", false)]
        [TestCase("abcd", "abacs", false)]
        [TestCase("abcd", "abc", true)]
        public void TestEx5_1(string s1, string s2, bool expected)
        {
            //Assert.That(Sec1Ex5.Check(s1, s2), Is.EqualTo(expected));
        }

        [TestCase("aaaaaaa", "a7")]
        [TestCase("a", "a")]
        [TestCase("abcdeff", "abcdeff")]
        [TestCase("aabbbcccd", "a2b3c3d1")]
        [TestCase("", "")]
        public void TestEx6_1(string intput, string expected)
        {
            Assert.That(Ex6_1.Compression(intput), Is.EqualTo(expected));
        }

        [Test]
        public void TestEx7_1()
        {
            int[,] matrixEx1 = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            int[,] matrixEx2 = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            int[,] expected = { { 13, 9, 5, 1 }, { 14, 10, 6, 2 }, { 15, 11, 7, 3 }, { 16, 12, 8, 4 } };
            Ex7_1.Rotate1(matrixEx1);
            Ex7_1.Rotate1(matrixEx2);
            Assert.That(matrixEx1, Is.EquivalentTo(expected));
            Assert.That(matrixEx2, Is.EquivalentTo(expected));
        }

        [Test]
        public void TestEx8_1()
        {
            int[,] matrix = { { 1, 2, 3, 4 }, { 0, 6, 7, 8 }, { 9, 10, 0, 12 } };
            Ex8_1.Zeroifyv2(matrix);
            int[,] expected = { { 0, 2, 0, 4 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            CollectionAssert.AreEqual(expected, matrix);
        }

        [Test]
        public void TestEx9_1()
        {

        }
    }

    class TestsAlgoSect2
    {
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 1, 2, 3, 4, 1, 2, 3, 2, 4 }, new int[] { 1, 2, 3, 4 })]
        public void TestEx1_2(int[] input, int[] expected)
        {
            {
                Node linkedList = LinkedListHelper.CreateIntLinkedList(input);
                Ex1_2.RemoveDuplicateWithBuffer(ref linkedList);
                int[] result_1 = LinkedListHelper.ToIntArray(linkedList);

                CollectionAssert.AreEqual(expected, result_1);
            }

            {
                Node linkedList = LinkedListHelper.CreateIntLinkedList(input);
                Ex1_2.RemoveDuplicate(ref linkedList);
                int[] result_1 = LinkedListHelper.ToIntArray(linkedList);

                CollectionAssert.AreEqual(expected, result_1);
            }
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 5, 6)]
        [TestCase(new int[] { 1, 2, 3, 23, 61, 83, 1, 4, 5 }, 7, 3)]
        [TestCase(new int[] { 1, 34, 64, 3, 5, 7, 4, 6, 23, 46 }, 1, 46)]
        [TestCase(new int[] { 1, 23, 52, 63, 7, 37, 8, 6, 10 }, 4, 37)]
        public void TestEx2_2(int[] input, int index, int expected)
        {
            Node linkedList = LinkedListHelper.CreateIntLinkedList(input);
            int res1 = Ex2_2.GetValueIntAtv1(linkedList, index);
            int res2 = Ex2_2.GetValueIntAtv2(linkedList, index);
            Assert.That(expected, Is.EqualTo(res1));
            Assert.That(expected, Is.EqualTo(res2));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 5, new int[] { 1, 2, 3, 4, 6, 7, 8, 9, 10 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 1, 2, 3, 23, 61, 83, 1, 4, 5 }, 83, new int[] { 1, 2, 3, 23, 61, 1, 4, 5 })]
        [TestCase(new int[] { 1, 34, 64, 3, 5, 7, 4, 6, 23, 46 }, 1, new int[] { 34, 64, 3, 5, 7, 4, 6, 23, 46 })]
        [TestCase(new int[] { 1, 23, 52, 63, 7, 37, 8, 6, 10 }, 10, new int[] { 1, 23, 52, 63, 7, 37, 8, 6 })]
        public void TestEx3_2(int[] input, int value, int[] expected)
        {
            Node listEx2 = LinkedListHelper.CreateIntLinkedList(input);
            Ex3_2.Removev1(ref listEx2);

            int[] result = LinkedListHelper.ToIntArray(listEx2);
            CollectionAssert.AreEqual(result, expected);
        }

        [TestCase(new int[] { 3, 5, 12, 4, 7, 1, 13 }, 6, new int[] { 3, 5, 4, 1 }, new int[] { 12, 7, 13 })]
        [TestCase(new int[] { 3, 5, 12, 4, 7, 1, 13 }, 10, new int[] { 3, 5, 4, 7, 1 }, new int[] { 12, 13 })]
        [TestCase(new int[] { 3, 5, 12, 4, 7, 1, 13 }, 0, new int[] { 3, 5, 12, 4, 7, 1, 13 }, new int[] { })]
        [TestCase(new int[] { 3, 5, 12, 4, 7, 1, 13 }, 15, new int[] { }, new int[] { 3, 5, 12, 4, 7, 1, 13 })]
        public void TestEx4_2(int[] input, int pivot, int[] smallerArr, int[] biggerArr)
        {
            {
                Node head = LinkedListHelper.CreateIntLinkedList(input);
                Ex4_2.Partition_v1(ref head, pivot);
                Node iterator = head;
                int countSmaller = 0;
                int countBigger = 0;
                while (iterator != null)
                {
                    if (iterator.Value >= pivot)
                    {
                        countSmaller++;
                        Assert.That(biggerArr.Contains(iterator.Value));
                    }
                    else
                    {
                        countBigger++;
                        Assert.That(smallerArr.Contains(iterator.Value));
                    }
                    iterator = iterator.Next;
                }
                Assert.That(smallerArr.Length == countSmaller);
                Assert.That(biggerArr.Length == countBigger);
            }

            {
                Node head = LinkedListHelper.CreateIntLinkedList(input);
                Ex4_2.Partition_v2(ref head, pivot);
                Node iterator = head;
                int countSmaller = 0;
                int countBigger = 0;
                while (iterator != null)
                {
                    if (iterator.Value >= pivot)
                    {
                        countSmaller++;
                        Assert.That(biggerArr.Contains(iterator.Value));
                    }
                    else
                    {
                        countBigger++;
                        Assert.That(smallerArr.Contains(iterator.Value));
                    }
                    iterator = iterator.Next;
                }
                Assert.That(smallerArr.Length == countSmaller);
                Assert.That(biggerArr.Length == countBigger);
            }
        }

        [TestCase(new int[] { 2, 3, 4 }, new int[] { 1, 2, 5 }, new int[] { 3, 5, 9 }, new int[] { 3, 5, 9 })]
        [TestCase(new int[] { 2, 3, 4, 2 }, new int[] { 1, 2, 5, 3 }, new int[] { 3, 5, 9, 5 }, new int[] { 3, 5, 9, 5 })]
        [TestCase(new int[] { 2, 3, 4 }, new int[] { 1, 2, 5, 9 }, new int[] { 3, 5, 9, 9 }, new int[] { 1, 4, 9, 3 })]
        [TestCase(new int[] { 2, 3, 4 }, new int[] { 2, 5 }, new int[] { 4, 8, 4 }, new int[] { 2, 5, 9 })]
        public void TestEx5_2(int[] input1, int[] input2, int[] expected1, int[] expected2)
        {
            Node list1 = LinkedListHelper.CreateIntLinkedList(input1);
            Node list2 = LinkedListHelper.CreateIntLinkedList(input2);

            Node result1_1 = Ex5_2.Addition1_v1(list1, list2);
            Node result2_1 = Ex5_2.Addition2_v1(list1, list2);
            CollectionAssert.AreEqual(LinkedListHelper.ToIntArray(result1_1), expected1);
            CollectionAssert.AreEqual(LinkedListHelper.ToIntArray(result2_1), expected2);

            Node result1_2 = Ex5_2.Addition1_v2(list1, list2);
            Node result2_2 = Ex5_2.Addition2_v2(list1, list2);
            CollectionAssert.AreEqual(LinkedListHelper.ToIntArray(result1_2), expected1);
            CollectionAssert.AreEqual(LinkedListHelper.ToIntArray(result2_2), expected2);
        }

        [TestCase(new int[] { 1, 3, 5, 8, 7, 8, 5, 3, 1 }, true)]
        [TestCase(new int[] { 12, 55, 33, 88, 44, 22, 66 }, false)]
        [TestCase(new int[] { 6, 3, 25, 456, 84, 2 }, false)]
        [TestCase(new int[] { 1, 2, 3, 4, 4, 3, 2, 1 }, true)]
        public void TestEx6_2(int[] input, bool expected)
        {
            Node list = LinkedListHelper.CreateIntLinkedList(input);
            bool result = Ex6_2.IsPalindrome(list);
            Assert.That(expected, Is.EqualTo(result));
        }

        [TestCase(new int[] { 1, 3, 5, 8, 7, 6, 2 }, new int[] { 1, 5, 7, 6, 11 }, new int[] { 1, 5, 7, 6 })]
        [TestCase(new int[] { 5, 9, 4, 3 }, new int[] { 5, 2, 3, 6, 9 }, new int[] { 5, 9 })]
        [TestCase(new int[] { 1 }, new int[] { 2, 6, 9, 8 }, null)]
        [TestCase(new int[] { 1, 2, 3, 4, 4, 3, 2, 1 }, new int[] { 1, 3, 5, 8, 7, 8, 5, 3, 1 }, new int[] { 1, 3, 3, 1 })]
        public void TestEx7_2(int[] input1, int[] input2, int[] expected)
        {
            Node list1 = LinkedListHelper.CreateIntLinkedList(input1);
            Node list2 = LinkedListHelper.CreateIntLinkedList(input2);
            int[] resultInt = LinkedListHelper.ToIntArray(Ex7_2.GetIntersection(list1, list2));
            CollectionAssert.AreEqual(resultInt, expected);
        }
    }
}
