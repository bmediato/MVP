namespace Api.Controllers.v1.Login;

/// <summary>
/// UserController
/// </summary>
[Route("api/v1/user")]
[ApiController]
[EnableCors]
public class UserController : Controller
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserController"/> class!
    /// </summary>
    /// <param name="mediator">The mediatorService.</param>
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Save users v1.
    /// </summary>
    /// <param name="request">The User request</param>
    [HttpPost("save")]
    [ProducesResponseType(typeof(UserSaveCommandResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> SaveUser([FromBody] UserSaveCommand request)
    {
        try
        {
            var user = await _mediator.Send(new UserSaveCommand(request.UserName, request.Email, request.Password, request.Address, request.PhoneNumber));
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Houve um erro ao cadastrar o usuário! {ex.Message}" });
        }
    }

    /// <summary>
    /// Login users v1.
    /// </summary>
    /// <param name="request">The User request</param>
    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginUserQueryResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginUserQuery request)
    {
        try
        {
            var token = await _mediator.Send(new LoginUserQuery(request.Email, request.Password));
            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Houve um erro ao tentar realizar o login! {ex.Message}" });
        }
    }
}
