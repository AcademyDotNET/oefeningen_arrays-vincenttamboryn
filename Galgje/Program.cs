using System;
using System.Collections.Generic;
namespace Galgje
{
    class Program
    {
        static void Main(string[] args)
        {
            string gok = "";
            List<string> gegoktFout = new List<string>();
            List<string> alGeraden = new List<string>();
            string[] antwoord = WordToArray(RandomWoord());
            string[] gegoktJuist = GegoktJuistInitialiseren(antwoord.Length);

            do
            {
                TekenGalgje(gegoktFout.Count);
                Console.Write("Juist gegokt: ");
                PrintArray(gegoktJuist);
                Console.Write("Fout gegokt: ");
                PrintList(gegoktFout);
                gok = RaadEenLetter(alGeraden);
                if (Gok(gok, antwoord))
                {
                    GokJuist(gok, antwoord, gegoktJuist);
                }
                else
                {
                    gegoktFout.Add(gok);
                }
                Console.Clear();
            } while (!GewonnenCheck(gegoktJuist, antwoord) && !(gegoktFout.Count == 8));
            if (gegoktFout.Count == 8)
            {
                YouLose();
                Console.Write($"Het juiste antwoord was ");
                PrintArray(antwoord);
            }
            else
            {
                YouWin();
                Console.Write($"Het juiste antwoord was inderdaad ");
                PrintArray(antwoord);
            }
        }
        static void TekenGalgje(int fouten)
        {
            //tekend de galg
            switch (fouten)
            {
                case 0:
                    Console.WriteLine(@"
      |
      |
      |
      |
      |
=========");
                    break;
                case 1:
                    Console.WriteLine(@"  
  +---+
      |
      |
      |
      |
      |
=========");
                    break;
                case 2:
                    Console.WriteLine(@"  
  +---+
  |   |
      |
      |
      |
      |
=========");
                    break;
                case 3:
                    Console.WriteLine(@"  
  +---+
  |   |
  O   |
      |
      |
      |
=========");
                    break;
                case 4:
                    Console.WriteLine(@"  
  +---+
  |   |
  O   |
  |   |
      |
      |
=========");
                    break;
                case 5:
                    Console.WriteLine(@"  
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========");
                    break;
                case 6:
                    Console.WriteLine(@"  
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========");
                    break;
                case 7:
                    Console.WriteLine(@"  
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========");
                    break;
                case 8:
                    Console.WriteLine(@"  
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
=========");
                    break;
                default:
                    Console.Write("error mistake with drawing");
                    break;
            }
        }
        static bool GewonnenCheck(string[] antwoord, string[] gegoktjuist)
        {//kijkt na of het spel al gewonnen is
            for (int i = 0; i < antwoord.Length; i++)
            {
                if (antwoord[i] != gegoktjuist[i])
                {
                    return false;
                }
            }
            return true;
        }
        static bool Gok(string gok, string[] antwoord)
        {//kijkt of een gok correct was
            //returns true als de gok juist was, false indien hij fout was
            for (int i = 0; i < antwoord.Length; i++)
            {
                if (antwoord[i] == gok)
                {
                    return true;
                }
            }
            return false;
        }
        static void GokJuist(string gok, string[] antwoorden, string[] gegoktjuist)
        {// veranderd de _ in de array gegoktjuist door de correct gegokte letter
            for (int i = 0; i < antwoorden.Length; i++)
            {
                if (antwoorden[i] == gok)
                {
                    gegoktjuist[i] = antwoorden[i];
                }
            }
        }
        static string[] GegoktJuistInitialiseren(int lengteWoord)
        {
            // vult de array gogoktjuist met _
            string[] gegoktJuist = new string[lengteWoord];
            for (int i = 0; i < lengteWoord; i++)
            {
                gegoktJuist[i] = "_";
            }
            return gegoktJuist;
        }
        static string RaadEenLetter(List<string> alGeraden)
        {//returnt een gok die nog niet gegokt is en slechts uit 1 letter bestaat
            string gok;
            do
            {
                Console.WriteLine("Gok een letter die je nog niet gegokt hebt");
                gok = Console.ReadLine();
                gok = gok.ToUpper();
            } while ((alGeraden.Contains(gok)) || gok.Length != 1 || Microsoft.VisualBasic.Information.IsNumeric(gok) || (Convert.ToInt32(Convert.ToChar(gok)) < 65 || Convert.ToInt32(Convert.ToChar(gok)) > 90));

            alGeraden.Add(gok);
            return gok;  
           
        }
        static void PrintArray<T>(T[] array)
        {
            if (array.Length > 0)
            {
                Console.Write(array[0]);
                for (int i = 1; i < array.Length; i++)
                {
                    Console.Write($" {array[i]}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("_");
            }
        }
        static void PrintList<T>(List<T> lijst)
        {
            if (lijst.Count > 0)
            {
                Console.Write(lijst[0]);
                for (int i = 1; i < lijst.Count; i++)
                {
                    Console.Write($" {lijst[i]}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("_");
            }
        }
        static void YouWin()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
                                                   __           
                                                  /  |          
 __    __   ______   __    __        __   __   __ $$/  _______  
/  |  /  | /      \ /  |  /  |      /  | /  | /  |/  |/       \ 
$$ |  $$ |/$$$$$$  |$$ |  $$ |      $$ | $$ | $$ |$$ |$$$$$$$  |
$$ |  $$ |$$ |  $$ |$$ |  $$ |      $$ | $$ | $$ |$$ |$$ |  $$ |
$$ \__$$ |$$ \__$$ |$$ \__$$ |      $$ \_$$ \_$$ |$$ |$$ |  $$ |
$$    $$ |$$    $$/ $$    $$/       $$   $$   $$/ $$ |$$ |  $$ |
 $$$$$$$ | $$$$$$/   $$$$$$/         $$$$$/$$$$/  $$/ $$/   $$/ 
/  \__$$ |                                                      
$$    $$/                                                       
 $$$$$$/                                                        ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void YouLose()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
                                     __                                     
                                    /  |                                    
 __    __   ______   __    __       $$ |        ______    _______   ______  
/  |  /  | /      \ /  |  /  |      $$ |       /      \  /       | /      \ 
$$ |  $$ |/$$$$$$  |$$ |  $$ |      $$ |      /$$$$$$  |/$$$$$$$/ /$$$$$$  |
$$ |  $$ |$$ |  $$ |$$ |  $$ |      $$ |      $$ |  $$ |$$      \ $$    $$ |
$$ \__$$ |$$ \__$$ |$$ \__$$ |      $$ |_____ $$ \__$$ | $$$$$$  |$$$$$$$$/ 
$$    $$ |$$    $$/ $$    $$/       $$       |$$    $$/ /     $$/ $$       |
 $$$$$$$ | $$$$$$/   $$$$$$/        $$$$$$$$/  $$$$$$/  $$$$$$$/   $$$$$$$/ 
/  \__$$ |                                                                  
$$    $$/                                                                   
 $$$$$$/                                                                    ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static string[] WordToArray(string word)
        {
            word = word.ToUpper();
            char[] letters = word.ToCharArray();
            string[] lettersArray = new string[letters.Length];
            for (int i = 0; i < letters.Length; i++)
            {
                lettersArray[i] = Convert.ToString(letters[i]);
            }
            return lettersArray;
        }
        static string RandomWoord()
        {
            string[] woordenLijst = {"cavia","krukje","tijd","fors","sambal","zuivel","kritisch","jasje","giga","dieren",
                                     "lepel","picknick","quasi","verzenden","winnaar","dextrose","vrezen","niqaab","hierbij",
                                     "quote","botox","cruciaal","zitting","cabaret","bewogen","vrijuit","carrière","ijverig","cake",
                                     "dyslexie","uier","nihil","sausje","kuuroord","poppetje","docent","camping","schijn","kloppen",
                                     "detox","boycot","cyclus","quiz","censuur","aaibaar","chagrijnig","fictief","chef","gering",
                                     "nacht","cacao","triomf","baby","ijstijd","cruisen","ontzeggen","quad","open","turquoise",
                                     "carnaval","boxer","straks","fysiek","accu","twijg","quote","gammel","flirt","futloos",
                                     "vreugde","ogen","geloof","periode","volwaardig","uitleg","stuk","volk","even","stijl","val",
                                     "alliantie","tocht","mooi","joggen","broek","kwik","werksfeer","vorm","nieuw","sopraan",
                                     "miljoen","inrichting","dak","echt","schikking","print","oorlog","zijraam","hyacint" };
            Random randomGen = new Random();
            return woordenLijst[randomGen.Next(0, woordenLijst.Length)];
        }
    }
}
