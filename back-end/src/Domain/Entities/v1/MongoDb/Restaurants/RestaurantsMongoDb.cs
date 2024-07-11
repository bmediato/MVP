namespace Domain.Entities.v1.MongoDb.Restaurants;

public class RestaurantsMongoDb
{
    public Guid id { get; set; }
    public string name { get; set; }
    public RestaurantCategory category { get; set; }
    public string description { get; set; }
    public string address { get; set; }
    public string phoneNumber { get; set; }
    public string logo { get; set; }
    public string banner { get; set; }
    public IEnumerable<Dishes> dishes { get; set; }
}
