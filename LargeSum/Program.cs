using System;

namespace LargeSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Random mygen = new Random();
            int[] toAdd = new int[50];
            for (int i = 0; i < 50; i++)
            {
                toAdd[i] = mygen.Next(0, 20);
            }
            LargeSum(toAdd);
        }
        public static void LargeSum(params int[] numbers)
        {
            int sum = numbers[0];
            Console.Write($"the sum {numbers[0]}");
            for (int i = 1; i < numbers.Length; i++)
            {
                sum += numbers[i];
                Console.Write($" + {numbers[i]}");
            }
            Console.WriteLine($" equals {sum}");
        }
    }
}