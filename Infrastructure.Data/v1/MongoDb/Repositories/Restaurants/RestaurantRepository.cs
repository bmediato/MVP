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

    public async Task UpsertAsync(RestaurantsMongoDb restaurant)
    {
        var existingRestaurant = await _restaurant.Find(r => r.Name == restaurant.Name).FirstOrDefaultAsync();

        if (existingRestaurant != null)
        {
            restaurant.Id = existingRestaurant.Id;
        }

        await _restaurant.ReplaceOneAsync(
            filter: r => r.Id == restaurant.Id,
            replacement: restaurant,
            options: new ReplaceOptions { IsUpsert = true });
    }

    public async Task<IEnumerable<RestaurantsMongoDb>> GetAllAsync()
    {
        var result = await _restaurant.Find(FilterDefinition<RestaurantsMongoDb>.Empty).ToListAsync();
        return result;
    }

    public async Task<RestaurantsMongoDb> GetByIdAsync(Guid id)
    {
        var filter = Builders<RestaurantsMongoDb>.Filter.Eq(restaurant => restaurant.Id, id); 
        var result = await _restaurant.Find(filter).FirstOrDefaultAsync();
        return result;
    }
}
