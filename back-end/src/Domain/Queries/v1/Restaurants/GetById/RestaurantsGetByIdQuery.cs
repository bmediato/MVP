namespace Domain.Queries.v1.Restaurants.GetById;

public class RestaurantsGetByIdQuery : IRequest<RestaurantsGetByIdQueryResponse>
{
    public RestaurantsGetByIdQuery(Guid id) => Id = id;

    public Guid Id { get; set; }
}
