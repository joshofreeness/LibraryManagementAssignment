

namespace DataAccess;

/// <summary>
/// A basic in memory "database" for the purpose of this exercise
/// </summary>
public class Database {

    // This would normally have another class or similar for actual storage formats
    // but because it is just in memeory for this demo we can just store the object that
    // will be returned by the repository, as there is no need to worry about
    // versioning of data formats which may change compared to the business objects
    // during development/changing requirements.
    private static Dictionary<string, Book> _books = new Dictionary<string, Book>();

    public void Add(Book book) {
        if(book.ISBN is null) {
            throw new ArgumentException("Can not store a book without an ISBN");
        }
        _books.Add(book.ISBN, book);
    }

    public List<Book> GetAll() {
        return _books.Values.ToList();
    }

    public Book Find(string isbn) {
        return _books[isbn];
    }

    public void Update(string isbn, Book newValues){
        _books[isbn].Author = newValues.Author;
        _books[isbn].Title = newValues.Title;
    }

    public bool Delete(string isbn) {
        return _books.Remove(isbn);
    }

    public void ClearAll() {
        _books = new Dictionary<string, Book>();
    }

}