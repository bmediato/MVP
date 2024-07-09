namespace Domain.Interfaces.v1.Services.Restaurants;

public interface IRestaurantSaveHandlerService
{
    Task<RestaurantsSaveCommandResponse> SaveAsync(RestaurantsSaveCommand request);
}
