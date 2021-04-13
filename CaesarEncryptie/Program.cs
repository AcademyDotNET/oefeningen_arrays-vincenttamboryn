using System;

namespace CaesarEncryptie
{
    class Program
    {
        static void Main(string[] args)
        {
            string newAlphabet = Encrypt("the quick brown fox jumps over the lazy dog", 3);
            Console.WriteLine(newAlphabet);
            string oldAlphabet = Decrypt(newAlphabet,3);
            Console.WriteLine(oldAlphabet);
        }
        static string Encrypt(string toEncrypt,int key)
        {
            toEncrypt = toEncrypt.ToLower();
            char[] toEncryptArray = toEncrypt.ToCharArray();
            char[] encryptedArray = new char[toEncrypt.Length];
            if (Math.Abs(key) >= 26)
            {
                key = key - ((key / 26) * 26);
            }
            for (int i = 0; i < toEncrypt.Length; i++)
            {
                if (Convert.ToInt32(toEncryptArray[i]) == 32)
                {
                    encryptedArray[i] = toEncryptArray[i];
                }
                else if (Convert.ToInt32(toEncryptArray[i]) + key < 97)
                {
                    encryptedArray[i] = Convert.ToChar(Convert.ToInt32(toEncryptArray[i]) + key + 26);
                }
                else if (Convert.ToInt32(toEncryptArray[i]) + key > 122)
                {
                    encryptedArray[i] = Convert.ToChar(Convert.ToInt32(toEncryptArray[i]) + key - 26);
                }
                else
                {
                    encryptedArray[i] = Convert.ToChar(Convert.ToInt32(toEncryptArray[i]) + key);
                }
            }

            string encrypted = new string(encryptedArray);
            return encrypted;
        }
        static string Decrypt(string toEncrypt, int key)
        {
            return Encrypt(toEncrypt, -key);
        }
    }
}
