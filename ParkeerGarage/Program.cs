using System;

namespace ParkeerGarage
{
    class Program
    {
        static void Main(string[] args)
        {
            int cars = Convert.ToInt32(GiveNumber("int", "How many cars were parked today?"));
            double[,] bill = new double[cars, 2];

            for (int i = 0; i < cars; i++)
            {
                bill[i, 0] = GiveNumber("+", $"How long was car {i + 1} parked? (In hours)");
                bill[i, 1] = CostCalculator(Convert.ToInt32(bill[i, 0]));
            }
            PrintBill(bill);
        }
        static double GiveNumber(string test, string question)
        {
            string numberString;
            do
            {
                Console.WriteLine(question);
                numberString = Console.ReadLine();
            } while (!(Microsoft.VisualBasic.Information.IsNumeric(numberString)));
            double number = Convert.ToDouble(numberString);
            if (test == "+")
            {
                if (number >= 0)
                {
                    return number;
                }
                else
                {
                    number = GiveNumber("+", question);
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
                    number = GiveNumber("+", question);
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
                    number = GiveNumber("int", question);
                    return number;
                }
            }
            else
            {
                return number;
            }

        }
        static double CostCalculator(int hoursParked)
        {
            if (hoursParked <= 3)
            {
                return 2.0;
            }
            else if (hoursParked < 19)
            {
                return 2.0 + (hoursParked - 3) * 0.5;
            }
            else
            {
                return 10;
            }
        }
        static void PrintBill(double[,] bill)
        {
            double totalCars = bill.GetLength(0);
            double totalTime = 0;
            double totalPrice = 0;
            Console.WriteLine("Car\t Time parked\t Cost");
            for (int i = 0; i < bill.GetLength(0); i++)
            {
                Console.WriteLine($"{i+1}\t {bill[i, 0]}\t\t {bill[i, 1]}");
                totalTime += bill[i, 0];
                totalPrice += bill[i, 1];
            }
            Console.WriteLine($"\n{totalCars}\t {totalTime}\t\t {totalPrice}");


        }
    }
}
