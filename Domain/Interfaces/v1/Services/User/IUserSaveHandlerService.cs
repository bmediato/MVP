namespace Domain.Interfaces.v1.Services.User;

public interface IUserSaveHandlerService
{
    public Task<UserSaveCommandResponse> SaveAsync(UserSaveCommand command);
}
