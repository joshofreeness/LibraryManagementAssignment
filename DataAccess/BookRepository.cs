using DataAccess;

public class BookRepository : IRepository<Book>
{
    private Database _database;
    public BookRepository(Database database) {
        _database = database;
    }

    public void Add(Book entity)
    {
        _database.Add(entity);
    }

    public List<Book> ListAll() {
        return _database.GetAll();
    }
    
    public Book Find(string isbn) {
        try {
            return _database.Find(isbn);
        } catch(KeyNotFoundException e){
            throw new BookNotFoundException($"Book with isbn {isbn} not found", e);
        }
    }

    public void Update(string isbn, Book newValues)
    {
        try {
           _database.Update(isbn, newValues);
        } catch(KeyNotFoundException e){
            throw new BookNotFoundException($"Book with isbn {isbn} not updated", e);
        }
    }

    public void Delete(string isbn) {
        var deleted = _database.Delete(isbn);
        if(!deleted)
            throw new BookNotFoundException($"Book with isbn {isbn} not deleted");
    }
}