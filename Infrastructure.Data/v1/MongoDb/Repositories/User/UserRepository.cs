using Domain.Interfaces.v1.Configurations;

namespace Infrastructure.Data.v1.MongoDb.Repositories.User;

public class UserRepository : IUserMongoDbRepository 
{
    private readonly IMongoCollection<UserMongoDb> _user;

    public UserRepository(IDatabaseConfig databaseConfig)
    {
        var client = new MongoClient(databaseConfig.ConnectionString);
        var database = client.GetDatabase(databaseConfig.DatabaseName);

        _user = database.GetCollection<UserMongoDb>("users");
    }

    public async Task UpsertAsync(UserMongoDb user)
    {
        await _user.InsertOneAsync(user);
    }
}
