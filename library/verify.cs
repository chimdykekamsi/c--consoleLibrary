using System;
using System.Threading;

namespace library
{
    internal class Verify
    {
        public static string hide()
        {
            var password = "";
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password = password.Remove(password.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }
            return password;
        }
        public static void animWord(string text)
        {

            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(150);
            }
            Console.WriteLine("\n");
        }
        public static bool number(string input)
        {
            bool verify;

            try
            {
                Convert.ToInt32(input);
                verify = true;
            }
            catch (Exception)
            {

                verify = false;
            }
            return verify;
        }

        public static bool strings(string input)
        {
            bool verify;

            try
            {
                Convert.ToInt32(input);
                verify = false;
            }
            catch (Exception)
            {

                verify = true;
            }
            return verify;
        }
    }
}
