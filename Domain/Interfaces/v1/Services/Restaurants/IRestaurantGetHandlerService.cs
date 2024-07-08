using Domain.Queries.v1.Restaurants.Get;

namespace Domain.Interfaces.v1.Services.Restaurants;

public interface IRestaurantGetHandlerService
{
    public Task<IEnumerable<RestaurantsGetQueryResponse>> GetAsync(RestaurantsGetQuery command);
}
