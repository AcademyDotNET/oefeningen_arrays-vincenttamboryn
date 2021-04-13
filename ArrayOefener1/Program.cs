using System;

namespace ArrayOefener1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array;
            array = InitialiseArray(10);
            double som = SomArray(array);
            double mean = MeanArray(array);
            double largest = LargestInArray(array);
            Console.WriteLine($"The sum of all the numbers in the array is {som}\nThe mean of all the numbers in the array is {mean}\nThe largest number in the array is {largest}");
            Console.WriteLine("Type a number, I'll show you all numbers in the array that are equal to or larger than this number");
            double largeNumber = Convert.ToDouble(Console.ReadLine());
            NumbersLargerThan(array, largeNumber);
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
        static double SomArray(double[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
        static double MeanArray(double[] array)
        {
            double sum = SomArray(array);
            return (sum/array.Length);
        }
        static double LargestInArray(double[] array)
        {
            double[] arrayCopy = new double[array.Length] ;
            Array.Copy(array , 0 , arrayCopy , 0 , array.Length);
            Array.Sort(arrayCopy);
            return arrayCopy[arrayCopy.Length-1];
        }
        static void NumbersLargerThan(double[]array, double largeNumber)
        {
            string lineToWrite = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > largeNumber)
                {
                    lineToWrite += $"{array[i]} ";
                }
            }
            if (lineToWrite == "")
            {
                Console.WriteLine($"There is no number larger than {largeNumber} in the array");
            }
            else
            {
                Console.WriteLine($"{lineToWrite} are larger than {largeNumber}");
            }
        }
    }
}
