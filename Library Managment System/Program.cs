using Library_Managment_System;

namespace Library_Managment_System
{

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }
        public Book(string title, string author, string isbn)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
            IsAvailable = true;
        }

    }



    class Library
    {
        List<Book> books = new List<Book>();
        public string addbook(string title, string author, string isbn)
        {
            books.Add(new Book(title, author, isbn));
            return $"Book '{title}' added successfully.";
        }
        public string SearchBook(string title)
        {

            foreach (var book in books)
            {
                if (title == book.Title)
                {

                    Console.WriteLine($"Book is found {book.Title} ");
                    return ($"Book '{title}' found in the library.");
                }
            }

            Console.WriteLine($"Book '{title}' not found in the library.");
            return $"Book '{title}' not found in the library.";

        }

        public String BorrowBook(string title)
        {
            foreach (var book in books)
            {
                if (title == book.Title && book.IsAvailable)
                {
                    book.IsAvailable = false;
                    Console.WriteLine($"You have borrowed '{book.Title}'.");
                    return $"You have borrowed '{book.Title}'.";
                }
            }
            Console.WriteLine($"Book '{title}' is not available for borrowing.");
            return $"Book '{title}' is not available for borrowing.";
        }

        public String ReturnBook(string title)
        {
            foreach (var book in books)
            {
                if (title == book.Title && !book.IsAvailable)
                {
                    book.IsAvailable = true;
                    Console.WriteLine($"You have returned '{book.Title}'.");
                    return $"You have returned '{book.Title}'.";
                }
            }
            Console.WriteLine($"Book '{title}' was not borrowed from the library.");
            return $"Book '{title}' was not borrowed from the library.";
        }

        public void DisplayAllBooks()
        {

            if (books.Count == 0)
            {
                Console.WriteLine("The library is empty");
                return;
            }
            Console.WriteLine(" The list of books");
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Available: {book.IsAvailable}");
            }
        }
    }

        internal class Program
    {
        static void Main(string[] args)
        {
         
            Library library = new Library();
            library.addbook("the alex ", "alex author", "123456");
            library.addbook("boy", "boy author", "285466");
            library.addbook("girl", "girl author", "3479951");
            library.addbook("tarek" ,"tarek author", "9387445");
            library.addbook("mohamed" ,"mohamed author", "9387445");
            library.SearchBook("girl");
            library.BorrowBook("tarek");
            library.DisplayAllBooks();
            library.ReturnBook("tarek");
            library.DisplayAllBooks();

        }
    }
}

