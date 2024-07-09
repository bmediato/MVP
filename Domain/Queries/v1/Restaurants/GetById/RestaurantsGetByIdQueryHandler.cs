namespace Domain.Queries.v1.Restaurants.GetById;

public class RestaurantsGetByIdQueryHandler : IRequestHandler<RestaurantsGetByIdQuery, RestaurantsGetByIdQueryResponse>
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

    public async Task<RestaurantsGetByIdQueryResponse> Handle(RestaurantsGetByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation(
                  $"[{nameof(RestaurantsGetByIdQueryHandler)}].Handle - Início"
                  );

            var resultRestaurant = await _restaurantMongoDbRepository.GetByIdAsync(request.Id);

            var mapperRestaurant = _mapper.Map<RestaurantsGetByIdQueryResponse>(
                source: resultRestaurant);

            _logger.LogInformation(
                 $"[{nameof(RestaurantsGetByIdQueryHandler)}].Handle - Fim"
                 );

            return mapperRestaurant;
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
