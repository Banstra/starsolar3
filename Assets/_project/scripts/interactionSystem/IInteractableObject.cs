public interface IInteractableObject
{
    public bool Interact(Interactor interactor, out string prompt);
    public string GetPrompt();
}
