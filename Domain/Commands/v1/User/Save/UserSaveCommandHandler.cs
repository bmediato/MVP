namespace Domain.Commands.v1.User.Save;

public class UserSaveCommandHandler : IRequestHandler<UserSaveCommand, UserSaveCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ILogger<UserSaveCommandHandler> _logger;
    private readonly IUserMongoDbRepository _userMongoDbRepository;

    public UserSaveCommandHandler(
        IMapper mapper,
        ILoggerFactory logger,
        IUserMongoDbRepository userMongoDbRepository)
    {
        _mapper = mapper;
        _logger = logger.CreateLogger<UserSaveCommandHandler>();
        _userMongoDbRepository = userMongoDbRepository;
    }

    public async Task<UserSaveCommandResponse> Handle(UserSaveCommand command, CancellationToken cancellationToken)
    {
        var response = new UserSaveCommandResponse();
        try
        {
            _logger.LogInformation(
                    $"[{nameof(UserSaveCommandHandler)}].Handle - Início | user: {command.UserName}"
                    );

            var user = _mapper.Map<UserMongoDb>(
                source: command);

            await _userMongoDbRepository.UpsertAsync(user);

            _logger.LogInformation(
              $"[{nameof(UserSaveCommandHandler)}].Handle - Fim | user: {command.UserName}"
              );

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(
                    ex,
                    $"[{nameof(UserSaveCommandHandler)}].Handle"
                    );

            return response.Error("Erro inesperado! Tente novamente mais tarde.");
        }
    }
}
