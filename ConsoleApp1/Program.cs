using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] matrix1 = { {1 , 2 , 1 },
                                  {3 , 1 , 0 },
                                  {2 , 2 , 3 } };
            double[,] matrix2 = { { 1 , 2 },
                                  { 3 , 4 } };
            PrintMatrix(matrix1);
            double det = DeterminantCalculator(matrix1);
            Console.WriteLine(det);
        }
        static double DeterminantCalculator(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid dimension, determinant is not defined in a non-square matrix");
                    return -111;
                }
            if (matrix.GetLength(0) > 3)
            {
                Console.WriteLine("Calculations for matrices with a 4+ x 4+ matrix not yest implemented ");
                return -111;
            }
            if (matrix.GetLength(0) == 3)
            {
                return Determinant3DMatrix(matrix);
            }
            else
            {
                return Determinant2DMatrix(matrix);
            }
        }
        static double Determinant2DMatrix(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                Console.WriteLine("Invalid dimension, determinant is not defined in a non-square matrix");
                return -111;
            }
            double determinant = (matrix[0,0] * matrix[1,1]) - (matrix[1,0] * matrix[0,1]);
            return determinant;
        }
        static double Determinant3DMatrix(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                Console.WriteLine("Invalid dimension, determinant is not defined in a non-square matrix");
                return -111;
            }

            double[,] matrix1 = { {matrix[1,1] , matrix[1,2]} ,
                                 {matrix[2,1] , matrix[2,2]} };
            double[,] matrix2 = { {matrix[1,0] , matrix[1,2]} ,
                                 {matrix[2,0] , matrix[2,2]} };
            double[,] matrix3 = { {matrix[1,0] , matrix[1,1]} ,
                                 {matrix[2,0] , matrix[2,1]} };

            double determinant = (matrix[0, 0] * Determinant2DMatrix(matrix1)) - (matrix[0, 1] * Determinant2DMatrix(matrix2)) + (matrix[0, 2] * Determinant2DMatrix(matrix3));
            return determinant;
        }
        static void PrintMatrix<T>(T[,] array)
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
                Console.WriteLine("matrix is empty");
            }
        }
    }
}
