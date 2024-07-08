namespace Domain.Interfaces.v1.Services.Restaurants;

public interface IRestaurantSaveHandlerService
{
    public Task<RestaurantsSaveCommandResponse> SaveAsync(RestaurantsSaveCommand command);
}
