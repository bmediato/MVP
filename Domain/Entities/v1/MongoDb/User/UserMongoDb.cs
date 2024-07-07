namespace Domain.Entities.v1.MongoDb.User;

public class UserMongoDb
{
    public Guid UserId { get; set; } 
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}
