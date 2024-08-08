using LibraryService;

public class ListAction : IAction  {

    private BookManagementService _bookManagementService;

    public ListAction(BookManagementService bookManangementService){
        _bookManagementService = bookManangementService;
    }

    public ActionResult Execute() {
        var bookList = _bookManagementService.List();

        Console.Clear();
        foreach(var book in bookList) {
            Console.Write(book.ISBN);
            Console.Write(" :  ");
            Console.WriteLine(book.Title);
        }

        return ActionResult.Success();
    }
}