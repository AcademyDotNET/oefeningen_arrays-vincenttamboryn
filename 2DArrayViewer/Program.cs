using System;

namespace _2DArrayViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] matrix1 = { {1 , 2 , 1 },
                                  {3 , 1 , 0 },
                                  {2 , 2 , 3 } };
            Arrayviewer(matrix1);
        }
        static void Arrayviewer<T>(T[,] array)
        {
            if (array.GetLength(0) > 0)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[j, 0]);

                    for (int i = 1; i < array.GetLength(1); i++)
                    {
                        Console.Write($" {array[j, i]}");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Array is empty");
            }
        }
    }
}
