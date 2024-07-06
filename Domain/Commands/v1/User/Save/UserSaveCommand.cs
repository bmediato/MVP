namespace Domain.Commands.v1.User.Save;

public class UserSaveCommand : IRequest<UserSaveCommandResponse>
{
    public Guid? UserId { get; set; } = new Guid();
    public string Email { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}
