public class ExitAction : IAction  {
    public ActionResult Execute() {
        Environment.Exit(0);
        return ActionResult.Success();
    }

}