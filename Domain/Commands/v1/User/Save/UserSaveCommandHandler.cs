namespace Domain.Commands.v1.User.Save;

public class UserSaveCommandHandler : IRequestHandler<UserSaveCommand, UserSaveCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ILogger<UserSaveCommandHandler> _logger;

    public UserSaveCommandHandler(
        IMapper mapper,
        ILoggerFactory logger)
    {
        _mapper = mapper;
        _logger = logger.CreateLogger<UserSaveCommandHandler>();
    }

    public async Task<UserSaveCommandResponse> Handle(UserSaveCommand command, CancellationToken cancellationToken)
    {
        try
        {
            return new UserSaveCommandResponse();
        }
        catch (Exception ex)
        {
            _logger.LogError(
                    ex,
                    $"[{nameof(UserSaveCommandHandler)}].Handle"
                    );

            throw ex;
        }
    }
}
