using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema4_28
{
    internal class Reader
    {
        public string name;
        public Reader(string name)
        {
            this.name = name;
        }
        public void BorrowBook(Library library,string isbn)
        {
            library.RemoveBook(isbn);
        }
        public void ReturnBook(Library library,Book book)
        {
            library.AddBook(book);
        }
    }
}
