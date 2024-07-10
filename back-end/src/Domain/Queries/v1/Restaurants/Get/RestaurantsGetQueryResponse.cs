namespace Domain.Queries.v1.Restaurants.Get;

public class RestaurantsGetQueryResponse
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public RestaurantCategory Category { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Logo { get; set; }
    public string Banner { get; set; }
    public IEnumerable<Dishes> Dishes { get; set; }
}
