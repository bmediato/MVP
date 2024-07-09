namespace Domain.Interfaces.v1.Services.Login;

public interface ILoginHandlerService
{
    Task<LoginCommandResponse> AuthenticateAsync(LoginCommand command);
}
