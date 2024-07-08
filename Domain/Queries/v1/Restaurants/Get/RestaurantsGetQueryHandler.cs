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

    public async Task<IEnumerable<RestaurantsGetQueryResponse>> GetAsync(RestaurantsGetQuery query)
    {
        try
        {
            _logger.LogInformation(
                  $"[{nameof(RestaurantsGetQueryHandler)}].Handle - Início"
                  );

            var resultRestaurants = await _restaurantMongoDbRepository.GetAllAsync();


            if (request.Id != null)
            {
                filteredNotifications = filteredNotifications.Where(notification =>
                   notification.Employees.Any(employee => employee.Id == request.Id) ||
                   notification.Template.ToLower().Contains(request.Id.ToLower()) ||
                   notification.UserName.ToLower().Contains(request.Id.ToLower()));
            }

            if (request.Status != null)
            {
                filteredNotifications = filteredNotifications.Where(notification => notification.Status == request.Status);
            }

            var

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
