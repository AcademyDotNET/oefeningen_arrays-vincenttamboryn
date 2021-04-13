using System;

namespace MatrixMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] matrix1 = { {1 , 2},
                                  {3 , 1},
                                  {2 , 2} };
            double[,] matrix2 = { { 1, 3, 1 },
                                  { 2, 4, 0 } };
            double[,] matrixMultiplied = MatrixMultiplier(matrix1,matrix2);
            PrintMatrix(matrixMultiplied);

        }
        static double[,] MatrixMultiplier(double[,] matrix1, double[,] matrix2)
        {
            double[,] multipliedMatrix = new double[matrix1.GetLength(0), matrix2.GetLength(1)];
            multipliedMatrix = FillMatrixWithZero(multipliedMatrix);

            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                Console.WriteLine("These matrices cannot be multiplied (invalid dimensions)");
                return multipliedMatrix;
            }
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        multipliedMatrix[i, j] += matrix1[i,k] * matrix2[k,j];
                    }
                }
            }
            return multipliedMatrix;
        }
        static double[,] FillMatrixWithZero(double[,] fillableMatrix)
        {
            for (int i = 0; i < fillableMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < fillableMatrix.GetLength(1); j++)
                {
                    int c = fillableMatrix.GetLength(0);
                    int v = fillableMatrix.GetLength(1);

                    fillableMatrix[i, j] = 0;
                }
            }
            return fillableMatrix;
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
