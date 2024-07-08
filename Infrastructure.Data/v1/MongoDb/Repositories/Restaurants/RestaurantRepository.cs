namespace Infrastructure.Data.v1.MongoDb.Repositories.Restaurants;

public class RestaurantRepository : IRestaurantMongoDbRepository
{
    private readonly IMongoCollection<RestaurantsMongoDb> _restaurant;

    public RestaurantRepository(IDatabaseConfig databaseConfig)
    {
        var client = new MongoClient(databaseConfig.ConnectionString);
        var database = client.GetDatabase(databaseConfig.DatabaseName);

        _restaurant = database.GetCollection<RestaurantsMongoDb>("restaurants");
    }

    //public async Task UpsertAsync(RestaurantsMongoDb restaurant)
    //{
    //    await _restaurant.InsertOneAsync(restaurant);
    //}

    //public async Task<IEnumerable<RestaurantsMongoDb>> GetAllAsync()
    //{
    //    await _restaurant.
    //}
    public async Task UpsertAsync(RestaurantsMongoDb restaurant)
    {
        await _restaurant.ReplaceOneAsync(
            filter: r => r.Name == restaurant.Name,
            replacement: restaurant,
            options: new ReplaceOptions { IsUpsert = true });
    }

    public async Task<IEnumerable<RestaurantsMongoDb>> GetAllAsync()
    {
        var result = await _restaurant.Find(FilterDefinition<RestaurantsMongoDb>.Empty).ToListAsync();
        return result;
    }
}
