namespace Domain.Entities.v1.MongoDb.User;

public class UserMongoDb
{
    public Guid id { get; set; } 
    public string userName { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string address { get; set; }
    public string phoneNumber { get; set; }
}
