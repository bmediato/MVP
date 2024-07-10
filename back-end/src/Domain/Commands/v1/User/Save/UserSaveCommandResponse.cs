namespace Domain.Commands.v1.User.Save;

public class UserSaveCommandResponse
{
    public UserSaveCommandResponse Error(string message)
    {
        Success = false;
        Message = message;

        return this;
    }

    public bool Success { get; set; } = true;
    public string Message { get; set; }
}
