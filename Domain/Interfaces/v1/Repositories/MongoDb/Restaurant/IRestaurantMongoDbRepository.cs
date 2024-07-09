namespace Domain.Interfaces.v1.Repositories.MongoDb.Restaurant;

public interface IRestaurantMongoDbRepository
{
    Task UpsertAsync(RestaurantsMongoDb request);

    Task<IEnumerable<RestaurantsMongoDb>> GetAllAsync();

    Task<RestaurantsMongoDb> GetByIdAsync(Guid id);
}
