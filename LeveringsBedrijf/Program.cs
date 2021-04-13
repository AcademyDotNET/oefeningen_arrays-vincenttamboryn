using System;

namespace LeveringsBedrijf
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] postcodes = { 3090, 3070, 3000, 1560, 3030, 3001, 1580, 1590, 3190, 3191 };
            double[] prijsPerKilo = { 5, 10, 12, 25, 10, 11, 20, 18, 8, 9 };

            double prijsTotaal = PrijsBerekening(postcodes, prijsPerKilo);
            Console.WriteLine($"Shipping this package will cost you {prijsTotaal} euro");
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
        static double PrijsBerekening(int[] postcodes,double[] prijsPerKilo)
        {
            double packageWeight = GiveNumber("+", "Type the weight of the package (in kilograms)");
            Console.WriteLine("We ship to these zipcodes:");
            PrintArray(postcodes);
            do
            {
            int zipcode = Convert.ToInt32(GiveNumber("int", "Which zipcode would you like to post to?"));
                for (int i = 0; i < postcodes.Length; i++)
                {
                    if (postcodes[i] == zipcode)
                    {
                        return prijsPerKilo[i] * packageWeight;
                    }
                }
                Console.WriteLine("Not a Valid Zipcode");
            } while (true);
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
    }
}
