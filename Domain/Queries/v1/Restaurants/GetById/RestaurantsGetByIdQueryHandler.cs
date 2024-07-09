namespace Domain.Queries.v1.Restaurants.GetById;

public class RestaurantsGetByIdQueryHandler : IRestaurantGetByIdHandlerService
{
    private readonly IMapper _mapper;
    private readonly ILogger<RestaurantsGetByIdQueryHandler> _logger;
    private readonly IRestaurantMongoDbRepository _restaurantMongoDbRepository;

    public RestaurantsGetByIdQueryHandler(IMapper mapper,
        ILoggerFactory logger,
        IRestaurantMongoDbRepository restaurantMongoDbRepository)
    {
        _mapper = mapper;
        _logger = logger.CreateLogger<RestaurantsGetByIdQueryHandler>();
        _restaurantMongoDbRepository = restaurantMongoDbRepository;
    }

    public async Task<RestaurantsGetByIdQueryResponse> GetByIdAsync(RestaurantsGetByIdQuery request)
    {
        try
        {
            _logger.LogInformation(
                  $"[{nameof(RestaurantsGetByIdQueryHandler)}].Handle - Início"
                  );

            //var resultRestaurants = await _restaurantMongoDbRepository.GetAllAsync();

            //var mapperRestaurant = _mapper.Map<IEnumerable<RestaurantsGetQueryResponse>>(
            //    source: filteredRestaurants.ToList());

            //_logger.LogInformation(
            //     $"[{nameof(RestaurantsGetByIdQueryHandler)}].Handle - Fim"
            //     );

            //return mapperRestaurant;
            return new RestaurantsGetByIdQueryResponse();
        }
        catch (Exception ex)
        {
            _logger.LogError(
                   ex,
                   $"[{nameof(RestaurantsGetByIdQueryHandler)}].Handle"
                   );

            throw ex;
        }

    }
}
