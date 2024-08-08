using System.Data.Common;
using DataAccess;

namespace DataAccessUnitTests;

public class BookRepositoryTests
{
    private Database _testDb;
    private BookRepository _testRepository;
    
    [SetUp]
    public void Setup()
    {
        //Db is so simple that it can also just be used
        //as the mock database. For an example of mocking see the
        //LibraryServiceUnitTests
        _testDb = new Database();
        _testDb.Add(new Book {Title = "Test title", Author = "Test Author", ISBN = "123"});

        _testRepository = new BookRepository(_testDb);
    }

    [TearDown]
    public void TearDown() 
    {
        _testDb.ClearAll();
    }

    [Test]
    public void Add_ISBNExists_ThrowsAlreadyExists()
    {
        Assert.Throws<ArgumentException>(() => {
            _testRepository.Add(new Book{Title = "Foo", Author = "Bar", ISBN = "123"});
        });
    }

    [Test]
    public void ListAll_ReturnsMany()
    {
        _testDb.Add(new Book {Title = "Test title 2", Author = "Test Author 2", ISBN = "12345"});

        var list = _testRepository.ListAll();
        Assert.That(list.Count, Is.EqualTo(2), "Incorrect number of books returned");

    }

    [Test]
    public void Find_UnknownIsbn_NotFound()
    {
        Assert.Throws<BookNotFoundException>(() => {
            _testRepository.Find("garbage");
        });
    }

    [Test]
    public void Find_ExistingIsbn_Found() 
    {
        var found = _testRepository.Find("123");
        Assert.That(found.ISBN, Is.EqualTo("123"));
    }

    [Test]
    public void Update_IsbnNotExist_NotFound() 
    {
        Assert.Throws<BookNotFoundException>(() => {
            _testRepository.Update("garbage", new Book());
        });
    }

    [Test]
    public void Update_ValidIsbnUpdated()
    {
        _testRepository.Update("123", new Book{Title = "Replaced"});
        var found = _testRepository.Find("123");

        Assert.That(found.Title, Is.EqualTo("Replaced"));
    }

    [Test]
    public void Delete_IsbnNotExist_NotFound()
    {
        Assert.Throws<BookNotFoundException>(() => {
            _testRepository.Delete("garbage");
        });
    }

    [Test]
    public void Delete_ValidIsbn_Deleted()
    {
        _testRepository.Delete("123");
        Assert.Throws<BookNotFoundException>(() => {
            _testRepository.Find("123");
        });
    }
}