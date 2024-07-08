using Domain.Enums.v1;

namespace Api.Controllers.v1.Restaurants;

/// <summary>
/// RestaurantsController
/// </summary>
[Route("api/v1/restaurants")]
[ApiController]
public class RestaurantsController : Controller
{
    private readonly IRestaurantSaveHandlerService _restaurantService;


    /// <summary>
    /// Initializes a new instance of the <see cref="RestaurantsController"/> class!
    /// </summary>
    /// <param name="IRestaurantSaveHandlerService">The RestaurantsService.</param>
    public RestaurantsController(IRestaurantSaveHandlerService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    /// <summary>
    /// Save restaurants v1.
    /// </summary>
    /// <param name="request">The Restaurants request</param>
    [HttpPost("save")]
    [ProducesResponseType(typeof(RestaurantsSaveCommandResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> SaveRestaurants([FromBody] RestaurantsSaveCommand request)
    {
        try
        {
            var restaurant = await _restaurantService.SaveAsync(new RestaurantsSaveCommand
                (request.Name,
                request.Category,
                request.Description,
                request.Address,
                request.PhoneNumber,
                request.Logo,
                request.Dishes)
                );
            return Ok(restaurant);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Houve um erro ao cadastrar o usuário! {ex.Message}" });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetRestaurants([FromQuery] string? name, [FromQuery] RestaurantCategory? category)
    {

    }
}
