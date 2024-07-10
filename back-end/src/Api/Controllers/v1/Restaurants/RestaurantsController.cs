namespace Api.Controllers.v1.Restaurants;

/// <summary>
/// RestaurantsController
/// </summary>
[Route("api/v1/restaurants")]
[ApiController]
[EnableCors]
public class RestaurantsController : Controller
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="RestaurantsController"/> class!
    /// </summary>
    /// <param name="mediator">The mediatorService</param>
    public RestaurantsController(
        IMediator mediator)
    {
        _mediator = mediator;
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
            var restaurant = await _mediator.Send(new RestaurantsSaveCommand
               (request.Name,
               request.Category,
               request.Description,
               request.Address,
               request.PhoneNumber,
               request.Logo,
               request.Banner,
               request.Dishes)
               );
            return Ok(restaurant);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Houve um erro ao cadastrar o usuário! {ex.Message}" });
        }
    }

    /// <summary>
    /// Find restaurants by name or category v1.
    /// </summary>
    /// <param name="name">The name restaurant.</param>
    /// <param name="category">The category restaurant.</param>
    /// <returns>The restaurants result.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<RestaurantsGetQueryResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetRestaurants(
        [FromQuery] string? name = null,
        [FromQuery] RestaurantCategory? category = null)
    {
        try
        {
            var restaurant = await _mediator.Send(new RestaurantsGetQuery(name, category));
            return Ok(restaurant);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Houve um erro ao buscar os restaurantes! {ex.Message}" });
        }
    }

    /// <summary>
    /// Find restaurant by id v1.
    /// </summary>
    /// <param name="id">The restaurant id.</param>
    /// <returns>The restaurants result.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IEnumerable<RestaurantsGetQueryResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetRestaurants(Guid id)
    {
        try
        {
            var restaurant = await _mediator.Send(new RestaurantsGetByIdQuery(id));
            return Ok(restaurant);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Houve um erro ao buscar o restaurante! {ex.Message}" });
        }
    }
}
