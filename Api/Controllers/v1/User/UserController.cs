namespace Api.Controllers.v1.Login;

/// <summary>
/// UserController
/// </summary>
[Route("api/v1/user")]
[ApiController]
[EnableCors]
public class UserController : Controller
{
    private readonly IUserSaveHandlerService _userService;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserController"/> class!
    /// </summary>
    /// <param name="IUserService">The UserService.</param>
    public UserController(IUserSaveHandlerService userService)
    {
        _userService = userService;
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
            var user = await _userService.SaveAsync(new UserSaveCommand(request.UserName, request.Email, request.Password, request.Address, request.PhoneNumber));
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Houve um erro ao cadastrar o usuário! {ex.Message}" });
        }
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginCommandResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginCommand request)
    {
        try
        {
            var token = await _authenticationService.AuthenticateAsync(request.Username, request.Password);
            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Houve um erro ao tentar realizar o login! {ex.Message}" });
        }
    }
}
