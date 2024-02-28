internal class BooksList
{
    private Book[] books;
    public int Size { get; private set; }
    public BooksList()
    {
        books = new Book[30];
    }
    public BooksList(int capacity)
    {
        books = new Book[capacity];
    }
    public Book this[string book_title]
    {
        get
        {
            for (int i = 0; i < Size; i++)
            {
                if (book_title == books[i].Title)
                {
                    return books[i];
                }
            }
            throw new IndexOutOfRangeException("Book out of list");
        }
    }
    public Book this[int index]
    {
        get
        {
            if (index >= 0 || index < Size)
            {
                return books[index];
            }
            throw new IndexOutOfRangeException("Index out of range");
        }
    }
    public void Clear()
    {
        Size = 0;
    }
    public int Find(Book book)
    {
        for (int i = 0; i < Size; i++)
        {
            if (books[i] == book)
            {
                return i;
            }
        }
        return -1;
    }
    public void Remove(int index)
    {
        if (index >= 0 || index < Size)
        {
            for (int i = index; i < Size - 1; i++)
            {
                var temp = books[i];
                books[i] = books[i + 1];
                books[i + 1] = temp;
            }
            Size--;
        }
        else
        {
            throw new IndexOutOfRangeException("Index out of range");
        }
    }
    public static BooksList operator +(BooksList left, Book right)
    {
        if (left.Size + 1 <= left.books.Length)
        {
            string title = right.Title;
            string writer = right.Writer;
            int sheetscount = right.SheetsCount;
            left.books[left.Size] = new Book(title, writer, sheetscount);
            left.Size++;
            return left;
        }
        throw new IndexOutOfRangeException("Out of capacity");
    }
    public static BooksList operator +(BooksList left, BooksList right)
    {
        if (left.Size + right.Size <= left.books.Length)
        {
            for (int i = 0; i < right.Size; i++)
            {
                string title = right.books[i].Title;
                string writer = right.books[i].Writer;
                int sheetscount = right.books[i].SheetsCount;
                left.books[left.Size + i] = new Book(title, writer, sheetscount);
                left.Size++;
            }
            return left;
        }
        throw new IndexOutOfRangeException("Out of capacity");
    }
    public static BooksList operator -(BooksList left, Book right)
    {
        for (int i = 0; i < left.Size; i++)
        {
            if (left.books[i] == right)
            {
                left.Remove(i);
                return left;
            }
        }
        throw new IndexOutOfRangeException("Book out of list");
    }
    public override string ToString()
    {
        string result = string.Empty;
        result += "List of books to read:\n\n";
        for (int i = 0; i < Size; i++)
        {
            result += $"|  {i + 1}. {books[i]}";
            if (i == Size - 1)
            {
                result += ".\n";
            }    
            else
            {
                result += ";\n\n";
            }
        }
        return result;
    }
    public static bool operator <(BooksList left, BooksList right)
    {
        return left.Size < right.Size;
    }
    public static bool operator >(BooksList left, BooksList right)
    {
        return left.Size > right.Size;
    }
    public static bool operator true(BooksList book)
    {
        return book.Size != 0 ? true : false;
    }
    public static bool operator false(BooksList book)
    {
        return book.Size == 0 ? true : false;
    }
    public static bool operator ==(BooksList left, BooksList right)
    {
        if (left.Size != right.Size)
        {
            return false;
        }
        for (int i = 0; i < left.Size; i++)
        {
            if (left.books[i] != right.books[i])
            {
                return false;
            }
        }
        return true;
    }
    public static bool operator !=(BooksList left, BooksList right)
    {
        if (left.Size != right.Size)
        {
            return true;
        }
        for (int i = 0; i < left.Size; i++)
        {
            if (left.books[i] != right.books[i])
            {
                return true;
            }
        }
        return false;
    }
    public static BooksList operator |(BooksList left, BooksList right)
    {
        if (left.Size != 0 || right.Size != 0)
        {
            return left;
        }
        return new BooksList();
    }
    public static BooksList operator &(BooksList left, BooksList right)
    {
        if (left.Size != 0 && right.Size != 0)
        {
            return right;
        }
        return new BooksList();
    }
}
