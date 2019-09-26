using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoExercices
{
    public class Ex1_1
    {
        public static bool Checkv1(string s)
        {
            HashSet<char> seenCharacters = new HashSet<char>();
            foreach (char c in s)
            {
                if (seenCharacters.Contains(c)) return false;
                seenCharacters.Add(c);
            }
            return true;
        }

        public static bool Checkv2(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i] == s[j]) return false;
                }
            }
            return true;
        }
    }

    public class Ex2_1
    {
        public static bool IsPermutationv1(string s1, string s2) //Order characters in strings and compare this 2 strings
        {
            if (s1.Length != s2.Length) return false;
            return string.Concat(s1.OrderBy(c => c)) == string.Concat(s2.OrderBy(c => c));
        }

        public static bool IsPermutationv2(string s1, string s2) //Calculate number of characters
        {
            if (s1.Length != s2.Length) return false;
            Dictionary<char, int> s1Frequency = StringHelper.Frequency(s1);

            foreach (char c in s2)
            {
                int n;
                if (!s1Frequency.TryGetValue(c, out n) || n == 0) return false;
                s1Frequency[c]--;
            }
            return true;
        }
    }

    public class Ex3_1
    {
        public static void Urlify(char[] input)
        {
            int whitespaceCount = 0;
            int count = 0;
            foreach (char c in input)
            {
                if (c == 0) break;
                if (char.IsWhiteSpace(c)) whitespaceCount++;
                count++;
            }

            if (whitespaceCount == 0) return;

            for (int i = count - 1; i >= 0; i--)
            {
                if (char.IsWhiteSpace(input[i]))
                {
                    input[i + whitespaceCount * 2 - 2] = '%';
                    input[i + whitespaceCount * 2 - 1] = '2';
                    input[i + whitespaceCount * 2] = '0';
                    whitespaceCount--;
                }
                else
                {
                    input[i + whitespaceCount * 2] = input[i];
                }
            }
        }
    }

    public class Ex4_1
    {
        public static bool IsPalindromPermutationv1(string s)
        {
            Dictionary<char, int> Frequency = new Dictionary<char, int>();
            bool hadCenter = false;
            s = s.Replace(".", "");
            foreach (char c in s)
            {
                int n;
                if (Frequency.TryGetValue(c, out n)) Frequency[c]++;
                else Frequency[c] = 1;
            }

            foreach (KeyValuePair<char, int> entry in Frequency)
            {
                if (entry.Value % 2 != 0)
                {
                    if (!hadCenter)
                    {
                        hadCenter = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool IsPalindromPermutationv2(string s)
        {
            s = s.Replace(".", "");
            return s.GroupBy(c => c).Count(c => c.Count() % 2 == 1) <= 1;
        }

        public static bool IsPalindromPermutationv3(string s)
        {
            s = s.Replace(".", "");
            var frequency = StringHelper.Frequency(s);
            int oddFound = 0;
            foreach (int count in frequency.Values)
            {
                if (count % 2 != 0 && ++oddFound == 2) return false;
            }
            return true;
        }
    }

    public class Ex5_1
    {
        public static bool Check(string s1, string s2)
        {
            if (s1 == s2) return true;
            if (Math.Abs(s1.Length - s2.Length) > 1) return false;

            if (s1.Length == s2.Length)
            {
                int diff = 0;
                for (int i = 0; i < s1.Length; i++)
                {
                    if (s1[i] != s2[i] && ++diff > 1) return false;
                }
                return true;
            }

            if (s2.Length > s1.Length)
            {
                string tmp = s1;
                s1 = s2;
                s2 = tmp;
            }

            int offset = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (i == s1.Length && offset == 0) return true;
                if (s1[i] != s2[i + offset] && offset-- != 0) return false;
            }
            return true;
        }
    }

    public class Ex6_1
    {
        public static string Compression(string input)
        {
            string newValue = string.Empty;
            var frequency = StringHelper.Frequency(input);

            if (input.Length < 2) return input;

            foreach (KeyValuePair<char, int> entry in frequency)
            {
                newValue += entry.Key.ToString() + entry.Value.ToString();
            }

            if (newValue.Length < input.Length) return newValue;
            return input;
        }
    }

    public class Ex7_1
    {
        public static void Rotate1(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            int[,] result = new int[size, size];

            for (int line = 0; line < size; line++)
            {
                for (int col = 0; col < size; col++)
                {
                    result[col, size - line - 1] = matrix[line, col];
                }
            }
            Array.Copy(result, matrix, result.Length);
        }

        public static void Rotate2(int[,] matrix)
        {
            int mWidth = matrix.GetLength(1);
            int mHeight = matrix.GetLength(0);

            int[,] newT = new int[mWidth, mHeight];
            for (int i = mHeight - 1; i >= 0; i--)
            {
                for (int j = 0; j < mWidth; j++)
                {
                    newT[j, mHeight - 1 - i] = matrix[i, j];
                }
            }
        }
    }

    public class Ex8_1
    {
        public static void Zeroify(int[,] input)
        {
            int height = input.GetLength(0);
            int width = input.GetLength(1);

            HashSet<int> lineContainingZero = new HashSet<int>();
            HashSet<int> columnsContainingZero = new HashSet<int>();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (input[i, j] == 0)
                    {
                        if (!columnsContainingZero.Contains(i)) columnsContainingZero.Add(i);
                        if (!lineContainingZero.Contains(i)) columnsContainingZero.Add(j);
                    }
                }
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (lineContainingZero.Contains(j) || columnsContainingZero.Contains(i))
                    {
                        input[i, j] = 0;
                    }
                }
            }
        }

        public static void Zeroifyv2(int[,] input)
        {
            int rows = input.GetLength(0);
            int columns = input.GetLength(1);
            bool lineHasZero = false;

            List<int> columnsContainingZero = new List<int>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (input[i, j] == 0)
                    {
                        columnsContainingZero.Add(j);
                        lineHasZero = true;
                    }
                }
                if (lineHasZero)
                {
                    SetLineZero(input, i);
                    lineHasZero = false;
                }
            }

            int count = 0;
            while (count < columnsContainingZero.Count)
            {
                SetColumnZero(input, columnsContainingZero[count]);
                count++;
            }
        }

        private static void SetLineZero(int[,] input, int index)
        {
            int columns = input.GetLength(1);

            for (int i = 0; i < columns; i++)
            {
                input[index, i] = 0;
            }
        }

        private static void SetColumnZero(int[,] input, int index)
        {
            int rows = input.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                input[i, index] = 0;
            }
        }
    }

    public class Ex9_1
    {
        public static bool IsSubString(string s1, string s2)
        {
            return s1.Contains(s2);
        }

        public static bool IsRotationString(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;
            return IsSubString(s1 + s1, s2);
        }
    }
}
