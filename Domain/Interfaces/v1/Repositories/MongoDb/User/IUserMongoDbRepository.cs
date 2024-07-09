namespace Domain.Interfaces.v1.Repositories.MongoDb.User;

public interface IUserMongoDbRepository
{
    Task UpsertAsync(UserMongoDb request);

    Task<UserMongoDb> GetByEmailAsync(string email);
}
