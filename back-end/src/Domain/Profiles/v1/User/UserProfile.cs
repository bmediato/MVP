namespace Domain.Profiles.v1.User;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserSaveCommand, UserMongoDb>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.userName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.phoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
    }
}
