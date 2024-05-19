using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema4_28
{
    internal class Book
    {
        public string title;
        public string author;
        public string isbn;
        public int publicationYear;
        public Book(string title, string author, string isbn, int publicationYear)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.publicationYear = publicationYear;
        }
    }
}
