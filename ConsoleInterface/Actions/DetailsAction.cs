using LibraryService;

public class DetailsAction : IAction  {

    private BookManagementService _bookManagementService;

    public DetailsAction(BookManagementService bookManangementService){
        _bookManagementService = bookManangementService;
    }

    public ActionResult Execute() {
        Console.Write("Input ISBN of book for details: ");
        var isbn = Console.ReadLine() ?? "";

        DataAccess.Book book;
        try {
            book = _bookManagementService.FindBook(isbn);
        } catch (BookNotFoundException) {
            return new ActionResult {
                Succeeded = false,
                ErrorMessage = "Book not found"
            };
        }

        Console.WriteLine("Book details:");
        Console.WriteLine($"Title: {book.Title}");
        Console.WriteLine($"Author: {book.Author}");
        Console.WriteLine($"ISBN: {book.ISBN}");

        return ActionResult.Success();
    }
}