namespace Domain.Interfaces.v1.Services.Restaurants;

public interface IRestaurantGetByIdHandlerService
{
    Task<RestaurantsGetByIdQueryResponse> GetByIdAsync(RestaurantsGetByIdQuery query);
}
