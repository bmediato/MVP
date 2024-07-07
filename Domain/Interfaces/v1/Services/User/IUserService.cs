using Domain.Dtos.v1.User;

namespace Domain.Interfaces.v1.Services.User;

public interface IUserService
{
    public Task<UserDtoResponse> SaveUserAsync(UserDto command);
}
