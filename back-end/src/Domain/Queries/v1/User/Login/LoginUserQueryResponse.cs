namespace Domain.Queries.v1.User.Login;

public class LoginUserQueryResponse
{
    public LoginUserQueryResponse Error(string message)
    {
        Success = false;
        Message = message;

        return this;
    }
    public string Token { get; set; }
    public bool Success { get; set; } = true;
    public string Message { get; set; }
    public string Name { get; set; }
    public string Address { get;set; }
}
