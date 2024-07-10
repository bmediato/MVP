namespace Domain.Commands.v1.Login;

public class LoginCommand
{
    public LoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
    public string Email { get; set; }
    public string Password { get; set; }
}
