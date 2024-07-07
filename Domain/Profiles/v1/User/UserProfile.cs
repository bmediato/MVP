namespace Domain.Profiles.v1.User;

public class UserProfile : Profile
{

    public UserProfile()
    {

    }

    public MapperConfiguration Configuration()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UserSaveCommand, UserMongoDb>();
        });
    }
}
