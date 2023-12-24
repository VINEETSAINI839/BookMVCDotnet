using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace BookMVCDotnet.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public decimal  BookPrice { get; set; }

        public static List<Book> GetAllBooks()
        {
            List<Book> list = new List<Book>();
            SqlConnection cn = new SqlConnection();
             cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Books;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "getAllBooks";
                SqlDataReader dr = cmd.ExecuteReader();
                 while (dr.Read())
                {
                    list.Add(new Book() { BookId=dr.GetInt32(0),
                        BookName=dr.GetString(1),
                        BookAuthor=dr.GetString(2),
                        BookPrice=dr.GetDecimal(3) });

                }
            }
            catch {
                throw;
                   }
            return list;
        }
        public static Book GetBookDetails(int bookId)
        {
            Book book = new Book();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Books;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "getBookDetails";
                cmd.Parameters.AddWithValue("@BookId", bookId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    book=new Book()
                    {
                        BookId = dr.GetInt32(0),
                        BookName = dr.GetString(1),
                        BookAuthor = dr.GetString(2),
                        BookPrice = dr.GetDecimal(3)
                    };

                }
            }
            catch { throw; }
            return book;
        }

        public static void UpdateBookDetails(Book book)
        {
            //Book book = new Book();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Books;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateBookDetails";
               cmd.Parameters.AddWithValue("@BookId",book.BookId);
                cmd.Parameters.AddWithValue("@BookName",book.BookName);
                cmd.Parameters.AddWithValue("@BookAuthor", book.BookAuthor);
                cmd.Parameters.AddWithValue("@BookPrice", book.BookPrice);
                cmd.ExecuteNonQuery();
               
            }
            catch { throw; }
           
        }


        public static void AddBookDetails(Book book)
        {
            
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Books;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "AddBookDetails";
                //cmd.Parameters.AddWithValue("@BookId",book.BookId);
                cmd.Parameters.AddWithValue("@BookName", book.BookName);
                cmd.Parameters.AddWithValue("@BookAuthor", book.BookAuthor);
                cmd.Parameters.AddWithValue("@BookPrice", book.BookPrice);
                cmd.ExecuteNonQuery();

            }
            catch { throw; }

        }

        public static void DeleteBookDetails(int bookId)
        {
            Book book = new Book();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Books;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "deleteBookDetails";
                cmd.Parameters.AddWithValue("@BookId", bookId);
            
                cmd.ExecuteNonQuery();

            }
            catch { }

        }
    }
}
