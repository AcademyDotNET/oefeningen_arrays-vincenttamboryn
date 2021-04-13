using System;

namespace VraagArray
{
    class Program
    {
        static void Main(string[] args)
        {
            VraagArray();
        }
        static void VraagArray()
        {
            string[] vragen = { "Hoeveel is 6 + 11" ,
                                "In welk jaar gebeurde de franse revolutie" ,
                                "Wat is het 3de perfecte getal" ,
                                "welk getal wordt hier in binair voorgesteld? 100010110" ,
                                "In welk jaar is de berlijnse muur gevallen?" ,
                                "in welk jaar was de eerste release van c#" };

            int[] antwoorden = { 17 , 1789 , 496 , 278 , 1989 , 2000 };
            int[] gebruikerAntwoorden = VragenEnAntwoorden(vragen);
            Console.Clear();
            PrintVragenAntwoorden(vragen, gebruikerAntwoorden, antwoorden);
        }
        static int[] VragenEnAntwoorden(string[] vragen)
        {
            int[] array = new int[vragen.Length];
            for (int i = 0; i < vragen.Length; i++)
            {
                Console.WriteLine(vragen[i]);
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            return array;
        }
        static void PrintVragenAntwoorden(string[] array1, int[] array2, int[] array3)
        {
            for (int i = 1; i < array1.Length; i++)
            {
                Console.WriteLine(array1[i]);
                Console.WriteLine($"Uw antwoord: {array2[i]}");
                Console.WriteLine($"Het juiste antwoord: {array3[i]}");
                Console.WriteLine();
            }
        }
    }
}
