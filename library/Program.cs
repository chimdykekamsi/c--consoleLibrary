using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Display.one();
        }

        public static void end()
        {
            Display.Write("Confirm exit (Y / N)");
            Console.Write("\nreply: ");
            string reply = Console.ReadLine();
            Verify.strings(reply);

            while (Verify.strings(reply) == false || reply.ToLower() != "y" && reply.ToLower() != "n")
            {
                Console.Write("(invalid input)reply: ");
                reply = Console.ReadLine();
            }

            if (reply.ToLower() == "y")
            {
                Environment.Exit(0);
            }
            else
            {
                Display.one();
            }
            
        }


      
    }
}
