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
        var existingUser = await _user.Find(u => u.Email == user.Email).FirstOrDefaultAsync();

        if (existingUser != null)
        {
            user.Id = existingUser.Id; 
        }

        await _user.ReplaceOneAsync(
            filter: u => u.Email == user.Email,
            replacement: user,
            options: new ReplaceOptions { IsUpsert = true });
    }

    public async Task<UserMongoDb> GetByEmailAsync(string email)
    {
        var filter = Builders<UserMongoDb>.Filter.Eq(user => user.Email, email); 
        var result = await _user.Find(filter).FirstOrDefaultAsync();
        return result;
    }
}
