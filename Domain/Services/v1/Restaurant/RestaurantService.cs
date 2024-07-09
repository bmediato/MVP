namespace Domain.Services.v1.Restaurant;

public class RestaurantService : IRestaurantService
{
    private readonly IRestaurantSaveHandlerService _restaurantSaveHandlerService;
    private readonly IRestaurantGetHandlerService _restaurantGetHandlerService;
    private readonly IRestaurantGetByIdHandlerService _restaurantGetByIdHandlerService;

    public RestaurantService(
        IRestaurantSaveHandlerService restaurantSaveHandlerService,
        IRestaurantGetHandlerService restaurantGetHandlerService,
        IRestaurantGetByIdHandlerService restaurantGetByIdHandlerService)
    {
        _restaurantSaveHandlerService = restaurantSaveHandlerService;
        _restaurantGetHandlerService = restaurantGetHandlerService;
        _restaurantGetByIdHandlerService = restaurantGetByIdHandlerService;
    }

    public async Task<RestaurantsSaveCommandResponse> SaveAsync(RestaurantsSaveCommand command)
    {
        return await _restaurantSaveHandlerService.SaveAsync(command);
    }

    public async Task<IEnumerable<RestaurantsGetQueryResponse>> GetAsync(RestaurantsGetQuery query)
    {
        return await _restaurantGetHandlerService.GetAsync(query);
    }

    public async Task<RestaurantsGetByIdQueryResponse> GetByIdAsync(RestaurantsGetByIdQuery query)
    {
        return await _restaurantGetByIdHandlerService.GetByIdAsync(query);
    }
}
