namespace Domain.Profiles.v1.Restaurant;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<RestaurantsSaveCommand, RestaurantsMongoDb>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.phoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.logo, opt => opt.MapFrom(src => src.Logo))
            .ForMember(dest => dest.banner, opt => opt.MapFrom(src => src.Banner))
            .ForMember(dest => dest.dishes, opt => opt.MapFrom(src => src.Dishes));

        CreateMap<RestaurantsMongoDb, RestaurantsGetQueryResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.category))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.address))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.phoneNumber))
            .ForMember(dest => dest.Logo, opt => opt.MapFrom(src => src.logo))
            .ForMember(dest => dest.Banner, opt => opt.MapFrom(src => src.banner))
            .ForMember(dest => dest.Dishes, opt => opt.MapFrom(src => src.dishes));

        CreateMap<RestaurantsMongoDb, RestaurantsGetByIdQueryResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.category))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.address))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.phoneNumber))
            .ForMember(dest => dest.Logo, opt => opt.MapFrom(src => src.logo))
            .ForMember(dest => dest.Banner, opt => opt.MapFrom(src => src.banner))
            .ForMember(dest => dest.Dishes, opt => opt.MapFrom(src => src.dishes));
    }
}
