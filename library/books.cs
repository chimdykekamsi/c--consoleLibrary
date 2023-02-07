using System;
using System.Collections.Generic;

namespace library
{

    internal class Books
    {
        public string name { get; set; }
        public string author { get; set; }
        public string user { get; set; }
        public string status { get; set; }
        public string bookId { get; set; }
        public DateTime dateAdded { get; set; }

        public string bookUserid { get; set; }

        public static List<Books> books = new List<Books>();
        public static void add()
        {
            Console.Clear();
            Display.Write("✍✍Add Book✍✍");

            Console.Write("Title: ");
            string name = Console.ReadLine();
            Verify.strings(name);

            while (Verify.strings(name) == false || name.ToLower() == "")
            {
                Console.Write("(invalid input)Title: ");
                name = Console.ReadLine();
            }

            Console.Write("authur: ");
            string authur = Console.ReadLine();
            Verify.strings(authur);

            while (Verify.strings(authur) == false || authur == "" )
            {
                Console.Write("(invalid input)Authur: ");
                authur = Console.ReadLine();
            }

            string status = "on shelf";
            Console.Write($"status: {status}");

            string user = "Nill";

            
            Random random = new Random();
            int rand = random.Next(1000000, 9999999);
            string bookid = "book" + rand;

            DateTime dateAdded = DateTime.Now;

            books.Add(new Books { name = name, author = authur, status = status, user = user, bookId = bookid, bookUserid = "",dateAdded = dateAdded});
            Display.Write("Book has been added to shelf!!");

            Display.twoA(Session.fullName);
        }

        public static void display()
        {
            Console.Clear();
            Display.Write("View all books");
            if (books.Count < 1)
            {
                Display.Write("No books found");
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
                foreach (var book in books)
                {

                    Console.WriteLine($"{a}| {book.name} || {book.bookId} |");

                    a++;

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
                    details(bookid);
                }
            }
        }

        public static void details(string bookid)
        {
            Console.Clear();
            Display.Write("Book details");
            foreach (var book in books)
            {

                if (book.bookId == bookid)
                {
                    
                    Console.WriteLine($"Name : {book.name}");
                    Console.WriteLine($"Author : {book.author}");
                    Console.WriteLine($"User : {book.user}");
                    Console.WriteLine($"Date added : {book.dateAdded.Date}");
                    Console.WriteLine($"Status : {book.status}");

                    if (Session.role.ToLower() == "admin")
                    {
                        Console.WriteLine("\nSelect an option");

                        Console.WriteLine("1.Delete");
                        Console.WriteLine("2.Edit");
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
                                delete(bookid);
                                break;
                            case 2:
                                edit(bookid);
                                break;
                            case 3:
                                display();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nSelect an option");

                        Console.WriteLine("1.Borrow");
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
                                borrow(bookid);
                                break;
                            case 2:
                                display();
                                break;
                        }
                    }
                    return;
                }
                else
                {
                    continue;
                }

                

            }
            Console.WriteLine("No such book exists");
            Books.display();
        }

        public static void borrow (string bookid)
        {
            foreach (var book in books)
            {
                if (book.bookId == bookid)
                {
                    if (book.status == "borrowed")
                    {
                        Display.Write("Book is currently not on shelf (select a different book)");
                        Console.ReadKey();
                        display();
                    }
                    else
                    {
                        book.user = Session.fullName;
                        book.status = "borrowed";
                        book.bookUserid = Session.userid;
                        changestats(Session.userid);
                        Display.Write("Book has been added to your inventory");
                        display();

                    }
                }
                else
                {
                    continue;
                }
            }
        }
       
        public static void edit(string bookid)
        {
            Console.Clear();
            Display.Write("Edit book");
            foreach (var book in books)
            {
                if (book.bookId == bookid)
                {
                    if (book.status == "borrowed")
                    {
                        Display.Write("Book is currently not on shelf (select a different book)");
                        Console.ReadKey();
                        display();
                    }
                    else
                    {
                        Console.Write("Title(leave field empty if you dont wish to change): ");
                        string name = Console.ReadLine();
                        Verify.strings(name);

                        while (Verify.strings(name) == false)
                        {
                            Console.Write("(invalid input)Title: ");
                            name = Console.ReadLine();
                        }

                        Console.Write("authur(leave field empty if you dont wish to change): ");
                        string authur = Console.ReadLine();
                        Verify.strings(authur);

                        while (Verify.strings(authur) == false)
                        {
                            Console.Write("(invalid input)Authur: ");
                            authur = Console.ReadLine();
                        }

                        if (name == "")
                        {
                            Console.WriteLine("Book title not changed");
                            Console.ReadKey();
                        }
                        else
                        {
                            book.name = name;
                        }

                        if (authur == "")
                        {
                            Console.WriteLine("Book Author not changed");
                            Console.ReadKey();
                        }
                        else
                        {
                            book.author = authur;
                        }
                        Display.Write("Book details changed successfully");
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

        public static void delete(string bookid)
        {
            Console.Clear();
            Console.WriteLine("Confirm delete? ...( Y/ N)");
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
                foreach (var book in books)
                {

                    if (book.bookId == bookid)
                    {
                        if (book.status == "borrowed")
                        {
                            Display.Write("Book is currently not on shelf (select a different book)");
                            Console.ReadKey();
                            display();
                        }
                        else
                        {
                            books.Remove(book);
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

        private static void changestats(string userid)
        {
            foreach (var person in Users.persons)
            {
                if (person.userid == userid)
                {
                    person.bookStats = "not free";
                    person.bookNum++; 
                    return;
                }
                else
                {
                    continue;
                }
            }
        }

        public static void Return(string bookid)
        {
            foreach (var book in books)
            {
                if (book.bookId == bookid)
                {
                    if (book.status == "borrowed")
                    {
                        book.user = "NILL";
                        book.status = "on shelf";
                        book.bookUserid = "";
                        Display.Write("Book has been returned to shelf");
                        Users.books();
                    }
                    else
                    {
                        Console.WriteLine("Book cannot be found your inventory");
                    }
                }
                else
                {
                    continue;
                }
            }
        }
    }

}