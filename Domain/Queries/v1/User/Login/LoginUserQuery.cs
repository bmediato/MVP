namespace Domain.Queries.v1.User.Login;

public class LoginUserQuery : IRequest<LoginUserQueryResponse>
{
    public LoginUserQuery(string email, string password)
    {
        Email = email;
        Password = password;
    }
    public string Email { get; set; }
    public string Password { get; set; }
}
