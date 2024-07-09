namespace Domain.Queries.v1.Restaurants.Get;

public class RestaurantsGetQuery
{
    public RestaurantsGetQuery(string? name, RestaurantCategory? category)
    {
        Name = name;
        Category = category;
    }

    public string? Name { get; set; }
    public RestaurantCategory? Category { get; set; }
}
