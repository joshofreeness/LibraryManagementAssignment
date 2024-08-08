using LibraryService;


internal class ActionFactory {

    /// <summary>
    /// Injected book service - using constructor injection
    /// for simplicity
    /// </summary>
    private BookManagementService _bookService;

    public ActionFactory(BookManagementService bookService) {
        _bookService = bookService;
    }

    internal IAction ResolveAction(string? input) {
        if(input is null)
            throw new UnknownCommandException($"Unknwon command, command empty");

        var lowerInput = input.ToLowerInvariant();

        if(lowerInput.StartsWith("add"))
            return new AddAction(_bookService);

        if(lowerInput.StartsWith("exit"))
            return new ExitAction();

        if(lowerInput.StartsWith("list"))
            return new ListAction(_bookService);
        
        if(lowerInput.StartsWith("update"))
            return new UpdateAction(_bookService);

        if(lowerInput.StartsWith("delete"))
            return new DeleteAction(_bookService);

        if(lowerInput.StartsWith("details"))
            return new DetailsAction(_bookService);

        throw new UnknownCommandException($"Unknwon command {input}");
    }
}