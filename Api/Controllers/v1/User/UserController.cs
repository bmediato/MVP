using Domain.Dtos.v1.User;
using Domain.Interfaces.v1.Services.User;

namespace Api.Controllers.v1.Login;

/// <summary>
/// UserController
/// </summary>
[Route("api/v1/user")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpPost("save")]
    [ProducesResponseType(typeof(UserSaveCommandResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> SaveUser([FromBody] UserDto request)
    {
        try
        {
            var user = await _service.SaveUserAsync(new UserDto(request.UserName, request.Email, request.Password, request.Address, request.PhoneNumber));
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Houve um erro ao cadastrar o usuário! {ex.Message}" });
        }
    }
}
