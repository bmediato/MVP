namespace Domain.Dtos.v1.User;

public class UserDto
{
    public UserDto(string userName, string email, string password, string address, string phoneNumber)
    {
        UserName = userName;
        Email = email;
        Password = password;
        Address = address;
        PhoneNumber = phoneNumber;
        UserId = Guid.NewGuid();
    }
    public Guid? UserId { get; set; } 
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}
