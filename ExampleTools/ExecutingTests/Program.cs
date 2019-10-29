using System;

namespace ExecutingTests
{
    class Program
    {

        static void Main(string[] args)
        {
            TestBreak();
        }

        static void TestBreak()
        {
            Random _rand = new Random();
            while(true)
            {
                int rand = _rand.Next();
                if (rand % 2 == 0)
                {
                    break;
                }

                Console.WriteLine(rand);
            }
        }


        static int PickRandomLevel()
        {
            Random _rand = new Random();
            int rand = 25;
            Console.WriteLine(rand >>= 1);
            int _levels = 0;
            int level = 0;

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
    }
}
