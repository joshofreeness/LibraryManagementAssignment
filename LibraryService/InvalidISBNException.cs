public class InvalidISBNException : Exception
{
    public InvalidISBNException()
    {
    }

    public InvalidISBNException(string message)
        : base(message)
    {
    }

    public InvalidISBNException(string message, Exception inner)
        : base(message, inner)
    {
    }
}