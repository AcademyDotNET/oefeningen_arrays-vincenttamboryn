using System;

namespace PasswordGeneratorArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your last name?");
            string lastName = Console.ReadLine();
            string phoneNumber = Convert.ToString(GiveNumber("int","Type your phonenumber, without the zero in the front."));
            string zipcode = Convert.ToString(GiveNumber("int", "In which zipcode do you live?"));
            string password = PasswordGenerator(lastName, phoneNumber, zipcode);

            Console.WriteLine($"Your new password is {password}");
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
        static string PasswordGenerator(string lastName, string phoneNumber, string zipcode)
        {
            string password1 = "";
            string password2 = "";

            lastName = lastName.ToLower();
            char firstLetter = char.ToUpper(lastName[0]);
            password1 += Convert.ToString(firstLetter) + Convert.ToString(lastName[1]);

            for (int i = password1.Length - 1; i >= 0; i--)
            {
                password2 += Convert.ToString(password1[i]);
            }

            for (int i = 0; i < 3; i++)
            {
                password2 += phoneNumber[i];
            }

            password2 += Convert.ToString(Math.Pow(Convert.ToInt32(Convert.ToString(zipcode[0])), 2));
            return password2;

        }
    }
}
