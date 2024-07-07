namespace Domain.Interfaces.v1.Services;

public interface IUnitOfWorkService
{
    UserSaveCommandHandler UserSaveCommandHandler { get; }
}
