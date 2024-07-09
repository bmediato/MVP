namespace Domain.Queries.v1.Restaurants.Get;

public class RestaurantsGetQueryHandler : IRestaurantGetHandlerService
{
    private readonly IMapper _mapper;
    private readonly ILogger<RestaurantsGetQueryHandler> _logger;
    private readonly IRestaurantMongoDbRepository _restaurantMongoDbRepository;

    public RestaurantsGetQueryHandler(IMapper mapper,
        ILoggerFactory logger,
        IRestaurantMongoDbRepository restaurantMongoDbRepository)
    {
        _mapper = mapper;
        _logger = logger.CreateLogger<RestaurantsGetQueryHandler>();
        _restaurantMongoDbRepository = restaurantMongoDbRepository;
    }

    public async Task<IEnumerable<RestaurantsGetQueryResponse>> GetAsync(RestaurantsGetQuery request)
    {
        try
        {
            _logger.LogInformation(
                  $"[{nameof(RestaurantsGetQueryHandler)}].Handle - Início"
                  );

            var resultRestaurants = await _restaurantMongoDbRepository.GetAllAsync();
            var filteredRestaurants = resultRestaurants.AsQueryable();

            if (request.Name != null)
            {

                filteredRestaurants = filteredRestaurants.Where(restaurant => restaurant.Name.ToLower()
                .Contains(request.Name.ToLower()) || restaurant.Dishes.Any(dishes => dishes.Name.ToLower()
                .Contains(request.Name) || dishes.Description.ToLower().Contains(request.Name)));
            }

            if (request.Category != null)
            {
                filteredRestaurants = filteredRestaurants.Where(restaurant => restaurant.Category == request.Category);
            }

            var mapperRestaurant = _mapper.Map<IEnumerable<RestaurantsGetQueryResponse>>(
                source: filteredRestaurants.ToList());

            _logger.LogInformation(
                  $"[{nameof(RestaurantsGetQueryHandler)}].Handle - Fim"
                  );

            return mapperRestaurant;

        }
        catch (Exception ex)
        {
            _logger.LogError(
                   ex,
                   $"[{nameof(RestaurantsGetQueryHandler)}].Handle"
                   );

            throw ex;
        }
    }
}
