namespace Api.Controllers.v1.Login;

/// <summary>
/// UserController
/// </summary>
[Route("api/v1/user")]
[ApiController]
public class UserController : Controller
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("save")]
    [ProducesResponseType(typeof(UserSaveCommandResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> SaveUser([FromBody] UserSaveCommand request)
    {
        var result = await _mediator.Send(request);

        return Ok(result);
    }
}
