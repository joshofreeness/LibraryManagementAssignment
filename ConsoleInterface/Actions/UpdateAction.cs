using DataAccess;
using LibraryService;

public class UpdateAction : IAction  {

    private BookManagementService _bookManagementService;

    public UpdateAction(BookManagementService bookManangementService){
        _bookManagementService = bookManangementService;
    }

    public ActionResult Execute() {
        Console.Write("Input ISBN of book to update: ");
        var isbn = Console.ReadLine() ?? "";

        var book = _bookManagementService.FindBook(isbn);

        Console.Clear();

        Console.WriteLine("Book found, current details: ");
        Console.WriteLine($"Title: {book.Title}");
        Console.WriteLine($"Author: {book.Author}");
        Console.WriteLine($"ISBN: {book.ISBN}");
        Console.WriteLine();
        Console.WriteLine("Provide new values");
        Console.Write($"Book title ({book.Title}):");
        var newTitle = Console.ReadLine();

        Console.Write($"Book author ({book.Author}):");
        var newAuthor = Console.ReadLine();

        _bookManagementService.Update(isbn, 
            new Book { 
                Title = newTitle, 
                Author = newAuthor,
            }
        );

        return ActionResult.Success();
    }
}