using System;

namespace ArrayOefener2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arrayA = InitialiseArray(5);
            Console.WriteLine("array A is complete, now array B");
            double[] arrayB = InitialiseArray(5);
            double[] arrayC = ArrayAdder(arrayA, arrayB);
            Console.Write("arrayC contains the following values ");
            PrintArray(arrayC);
        }
        static double[] InitialiseArray(int size)
        {
            double[] array = new double[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"give the number you want at index {i} in the array");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            return array;
        }
        static double[] ArrayAdder(double[] array1, double[] array2)
        {
            double[] array3 = new double[array1.Length];
            if (array1.Length != array2.Length)
            {
                Console.WriteLine("These arrays aren't the same size");
                return array3;
            }
            else
            {
                for (int i = 0; i < array1.Length; i++)
                {
                    array3[i] = array2[i] + array1[i];
                }
                return array3;
            }
            
        }
        static void PrintArray<T>(T[] array)
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
