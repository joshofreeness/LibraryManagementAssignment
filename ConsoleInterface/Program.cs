
using DataAccess;
using LibraryService;

Console.WriteLine("Welcome to the Library Management System!");

// In a full application this would be configured using
// an IoC framework. But in this simple case we can just use
// constructor injection.
var db = new Database();
var repository = new BookRepository(db);
var bookManangement = new BookManagementService(repository);
var actionFactory = new ActionFactory(bookManangement);

while(true) {
    Console.Write("Command: ");
    var input = Console.ReadLine();

    IAction action;
    try {
        action = actionFactory.ResolveAction(input);
    } catch (UnknownCommandException e) {
        Console.WriteLine(e.Message);
        continue;
    }

    ActionResult result;
    try {
        result = action.Execute();
    } catch (Exception e) {
        result = new ActionResult {
            Succeeded = false,
            ErrorMessage = $"Unknown errror occurred {e.Message}"
        };
    }

    if(!result.Succeeded) {
        var currentBackground = Console.BackgroundColor;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine(result.ErrorMessage);
        Console.BackgroundColor = currentBackground;
        Console.WriteLine();
    } else {
        Console.WriteLine("Operation Complete");
    }

}