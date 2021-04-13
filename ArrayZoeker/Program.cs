using System;

namespace ArrayZoeker
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayInitieel = InitialiseArray(10);

            Console.WriteLine("these are the values in the initial array");
            PrintArray(arrayInitieel);

            Console.WriteLine("Which value would you like to delete in the array?");
            string deleted = Console.ReadLine();
            ArrayValueDeleter(deleted , arrayInitieel);

            Console.WriteLine($"These are the values in the array, now that we have deleted {deleted}");
            PrintArray(arrayInitieel);
        }
        static string[] InitialiseArray(int size)
        {
            string[] array = new string[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"give the value you want at index {i} in the array");
                array[i] = Console.ReadLine();
            }
            return array;
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
        static void ArrayValueDeleter(string delete, string[] array)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == delete)
                {
                    for (int j = i; j < array.Length; j++)
                    {
                        if (j == array.Length - 1)
                        {
                            array[j] = "-1";
                        }
                        else
                        {
                            array[j] = array[j + 1];
                        }

                    }
                    return;
                }
        }
    }
}
