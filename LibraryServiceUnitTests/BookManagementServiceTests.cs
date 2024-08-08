using DataAccess;
using LibraryService;
using Moq;

namespace LibraryServiceUnitTests;

public class BookManagementServiceTests
{
    private Mock<IRepository<Book>> _mockBookRepository;
    [SetUp]
    public void Setup()
    {
        _mockBookRepository = new Mock<IRepository<Book>>();   
    }

    [Test]
    public void ValidateISBN_Valid_True()
    {
        var validISBN = "0943396042";
        var service = new BookManagementService(_mockBookRepository.Object);

        var result = service.ValidateISBN(validISBN);

        Assert.That(result, Is.True);
    }

    [Test]
    public void ValidateISBN_ValidContainingX_True()
    {
        var validISBN = "097522980X";
        var service = new BookManagementService(_mockBookRepository.Object);

        var result = service.ValidateISBN(validISBN);

        Assert.That(result, Is.True);
    }

    [Test]
    public void ValidateISBN_InvalidLength_False()
    {
        var validISBN = "123";
        var service = new BookManagementService(_mockBookRepository.Object);

        var result = service.ValidateISBN(validISBN);

        Assert.That(result, Is.False);
    }

    [Test]
    public void ValidateISBN_Invalid_False()
    {
        var validISBN = "999999999X";
        var service = new BookManagementService(_mockBookRepository.Object);

        var result = service.ValidateISBN(validISBN);

        Assert.That(result, Is.False);
    }

    [Test]
    public void AddBookToLibrary_ValidISBN_succeeds()
    {
        _mockBookRepository.Setup(b => b.Add(It.IsAny<Book>()));

        var service = new BookManagementService(_mockBookRepository.Object);

        service.AddBookToLibrary("Title", "Author", "960-425-059-0");

        _mockBookRepository.Verify(b => b.Add(It.IsAny<Book>()), Times.Once());
    }

    [Test]
    public void AddBookToLibrary_InvalidISBN_fails()
    {
        _mockBookRepository.Setup(b => b.Add(It.IsAny<Book>()));
        
        var service = new BookManagementService(_mockBookRepository.Object);

        Assert.Throws<InvalidISBNException>(
             () => service.AddBookToLibrary("Title", "Author", "99")
        );

        _mockBookRepository.Verify(b => b.Add(It.IsAny<Book>()), Times.Never());
    }

    [Test]
    public void FindBook_FormattedISBN_BookFound()
    {
        _mockBookRepository.Setup(b => b.Find(It.IsAny<string>())).Returns(new Book());

        var service = new BookManagementService(_mockBookRepository.Object);

        service.FindBook("960-425-059-0");
        var cleanISBN = "9604250590";

        _mockBookRepository.Verify(b => b.Find(It.Is<string>(s => s == cleanISBN)), Times.Once());
    }
    
    [Test]
    public void Update_FormattedISBN_BookFound()
    {
        _mockBookRepository.Setup(b => b.Update(It.IsAny<string>(), It.IsAny<Book>()));

        var service = new BookManagementService(_mockBookRepository.Object);

        service.Update("960-425-059-0", new Book());
        var cleanISBN = "9604250590";

        _mockBookRepository.Verify(b => b.Update(It.Is<string>(s => s == cleanISBN), It.IsAny<Book>()), Times.Once());
    }

    [Test]
    public void Delete_FormattedISBN_BookFound()
    {
        _mockBookRepository.Setup(b => b.Delete(It.IsAny<string>()));

        var service = new BookManagementService(_mockBookRepository.Object);

        service.Delete("960-425-059-0");
        var cleanISBN = "9604250590";

        _mockBookRepository.Verify(b => b.Delete(It.Is<string>(s => s == cleanISBN)), Times.Once());
    }
}