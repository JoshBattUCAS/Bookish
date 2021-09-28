using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookish.DataAccess;

namespace Bookish
{
    class Program
    {
        public static void PrintHomepage(Repository repo, int myUserID)
        {
            Console.WriteLine("Homepage \n".PadLeft(40));

            Console.WriteLine("Book Name".PadRight(30) + "Author".PadRight(30) + "Due Date \n");

            foreach (Copy copy in repo.GetMyBooks(myUserID))
            {
                Book book = repo.GetBook(copy.BookID);

                Console.WriteLine(book.BookName.PadRight(30) + book.Author.PadRight(30) + copy.DueDate);
            }
        }

        public static void PrintAllBooks(Repository repo)
        {
            Console.WriteLine("Library \n".PadLeft(27));

            Console.WriteLine("Book ID ".PadRight(17) + "Book Name".PadRight(22) + "Author \n");

            foreach (Book book in repo.GetAllBooks())
            {
                string BookIDstr = book.BookID.ToString();

                if (BookIDstr.Length == 1)
                {
                    BookIDstr = "0" + BookIDstr;
                }

                Console.WriteLine(BookIDstr.PadLeft(5) + " ".PadRight(12) + book.BookName.PadRight(22) + book.Author);
            }
        }

        public static void PrintBookSearch(Repository repo, string TitleAuthor)
        {
            Console.WriteLine("Book Search \n".PadLeft(27));
            Console.WriteLine("Book Name ".PadRight(30) + "Author \n");

            foreach (IEnumerable<Book> searchOption in repo.GetBookBySearch(TitleAuthor))
            {
                if (searchOption.Any())
                {
                    foreach (Book book in searchOption)
                    {
                        Console.WriteLine(book.BookName.PadRight(30) + book.Author.PadRight(30));
                        PrintCopies(repo, book);
                    }
                }
            }
            
        }

        public static void PrintCopies(Repository repo, Book book)
        {
            var copies = repo.GetCopies(book.BookID);
            int availableBooks = 0;

            Console.WriteLine("\nCopies \n");
            Console.WriteLine("Total Copies: " + copies.Count());

            foreach (Copy copy in copies)
            {
                if (copy.DueDate == null)
                {
                    availableBooks += 1;
                    
                }
                else
                {
                    string userName = repo.GetUser(copy.UserID).Name;
                    string dueDate = copy.DueDate;
                    Console.WriteLine("User: " + userName);
                    Console.WriteLine("Due Date: " + dueDate);

                }
            }
            Console.WriteLine("Available Books: " + availableBooks);

        }

        static void Main(string[] args)
        {
            Repository repo = new Repository();

            string myName = "Josh Batt";
            int myUserID = repo.GetUserID(myName);
            string TitleAuthor = "Game Of Thrones";

            //PrintHomepage(repo, myUserID);
            //PrintAllBooks(repo);
            PrintBookSearch(repo, TitleAuthor);

            Console.ReadLine();
        }
    }
    
}
