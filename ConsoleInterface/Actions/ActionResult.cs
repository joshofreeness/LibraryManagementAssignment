public class ActionResult {
    public bool Succeeded;

    public string? ErrorMessage;

    public static ActionResult Success() {
        return new ActionResult { Succeeded = true };
    }
}