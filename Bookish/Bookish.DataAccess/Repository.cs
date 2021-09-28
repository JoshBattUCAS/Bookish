using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.DataAccess
{
    public class Repository
    {
        private static string connectionString = @"Server=localhost;Database=Bookish;Trusted_connection=True;";
        SqlConnection connection = new SqlConnection(connectionString);

        public int GetUserID(string name)
        {
            return connection.Query<int>("SELECT UserID FROM person WHERE Name = '" + name +"'").First();
        }

        public Book GetBook(int bookID)
        {
            return connection.Query<Book>("SELECT * FROM book WHERE BookID = '" + bookID + "'").First();
        }

        public Person GetUser(int userID)
        {
            return connection.Query<Person>("SELECT * FROM person WHERE UserID = '" + userID + "'").First();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return connection.Query<Book>("SELECT * FROM book");
        }
        public IEnumerable<Copy> GetMyBooks(int myUserID)
        {
            return connection.Query<Copy>("SELECT * FROM copy WHERE UserID = '" + myUserID + "'");
        }
        public List<IEnumerable<Book>> GetBookBySearch(string TitleAuthor)
        {
            List<IEnumerable<Book>> TitleAuthorList = new List<IEnumerable<Book>>();

            var titleSearch = connection.Query<Book>("SELECT * FROM book WHERE BookName = '" + TitleAuthor + "'");
            var authorSearch = connection.Query<Book>("SELECT * FROM book WHERE Author = '" + TitleAuthor + "'");

            TitleAuthorList.Add(titleSearch);
            TitleAuthorList.Add(authorSearch);

            return TitleAuthorList;
     
        }
        public IEnumerable<Copy> GetCopies(int bookID)
        {
            var copies = connection.Query<Copy>("SELECT * FROM copy WHERE BookID = '" + bookID + "'");

            return copies;
        }


    }   

}
