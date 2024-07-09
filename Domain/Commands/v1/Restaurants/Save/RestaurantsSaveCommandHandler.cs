namespace Domain.Commands.v1.Restaurants.Save;

public class RestaurantsSaveCommandHandler : IRestaurantSaveHandlerService
{
    private readonly IMapper _mapper;
    private readonly ILogger<RestaurantsSaveCommandHandler> _logger;
    private readonly IRestaurantMongoDbRepository _restaurantMongoDbRepository;

    public RestaurantsSaveCommandHandler(
        IMapper mapper,
        ILoggerFactory logger,
        IRestaurantMongoDbRepository restaurantMongoDbRepository)
    {
        _mapper = mapper;
        _logger = logger.CreateLogger<RestaurantsSaveCommandHandler>();
        _restaurantMongoDbRepository = restaurantMongoDbRepository;
    }

    public async Task<RestaurantsSaveCommandResponse> SaveAsync(RestaurantsSaveCommand request)
    {
        var response = new RestaurantsSaveCommandResponse();

        try
        {
            _logger.LogInformation(
                    $"[{nameof(RestaurantsSaveCommandHandler)}].Handle - Início | Restaurant: {request.Name}"
                    );

            var restaurant = _mapper.Map<RestaurantsMongoDb>(
            source: request);

            await _restaurantMongoDbRepository.UpsertAsync(restaurant);

            _logger.LogInformation(
              $"[{nameof(RestaurantsSaveCommandHandler)}].Handle - Fim | user: {request.Name}"
              );

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(
                   ex,
                   $"[{nameof(RestaurantsSaveCommandHandler)}].Handle"
                   );

            return response.Error("Erro inesperado! Tente novamente mais tarde.");
        }
    }
}
