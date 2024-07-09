namespace Domain.Queries.v1.Restaurants.GetById;

public class RestaurantsGetByIdQuery
{
    public RestaurantsGetByIdQuery(string id) => Id = id;

    public string Id { get; set; }
}
