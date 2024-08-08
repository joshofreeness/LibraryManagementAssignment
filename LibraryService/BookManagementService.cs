using DataAccess;

namespace LibraryService;

public class BookManagementService
{
    private IRepository<Book> _bookRepository;
    public BookManagementService(IRepository<Book> repository) {
        _bookRepository = repository;
    }

    public void AddBookToLibrary(string title, string author, string ISBN){
        
        var isbnClean = CleanISBN(ISBN);
        var valid = ValidateISBN(isbnClean);

        if(!valid) {
            throw new InvalidISBNException();
        }

        var book = new Book {
            Title = title,
            Author = author,
            ISBN = isbnClean
        };

        _bookRepository.Add(book);
    }

    public List<Book> List() {
        return _bookRepository.ListAll();
    }

    public Book FindBook(string isbn) {
        return _bookRepository.Find(CleanISBN(isbn));
    }

    public void Update(string isbn, Book book) {
        _bookRepository.Update(CleanISBN(isbn), book);
    }

    public void Delete(string isbn) {
        _bookRepository.Delete(CleanISBN(isbn));
    }

    /// <summary>
    /// Onlu validating 10 digit ISBN specification not 13 digit
    /// </summary>
    public bool ValidateISBN(string isbn) {
        //Must be 10 digits
        if(isbn.Length != 10)
            return false;

        var multipliedSum = 0;
        for(int i=0; i< 10; i++) {
            //subtract char 0 to convert to int, except X which is 10
            int value;
            if(isbn[i] == 'X')
                value = 10;
            else
                value = isbn[i] - '0';

            //multiply each position from 10 down to 1.
            // 10, 9, 8, ... etc
            multipliedSum += value * (10 - i);
        }

        // Valid if no remainder when divided by 11
        return multipliedSum % 11 == 0;
    }

    // ISBN can be formatted with extra chars for
    // human readiability e.g. "-" we don't need them.
    private string CleanISBN(string isbn) {
        var isbnClean = string.Concat(isbn.Where(
            c => char.IsDigit(c) || c == 'X'));
        return isbnClean;
    }
}
