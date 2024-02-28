internal class Book
{
    public string Title { get; }
    public string Writer { get; }
    public int SheetsCount { get; }
    public Book()
    {
        Title = string.Empty;
        Writer = string.Empty;
        SheetsCount = 0;
    }
    public Book(string title, string writer, int sheetscount)
    {
        Title = title;
        Writer = writer;
        SheetsCount = sheetscount;
    }
    public override string ToString()
    {
        return $"Title: {Title} | Writer: {Writer} | Sheets' count: {SheetsCount}";
    }
    public override bool Equals(object? obj)
    {
        return ToString() == obj.ToString();
    }
    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }
    public static bool operator <(Book left, Book right)
    {
        return left.SheetsCount < right.SheetsCount;
    }
    public static bool operator >(Book left, Book right)
    {
        return left.SheetsCount > right.SheetsCount;
    }
    public static bool operator true(Book book)
    {
        return book.SheetsCount != 0 ? true : false;
    }
    public static bool operator false(Book book)
    {
        return book.SheetsCount == 0 ? true : false;
    }
    public static bool operator ==(Book left, Book right)
    {
        return left.Equals(right);
    }
    public static bool operator !=(Book left, Book right)
    {
        return !left.Equals(right);
    }
    public static Book operator |(Book left, Book right)
    {
        if (left.SheetsCount != 0 || right.SheetsCount != 0)
        {
            return left;
        }
        return new Book();
    }
    public static Book operator &(Book left, Book right)
    {
        if (left.SheetsCount != 0 && right.SheetsCount != 0)
        {
            return right;
        }
        return new Book();
    }
}
