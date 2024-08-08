namespace DataAccess;

public class Book : Entity
{
    /// <summary>
    /// Book title.
    /// </summary>
    public string? Title;

    /// <summary>
    /// Author or authors - full name(s)
    /// </summary>
    public string? Author;
    
    public string? ISBN;
}
