namespace Domain.Interfaces.v1.Services.Restaurants;

public interface IRestaurantGetHandlerService
{
    Task<IEnumerable<RestaurantsGetQueryResponse>> GetAsync(RestaurantsGetQuery request);
}
