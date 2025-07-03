using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{

    //program to display books in bookshelf and display the books
    public class books
    {
        string bookName { get; set; }
        string authorName { get; set; }

        public books(string bName, string aName)
        {
            bookName = bName;
            authorName = aName;
        }

        public void display()
        {
            Console.WriteLine($"BookName : {bookName} and AuthorName : {authorName}");
        }
    }
    public class bookShelf
    {
        books[] book = new books[5];

        public books this[int index] 
        {
            get
            {
                if (index == 0) return book[index];
                else if (index == 1) return book[index];
                else if (index == 2) return book[index];
                else if (index == 3) return book[index];
                else if (index == 4) return book[index];
                else return null;
            }
            set
            {
                if (index == 0)  book[index] = value; 
                else if (index == 1) book[index] = value;
                else if (index == 2) book[index] = value;
                else if (index == 3) book[index] = value;
                else if (index == 4) book[index] = value;
            }
        }
        static void Main()
        {
            bookShelf bs = new bookShelf();


            bs[0] = new books ("India of my Dreams", "Mahatma Gandhi");
            bs[1] = new books ("The Indian Struggle", "Subash Chandra Bose");
            bs[2] = new books ("The Discovery of India", "Jawaharlal Nehru");
            bs[3] = new books ("A River Sutra", "Geetha Mehta");
            bs[4] = new books ("Cricket My Style", "Kapil Dev");

            for(int i = 0; i < 5; i++)
            {
                bs[i].display();
            }

            Console.Read();
        }

    }
}
