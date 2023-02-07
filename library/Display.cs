using System;

namespace library
{
    internal class Display
    {
        public static void Write(string word)
        {
            Console.WriteLine("\n");
            string start = "|    ";
            string ast = " =========";
            for (int i = 0; i < word.Length; i++)
            {
                ast += "=";
            }
            Console.WriteLine(ast);
            for (int i = 0; i < word.Length; i++)
            {
                start += word[i];
            }
            start += "     |";
            Console.WriteLine(start);
            ast = " ";
            for (int i = 0; i < word.Length; i++)
            {
                ast += "=";
            }
            ast += "=========";
            Console.WriteLine(ast);
            Console.WriteLine("\n");
            Console.ReadKey();
        }


        public static void one()
        {
            Console.Clear();
            Write("🖐🏼🖐🏼 Hello welcome to aptech library  ✍🏼🤵🏼");
            Console.WriteLine("\nSelect an option");
            Console.WriteLine("1.Register(obtain an account) ✍✍"); 
            Console.WriteLine("2.Login(Already have an account) ✍✍"); 
            Console.WriteLine("3.Exit app 📤📤🔳");
            Console.Write("reply: ");

            string reply = Console.ReadLine();
            Verify.number(reply);
            while (Verify.number(reply) == false || reply == "" || Convert.ToInt32(reply) > 3 || Convert.ToInt32(reply) < 1)
            {
                Console.Write("(invalid input) reply: ");
                reply = Console.ReadLine();
            }
            switch (Convert.ToInt32(reply))
            {
                case 1:
                    Users.register();
                    break;
                case 2:
                    Users.login();
                    break;
                case 3:
                    Program.end();
                    break;
            }
            return;
        }


        public static void twoA(string name)
        {
            Console.Clear();
            string reply;
            Write($"Welcome to your dashboard {name}");
            Console.WriteLine("\nSelect an option");           
            Console.WriteLine("1.View all users");
            Console.WriteLine("2.Add a book");
            Console.WriteLine("3.View all books");
            Console.WriteLine("4.View profile");
            Console.WriteLine("5.Logout");
          

            Console.Write("reply: ");
            reply = Console.ReadLine();

            Verify.number(reply);

            while (Verify.number(reply) == false || reply == "" || Convert.ToInt32(reply) < 1 || Convert.ToInt32(reply) > 5)
            {
                Console.Write("(invalid input)reply: ");
                reply = Console.ReadLine();
            }

            switch(Convert.ToInt32(reply))
            {
                case 1:
                    Users.display();
                    break; 
                case 2:
                    Books.add();
                    break;
                case 3:
                    Books.display();
                    break;
                case 4:
                    Users.viewProfile();
                    break;
                case 5:
                    Session.fullName = null;
                    Session.age = null;
                    Session.role = null;
                    Session.userid = null;
                    Display.one();
                    break;
            }

            return;
        }
        

        public static void twoS(string name)
        {
            Console.Clear();
            string reply;
            Write($"Welcome to your dashboard {name}");
            Console.WriteLine("\nSelect an option");

            Console.WriteLine("1.View all books");
            Console.WriteLine("2.View inventory");
            Console.WriteLine("3.Logout");


            Console.Write("reply: ");
            reply = Console.ReadLine();

            Verify.number(reply);

            while (Verify.number(reply) == false || reply == "" || Convert.ToInt32(reply) < 1 || Convert.ToInt32(reply) > 3)
            {
                Console.Write("(invalid input)reply: ");
                reply = Console.ReadLine();
            }
            switch (Convert.ToInt32(reply))
            {
                case 1:
                    Books.display();
                    break;
                case 2:
                    Users.inventory();
                    break;
                case 3:
                    Session.fullName = null;
                    Session.age = null;
                    Session.role = null;
                    Session.userid = null;
                    Display.one();
                    break;
            }
            return;
        }
    }
}