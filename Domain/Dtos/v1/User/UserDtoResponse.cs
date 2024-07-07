namespace Domain.Dtos.v1.User;

public class UserDtoResponse
{
    public UserDtoResponse Error(string message)
    {
        Success = false;
        Message = message;

        return this;
    }

    public bool Success { get; set; } = true;
    public string Message { get; set; }
}
