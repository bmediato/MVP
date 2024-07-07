using Domain.Dtos.v1.User;
using Domain.Interfaces.v1.Services.User;

namespace Domain.Services.v1.User
{
    public class UserService : IUserService
    {
        private readonly IUserMongoDbRepository _userMongoDbRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IMapper mapper, ILoggerFactory logger, IUserMongoDbRepository userMongoDbRepository)
        {
            _mapper = mapper;
            _logger = logger.CreateLogger<UserService>();
            _userMongoDbRepository = userMongoDbRepository;
        }

        public async Task<UserDtoResponse> SaveUserAsync(UserDto command)
        {
            var response = new UserDtoResponse();

            try
            {
                _logger.LogInformation(
                   $"[{nameof(UserService)}].Service - Início | user: {command.UserName}"
                   );

                var user = _mapper.Map<UserMongoDb>(
                    source: command);

                await _userMongoDbRepository.UpsertAsync(user);

                _logger.LogInformation(
                  $"[{nameof(UserService)}].Service - Fim | user: {command.UserName}"
                  );

                return response;
            } catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    $"[{nameof(UserSaveCommandHandler)}].Handle"
                    );

                return response.Error("Erro inesperado! Tente novamente mais tarde.");
            }
        }
    }
}
