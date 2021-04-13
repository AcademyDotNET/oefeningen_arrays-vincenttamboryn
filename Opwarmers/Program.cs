using System;
using System.Collections.Generic;

namespace Opwarmers
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] truefalse = ArrayTrueFalse();
            PrintArray(truefalse);

        }
        static int[] Array1To10()
        {
            int[] getallen;
            getallen = new int[10];
            for (int i = 0; i < 10; i++)
            {
                getallen[i] = i + 1;
            }
            return getallen;
        }
        static int[] Array100To1()
        {
            int[] getallen;
            getallen = new int[100];
            for (int i = 0; i < 100; i++)
            {
                getallen[i] = 100 - i;
            }
            return getallen;
        }
        static char[] ArrayAToZ()
        {
            char[] letters = new char[26];
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = Convert.ToChar(97 + i);
            }
            return letters;
        }
        static int[] ArrayRandomNumbers()
        {
            Random generator = new Random();
            int[] numbers = new int[20];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = generator.Next(1,101);
            }
            return numbers;
        }
        static bool[] ArrayTrueFalse()
        {
            bool[] truefalse = new bool[30];
            for (int i = 0; i < truefalse.Length; i++)
            {
                if (i % 2 == 0)
                {
                    truefalse[i] = true;
                }
                else
                {
                    truefalse[i] = false;
                }
            }
            return truefalse;
        }
        static void PrintArray<T>(T[]array)
        {
            Console.Write(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                Console.Write($", {array[i]}");
            }
            Console.WriteLine();
        }
    }
}
