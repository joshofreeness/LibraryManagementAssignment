using LibraryService;

public class DeleteAction : IAction  {

    private BookManagementService _bookManagementService;

    public DeleteAction(BookManagementService bookManangementService){
        _bookManagementService = bookManangementService;
    }

    public ActionResult Execute() {
        Console.Write("Input ISBN of book to delete: ");
        var isbn = Console.ReadLine() ?? "";

        try {
            _bookManagementService.Delete(isbn);
        } catch (BookNotFoundException) {
            return new ActionResult {
                Succeeded = false,
                ErrorMessage = "ISBN Not found"
            };
        } 

        return ActionResult.Success();
    }
}