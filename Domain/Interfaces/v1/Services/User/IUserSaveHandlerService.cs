using Domain.Dtos.v1.User;

namespace Domain.Interfaces.v1.Services.User;

public interface IUserSaveHandlerService
{
    public Task<UserSaveCommandResponse> SaveUserAsync(UserSaveCommand command);
}
