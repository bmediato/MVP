namespace Domain.Commands.v1.User.Save;

public class UserSaveCommand 
{
    public UserSaveCommand(string userName, string email, string password, string address, string phoneNumber)
    {
        UserName = userName;
        Email = email;
        Password = password;
        Address = address;
        PhoneNumber = phoneNumber;
    }
    public Guid? UserId { get; set; } = new Guid();
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}
