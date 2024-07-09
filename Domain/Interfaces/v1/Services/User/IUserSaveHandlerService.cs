namespace Domain.Interfaces.v1.Services.User;

public interface IUserSaveHandlerService
{
    Task<UserSaveCommandResponse> SaveAsync(UserSaveCommand request);
}
