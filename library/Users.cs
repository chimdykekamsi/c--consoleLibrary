using System;
using System.Collections.Generic;

namespace library
{
    internal class Users
    {
        public string fullName { get; set; }
        public string age { get; set; }
        public string role { get; set; }
        public string userid { get; set; }
        public string bookStats { get; set; }
        public string dateJoined { get; set; }
        public int bookNum { get; set; }


        public static List<Users> persons = new List<Users> ();

        public static void register()
        {
            Console.Clear();
            Display.Write("✍✍User registration✍✍");

            Console.Write("fullname: ");
            string name = Console.ReadLine();
            Verify.strings(name);

            while (Verify.strings(name) == false || name.ToLower() == "")
            {
                Console.Write("(invalid input)Fullname: ");
                name = Console.ReadLine();
            }
            
            Console.Write("age: ");
            string age = Console.ReadLine();
            Verify.number(age);

            while (Verify.number(age) == false || age == "" || Convert.ToInt32(age) < 10)
            {
                Console.Write("(invalid input)age: ");
                age = Console.ReadLine();
            }
            
            Console.Write("role(Student/Admin): ");
            string role = Console.ReadLine();
            Verify.strings(role);

            while (Verify.strings(role) == false || role == "" || role.ToLower() != "student" && role.ToLower() != "admin")
            {
                Console.Write("(invalid input)role(student/admin): ");
                role = Console.ReadLine();
            }

            Verify.animWord("Generating userid ........");
            Console.ReadKey();
            Random random = new Random();
            int rand = random.Next(1000000,9999999);
            string userid = "Apt" + rand;
            Console.WriteLine($"userid : {userid}");

            string bookstats = "free";

            DateTime date = DateTime.Now;

            persons.Add(new Users { fullName = name, age = age,role = role,userid = userid, bookStats = bookstats, dateJoined = date.ToString(), bookNum = 0});
            Verify.animWord("Registeration was Sucessfull !!");

            Console.WriteLine("Proceed to login ...( Y/ N)");
            Console.Write("reply: ");
            string reply = Console.ReadLine();
            Verify.strings(reply);

            while (Verify.strings(reply) == false || reply.ToLower() != "y" && reply.ToLower() != "n")
            {
                Console.Write("(invalid input)reply: ");
                reply = Console.ReadLine();
            }

            if (reply.ToLower() == "y")
            {
                Users.login();
            }
            else
            {
                Display.one();
            }
                        
        }

        public static void display()
        {
            Console.Clear();
            Display.Write("All registered users");            
            
            if (persons.Count < 2)
            {
                Display.Write("No other user found");
                if (Session.role == "admin")
                {
                    Display.twoA(Session.fullName);
                }
                else
                {
                    Display.twoS(Session.fullName);
                }
            }
            else
            {
                int a = 1;
                foreach (var person in persons)
                {
                    if (person.userid == Session.userid)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{a} | {person.fullName} || {person.userid} |");
                    }
                    a++;

                }
                Console.WriteLine($"Go back(type 'back')");
                Console.WriteLine("Select a user using the respective user id to view user details");
                Console.Write("userid: ");
                string userid = Console.ReadLine();
                Verify.strings(userid);

                while (Verify.strings(userid) == false || userid.ToLower() == "")
                {
                    Console.Write("(invalid input)userid: ");
                    userid = Console.ReadLine();
                }

                if (userid.ToLower() == "back")
                {
                    Display.twoA(Session.fullName);
                }
                else
                {
                   details(userid);
                }
            }
           
            
            Console.ReadKey();
        }
        
        public static void login()
        {
            Console.Clear();
            Display.Write("User Login");
            Console.WriteLine("login with your userid");
            Console.Write("userid: ");
            string userid = Verify.hide();
            Verify.strings(userid);

            while (Verify.strings(userid) == false || userid.ToLower() == "")
            {
                Console.Write("(invalid input)userid: ");
                userid = Console.ReadLine();
            }
            if (persons.Count > 0)
            {
                foreach (var person in persons)
                {

                    if (person.userid == userid)
                    {
                        Session.fullName = person.fullName;
                        Session.age = person.age;
                        Session.role = person.role;
                        Session.userid = person.userid;
                        Session.dateJoined = person.dateJoined;
                        if (person.role.ToLower() == "admin")
                        {
                            Display.twoA(person.fullName);
                        }
                        else
                        {
                            Display.twoS(person.fullName);
                        }
                        
                        return;
                    }
                    else
                    {
                        continue;
                    }                                   

                }
                Display.Write("No such user exists");
                Console.WriteLine("Try Again? ...( Y/ N)");
                Console.Write("reply: ");
                string reply = Console.ReadLine();
                Verify.strings(reply);

                while (Verify.strings(reply) == false || reply.ToLower() != "y" && reply.ToLower() != "n")
                {
                    Console.Write("(invalid input)reply: ");
                    reply = Console.ReadLine();
                }

                if (reply.ToLower() == "y")
                {
                    Users.login();
                }
                else
                {
                    Display.one();
                }
            }
            else
            {
                Display.Write("No such user exists");
                Console.WriteLine("Try Again? ...( Y/ N)");
                Console.Write("reply: ");
                string reply = Console.ReadLine();
                Verify.strings(reply);

                while (Verify.strings(reply) == false || reply.ToLower() != "y" && reply.ToLower() != "n")
                {
                    Console.Write("(invalid input)reply: ");
                    reply = Console.ReadLine();
                }

                if (reply.ToLower() == "y")
                {
                    Users.login();
                }
                else
                {
                    Display.one();
                }
            }
        }
    
        private static void details(string userid)
        {
            Console.Clear();
            Display.Write("User details");
            foreach (var person in persons)
            {

                if (person.userid == userid)
                {
                    Session._fullName = person.fullName;
                    Session._age = person.age;
                    Session._role = person.role;
                    Session._userid = person.userid;
                    Session.bookstat = person.bookStats;

                    Console.WriteLine($"Fullname : {Session._fullName}");
                    Console.WriteLine($"Age : {Session._age}");
                    Console.WriteLine($"Role : {Session._role}");
                    Console.WriteLine($"Role : {Session._role}");
                    Console.WriteLine($"Date joined : {person.dateJoined}");
                    Console.WriteLine($"Book status : {Session.bookstat}");
                    Console.WriteLine($"Number of books in possesion : {person.bookNum}");
                    Console.WriteLine("\nSelect an option");

                    Console.WriteLine("1.Delete");
                    Console.WriteLine("2.Go back");


                    Console.Write("reply: ");
                    string reply = Console.ReadLine();

                    Verify.number(reply);

                    while (Verify.number(reply) == false || reply == "" || Convert.ToInt32(reply) < 1 || Convert.ToInt32(reply) > 2)
                    {
                        Console.Write("(invalid input)reply: ");
                        reply = Console.ReadLine();
                    }
                    switch (Convert.ToInt32(reply))
                    {
                        case 1:
                            delete(userid);
                            break;
                        case 2:
                            display();
                            break;
                    }
                    return;
                }
                else
                {
                    continue;
                }

            }
            Console.WriteLine("No such user exists");
            Users.display();
        }

        private static void delete(string userid)
        {
            Console.Clear();
            Display.Write("Confirm delete? ...( Y/ N)");
            Console.Write("reply: ");
            string reply = Console.ReadLine();
            Verify.strings(reply);
            while (Verify.strings(reply) == false || reply.ToLower() != "y" && reply.ToLower() != "n")
            {
                Console.Write("(invalid input)reply: ");
                reply = Console.ReadLine();
            }
            if (reply.ToLower() == "y")
            {
                foreach (var person in persons)
                {

                    if (person.userid == userid)
                    {
                        if (person.bookStats != "free")
                        {
                            Display.Write("This User is currently in possesion of a book (select a different user)");
                            Console.ReadKey();
                            display();
                        }
                        else
                        {
                            persons.Remove(person);
                            display();
                        }
                        return;
                    }
                    else
                    {
                        continue;
                    }

                }
            }
            else
            {
                display();
            }
        }

        public static void inventory()
        {
            Console.Clear();
            Display.Write("USER INVENTORY");


            Console.WriteLine("\nSelect an option");
            Console.WriteLine("1.View profile");
            Console.WriteLine("2.View Borrowed Books");
            Console.WriteLine("3.Go back");
            Console.Write("reply: ");
            string reply = Console.ReadLine();

            Verify.number(reply);

            while (Verify.number(reply) == false || reply == "" || Convert.ToInt32(reply) < 1 || Convert.ToInt32(reply) > 3)
            {
                Console.Write("(invalid input)reply: ");
                reply = Console.ReadLine();
            }
            switch (Convert.ToInt32(reply))
            {
                case 1:
                    viewProfile();
                    break;
                case 2:
                    books();
                    break;
                case 3:
                    Display.twoS(Session.fullName);
                    break;
            }

            
        }

        public static void viewProfile()
        {
            Console.Clear();
            Display.Write("profile...");

            Console.WriteLine($"Fullname: {Session.fullName}");
            Console.WriteLine($"Age: {Session.age}");
            Console.WriteLine($"Role: {Session.role}");
            Console.WriteLine($"Userid: {Session.userid}");
            Console.WriteLine($"Datejoined: {Session.dateJoined}");
            Console.ReadKey();

            Console.WriteLine($"\n");


            Console.WriteLine($"Select an option");
            Console.WriteLine($"1. Edit Profile");
            Console.WriteLine($"2. Go Back");
            Console.Write("reply: ");
            string reply = Console.ReadLine();
            Verify.number(reply);

            while (Verify.number(reply) == false || Convert.ToInt32(reply) == 0 || Convert.ToInt32(reply) > 2)
            {
                Console.Write("(invalid input)reply: ");
                reply = Console.ReadLine();
            }

            switch (Convert.ToInt32(reply))
            {
                case 1:
                    edit(Session.userid);
                    break;
                case 2:
                    if (Session.role.ToLower() == "admin")
                    {
                        Display.twoA(Session.fullName);
                    }
                    else
                    {
                        inventory();
                    }
                    break;
            }
        }

        public static void edit(string userid)
        {
            Console.Clear();
            Display.Write("Edit Profile");
            foreach (var person in persons)
            {
                if (person.userid == userid)
                {
                    Console.Write("Fullname(leave field empty if you dont wish to change): ");
                    string name = Console.ReadLine();
                    Verify.strings(name);

                    while (Verify.strings(name) == false)
                    {
                        Console.Write("(invalid input)Fullname: ");
                        name = Console.ReadLine();
                    }

                    Console.Write("Age(Input '0' if you dont wish to change): ");
                    string age = Console.ReadLine();
                    Verify.number(age);

                    while (Verify.number(age) == false)
                    {
                        Console.Write("(invalid input)Age: ");
                        age = Console.ReadLine();
                    }

                    if (name == "")
                    {
                        Console.WriteLine("Fullname not changed");
                        Console.ReadKey();
                    }
                    else
                    {
                        person.fullName = name;
                        Session.fullName = person.fullName;
                    }

                    if (Convert.ToInt32(age) == 0)
                    {
                        Console.WriteLine("Age not changed");
                        Console.ReadKey();
                    }
                    else
                    {
                        person.age = age;
                        Session.age = person.age;
                    }
                    Display.Write("User profile changed successfully");
                    if (Session.role.ToLower() == "admin")
                    {
                        Display.twoA(Session.fullName);
                    }
                    else
                    {
                        inventory();
                    }
                    

                    return;
                }
                else
                {
                    continue;
                }


            }
        }

        public static void books()
        {
            Console.Clear();
            Display.Write("Books in possesion");
            int a = 0;
            if (Books.books.Count > 0)
            {
                foreach (var book in Books.books)
                {

                    if (book.bookUserid == Session.userid)
                    {                                        
                        a++;
                        Console.WriteLine($"{a}| {book.name} || {book.bookId} |");
                    }
                    else
                    {
                        continue;
                    }
                    
                }
                if (a < 1)
                {
                    Console.WriteLine("No book is in your inventory");
                    foreach (var person in persons)
                    {
                        if (person.userid == Session.userid)
                        {
                            person.bookNum = a;
                            person.bookStats = "free";
                        }
                    }
                    inventory();
                }
                else
                {
                    foreach (var person in persons)
                    {
                        if (person.userid == Session.userid)
                        {
                            person.bookNum = a;
                            person.bookStats = "Not free";
                        }
                    }
                }

                Console.WriteLine($"Go back(type 'back')");
                Console.WriteLine("Select a book using the respective book id to view book details");
                Console.Write("bookid: ");
                string bookid = Console.ReadLine();
                Verify.strings(bookid);

                while (Verify.strings(bookid) == false || bookid.ToLower() == "")
                {
                    Console.Write("(invalid input)userid: ");
                    bookid = Console.ReadLine();
                }

                if (bookid.ToLower() == "back")
                {
                    inventory();
                }
                else
                {
                    action(bookid);
                }
            }
            else
            {
                Console.WriteLine("No book is in your inventory");
                inventory();
            }

            
        }

        private static void action(string bookid)
        {
            Console.Clear();
            Display.Write("Book details");
            foreach (var book in Books.books)
            {

                if (book.bookId == bookid)
                {

                    Console.WriteLine($"Name : {book.name}");
                    Console.WriteLine($"Author : {book.author}");

                    Console.WriteLine("\n");

                    Console.WriteLine("Select Action");

                    Console.WriteLine("1.Return Book");
                    Console.WriteLine("2.Go back");


                    Console.Write("reply: ");
                    string reply = Console.ReadLine();

                    Verify.number(reply);

                    while (Verify.number(reply) == false || reply == "" || Convert.ToInt32(reply) < 1 || Convert.ToInt32(reply) > 2)
                    {
                        Console.Write("(invalid input)reply: ");
                        reply = Console.ReadLine();
                    }
                    switch (Convert.ToInt32(reply))
                    {
                        case 1:
                            Books.Return(bookid);
                            break;
                        case 2:
                            books();
                            break;
                    }
                    return;
                }
                else
                {
                    continue;
                }



            }
            Console.WriteLine("No such book exists");
            books();
        }

    }
}
