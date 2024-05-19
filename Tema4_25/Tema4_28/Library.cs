using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema4_28
{
    internal class Library
    {
        public List<Book> books = new List<Book>();
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public void RemoveBook(string isbn)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].isbn == isbn)
                {
                    books.RemoveAt(i);
                }
            }
        }
        public void ListBooks()
        {
            foreach (var item in books)
            {
                Console.WriteLine($"{item.title} {item.author} {item.isbn} {item.publicationYear}");
            }
        }
    }
}
