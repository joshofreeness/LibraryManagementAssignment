using LibraryService;

public class AddAction : IAction  {
    private string _title = "";
    private string _author = "";
    private string _ISBN = "";

    private BookManagementService _bookManagementService;

    public AddAction(BookManagementService bookManangementService){
        _bookManagementService = bookManangementService;
    }

    public ActionResult Execute() {
        CollectInformation();

        try {
            _bookManagementService.AddBookToLibrary(_title, _author, _ISBN);
        } catch (InvalidISBNException) {
            return new ActionResult { Succeeded = false, ErrorMessage = "Invalid ISBN" };
        }

        return ActionResult.Success();;
    }

    private void CollectInformation()
    {
        Console.WriteLine("Please provide the details of the new book:");
        Console.Write("Book title:");
        _title = Console.ReadLine() ?? "";

        Console.Write("Book author:");
        _author = Console.ReadLine() ?? "";

        Console.Write("ISBN:");
        _ISBN = Console.ReadLine() ?? "";
    }
}