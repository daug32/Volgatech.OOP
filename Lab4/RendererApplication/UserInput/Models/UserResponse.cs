namespace RendererApplication.UserInput.Models;

public class UserResponse
{
    public UserResponse( UserAction action, string? input = null )
    {
        UserAction = action;
        Input = input;
    }

    public UserAction UserAction { get; init; }

    public string? Input { get; init; }
}