namespace Domain.Commands.v1.Restaurants.Save;

public class RestaurantsSaveCommandHandler : IRequestHandler<RestaurantsSaveCommand, RestaurantsSaveCommandResponse> //IRestaurantSaveHandlerService
{
    private readonly IMapper _mapper;
    private readonly ILogger<RestaurantsSaveCommandHandler> _logger;
    private readonly IRestaurantMongoDbRepository _restaurantMongoDbRepository;
    private readonly IValidator<RestaurantsSaveCommand> _validator;

    public RestaurantsSaveCommandHandler(
        IMapper mapper,
        ILoggerFactory logger,
        IRestaurantMongoDbRepository restaurantMongoDbRepository,
        IValidator<RestaurantsSaveCommand> validator)
    {
        _mapper = mapper;
        _logger = logger.CreateLogger<RestaurantsSaveCommandHandler>();
        _restaurantMongoDbRepository = restaurantMongoDbRepository;
        _validator = validator;
    }

    public async Task<RestaurantsSaveCommandResponse> Handle(RestaurantsSaveCommand request, CancellationToken cancellationToken)
    {
        var response = new RestaurantsSaveCommandResponse();

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning($"[{nameof(RestaurantsSaveCommandHandler)}].Handle - Validação falhou para o restaurante: {request.Name}");
            return response.Error(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
        }
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
