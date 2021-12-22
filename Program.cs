using System;

namespace Caesar
{
    class Program
    {
        static char[] alphabet = new char[26] {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
        static void Main(string[] args)
        {
            Console.Clear();
            string plainText = "";
            string secretText = "";
            int key = 0;
            Console.WriteLine("[1] Enkripsi");
            Console.WriteLine("[2] Dekripsi");
            Console.Write("Masukkan pilihan anda(1/2) : ");
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                Console.Clear();
                Console.WriteLine("-- Enkripsi --");
                Console.Write("Pesan    : ");
                plainText = Console.ReadLine();
                char[] plainChar = plainText.ToCharArray();
                Console.Write("Masukkan kunci : ");
                key = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enkripsi : "+encrypt(plainChar,key));
                break;
                case "2":
                Console.Clear();
                Console.WriteLine("-- Dekripsi --");
                Console.Write("Enkripsi : ");
                secretText = Console.ReadLine();
                char[] secretChar = secretText.ToCharArray();
                Console.Write("Masukkan kunci : ");
                key = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Pesan    : "+decrypt(secretChar, key));
                break;
                default:
                Console.WriteLine("Your input is invalid.");
                break;
            }
        }
        static string encrypt(char[] plainChar, int key)
        {
            int lengthPlainText = plainChar.Length;
            char[] secretText = new char[lengthPlainText];
            for (int i = 0; i < lengthPlainText; i++)
            {
                char karakter = plainChar[i];
                if (Char.IsLetter(karakter) == true)
                {
                    int indexAwalKarakter = Array.IndexOf(alphabet, karakter);
                    int indexAkhirKarakter = (indexAwalKarakter + key) % 26;
                    char hurufRahasia = alphabet[indexAkhirKarakter];
                    secretText[i] = hurufRahasia;
                }
                else
                {
                    secretText[i] = karakter;
                }
            }
            string secretMsg = "";
            for (int i = 0; i < lengthPlainText; i++)
            {
                secretMsg += secretText[i];
            }
            return secretMsg;
        }
        static string decrypt(char[] secretChar, int key)
        {
            int lengthSecretText = secretChar.Length;
            char[] trueText = new char[lengthSecretText];
            for (int i = 0; i < lengthSecretText; i++)
            {
                char karakter = secretChar[i];
                if (Char.IsLetter(karakter) == true)
                {
                    int indexAwalKarakter = Array.IndexOf(alphabet, karakter);
                    int indexAkhirKarakter = (indexAwalKarakter - key) % 26;
                    char hurufRahasia = alphabet[indexAkhirKarakter];
                    trueText[i] = hurufRahasia;
                }
                else
                {
                    trueText[i] = karakter;
                }
            }
            string trueMsg = "";
            for (int i = 0; i < lengthSecretText; i++)
            {
                trueMsg += trueText[i];
            }
            return trueMsg;
        }
    }
}