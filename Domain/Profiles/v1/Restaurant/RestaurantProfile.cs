namespace Domain.Profiles.v1.Restaurant;

public class RestaurantProfile : Profile
{
    public RestaurantProfile() { }

    public MapperConfiguration Configuration()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<RestaurantsSaveCommand, RestaurantsMongoDb>(); //command to mongo
        });
    }
}
