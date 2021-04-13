using System;

namespace Voetbalcoach
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] playerScores = new int[12,2];
            int[] totalPoints = new int[playerScores.GetLength(0)];

            FillArrayZero2D(playerScores);
            InputArray(playerScores);
            ResultArray(playerScores, totalPoints);
            PrintResults(playerScores, totalPoints);
        }
        static void InputArray(int[,] playerscores)
        {
            int inputPlayer = 0;
            string inputGoodBad = "";
            do
            {
                inputPlayer = Convert.ToInt32(GiveNumber("int", $"Which player would you like to enter an action for?({playerscores.GetLength(0) + 1} to stop)", 1, playerscores.GetLength(0) + 1));
                if (inputPlayer != 13)
                {
                    do
                    {
                        Console.WriteLine($"Did player {inputPlayer} perform a great play (a), or a bad play(b)?");
                        inputGoodBad = Console.ReadLine();
                    } while (inputGoodBad != "a" && inputGoodBad != "b");
                    if (inputGoodBad == "a")
                    {
                        playerscores[inputPlayer - 1, 0] = Convert.ToInt32(GiveNumber("int", $"How many good plays did player {inputPlayer} perform?", 1));
                    }
                    else
                    {
                        playerscores[inputPlayer - 1, 1] = Convert.ToInt32(GiveNumber("int", $"How many bad plays did player {inputPlayer} perform?", 1));
                    }
                    inputGoodBad = "";
                }
            } while (inputPlayer != playerscores.GetLength(0)+1);
        }
        static void ResultArray(int[,]arrayGoodBad, int[]arrayPoints)
        {
            for (int i = 0; i < arrayGoodBad.GetLength(0); i++)
            {
                arrayPoints[i] = arrayGoodBad[i,0] - arrayGoodBad[i,1];
            }
        }
        static double GiveNumber(string test, string question, double minValue = double.NegativeInfinity, double maxvalue = double.PositiveInfinity)
        {
            string numberString;
            do
            {
                Console.WriteLine(question);
                numberString = Console.ReadLine();
            } while (!(Microsoft.VisualBasic.Information.IsNumeric(numberString)));
            double number = Convert.ToDouble(numberString);
            if (number < minValue || number > maxvalue)
            {
                return GiveNumber(test, question, minValue, maxvalue);
            }
            else
            {
                if (test == "+")
                {
                    if (number >= 0)
                    {
                        return number;
                    }
                    else
                    {
                        number = GiveNumber("+", question, minValue, maxvalue);
                        return number;
                    }
                }
                else if (test == "-")
                {
                    if (number < 0)
                    {
                        return number;
                    }
                    else
                    {
                        number = GiveNumber("+", question, minValue, maxvalue);
                        return number;
                    }
                }
                else if (test == "int")
                {
                    char[] komma = { ',' };
                    if (numberString.IndexOfAny(komma) == -1)
                    {
                        return number;
                    }
                    else
                    {
                        number = GiveNumber("int", question, minValue, maxvalue);
                        return number;
                    }
                }
                else
                {
                    return number;
                }
            }

        }
        static void FillArrayZero2D(int[,] fillableArray)
        {
            for (int i = 0; i < fillableArray.GetLength(0); i++)
            {
                for (int j = 0; j < fillableArray.GetLength(1); j++)
                {
                    fillableArray[i, j] = 0;
                }
            }
        }
        static void PrintResults(int[,] arrayGoodBad, int[] arrayPoints)
        {
            int indexBest = 0;
            int indexWorst = 0;
            for (int i = 0; i < arrayPoints.Length; i++)
            {
                if (arrayPoints[i] < arrayPoints[indexWorst])
                {
                    indexWorst = i;
                }
                if (arrayPoints[i] > arrayPoints[indexBest])
                {
                    indexBest = i;
                }
            }
            Console.WriteLine($"Backnumber \tGood \tBad \tDifference");
            for (int i = 0; i < arrayPoints.Length; i++)
            {
                if (i == indexBest)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{i + 1} \t\t{arrayGoodBad[i, 0]} \t{arrayGoodBad[i, 1]} \t{arrayPoints[i]}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (i == indexWorst)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{i + 1} \t\t{arrayGoodBad[i, 0]} \t{arrayGoodBad[i, 1]} \t{arrayPoints[i]}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (arrayPoints[i] == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{i + 1} \t\t{arrayGoodBad[i, 0]} \t{arrayGoodBad[i, 1]} \t{arrayPoints[i]}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine($"{i + 1} \t\t{arrayGoodBad[i, 0]} \t{arrayGoodBad[i, 1]} \t{arrayPoints[i]}");
                }
            }
        }
    }
}
