namespace Domain.Entities.v1.MongoDb.Restaurants;

public class RestaurantsMongoDb
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Logo { get; set; }
    public IEnumerable<Dishes> Dishes { get; set; }
}
