namespace Domain.Interfaces.v1.Services.Restaurants;

public interface IRestaurantService
{
    Task<IEnumerable<RestaurantsGetQueryResponse>> GetAsync(RestaurantsGetQuery request);
    Task<RestaurantsSaveCommandResponse> SaveAsync(RestaurantsSaveCommand request);
    Task<RestaurantsGetByIdQueryResponse> GetByIdAsync(RestaurantsGetByIdQuery request);
}
