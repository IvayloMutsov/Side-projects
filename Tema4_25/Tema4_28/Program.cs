namespace Tema4_28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader("Kurva Putkova");
            Book book1 = new Book("C#","Svetlin Nakov","abcd",2017);
            Book book2 = new Book("Java","Svetlin Nakov","acdb",2016);
            Book book3 = new Book("Pod Igoto","Ivan Vazov","abdc",1893);
            Book book4 = new Book("50 shades of gray","Edin nekuv","acbd",1976);
            Library library = new Library();
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);
            library.ListBooks();
            Console.WriteLine();
            library.RemoveBook("acbd");
            library.ListBooks();
            Console.WriteLine();
            reader.BorrowBook(library,"abcd");
            library.ListBooks();
            Console.WriteLine();
            reader.BorrowBook(library, "acdb");
            library.ListBooks();
            Console.WriteLine();
            reader.ReturnBook(library, book2);
            library.ListBooks();
            Console.WriteLine();
            Console.WriteLine("End");
        }
    }
}
