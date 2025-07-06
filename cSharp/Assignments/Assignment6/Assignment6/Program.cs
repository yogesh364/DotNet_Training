using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    //program to store and display bookname and authorname in bookshelf
    class books
    {
        public string authorName { get; set; }
        public string bookName { get; set; }

        public books(string AuthorName, string BookName)
        {
            authorName = AuthorName;
            bookName = BookName;
        }
        int i = 0;
        public void display()
        {
            Console.WriteLine($"The Books in shelf {i++} is BookName : {bookName} and AuhtorName : {authorName}");
        }
    }
    class bookShelf
    {
        books[] book = new books[5];

        public books this[int index]
        {
            get
            {
                if (index >= 0 && index < book.Length)
                    return book[index];
                else
                    throw new IndexOutOfRangeException("Enter the valid Index to get from BookShelf");
            }
            set
            {
                if (index >= 0 && index < book.Length)
                    book[index] = (books)value;
                else
                    throw new IndexOutOfRangeException("Enter the valid index to get from BookShelf");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bookShelf bs = new bookShelf();
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Enter the Author Name and BookName for Shelf " + i);
                    Console.Write("AuthorName : ");
                    string name = Console.ReadLine();
                    Console.Write("BookName : ");
                    string bname = Console.ReadLine();
                    bs[i] = new books(name, bname);
                }

                Console.WriteLine("------------Displaying the elements in BookShelf------------");

                for (int i = 0; i < 5; i++)
                {
                    bs[i].display();
                }
            }catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
