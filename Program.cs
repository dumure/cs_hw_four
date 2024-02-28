internal class Program
{
    static void Main(string[] args)
    {
        BooksList books = new BooksList(15);
        Book book1 = new Book("War and Peace", "Leo Tolstoy", 1274);
        Book book2 = new Book("Crime and Punishment", "Fyodor Dostoevsky", 672);
        Book book3 = new Book("The Master and Margarita", "Mikhail Bulgakov", 789);
        books += book1;
        books += book2;
        books += book3;
        Console.WriteLine(books);
        books -= book3;
        Console.WriteLine(books);
    }
}
