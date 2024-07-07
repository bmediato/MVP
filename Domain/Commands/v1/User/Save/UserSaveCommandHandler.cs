using Domain.Interfaces.v1.Services.User;
using FluentValidation.Results;

namespace Domain.Commands.v1.User.Save;

public class UserSaveCommandHandler : IUserSaveHandlerService
{
    private readonly IMapper _mapper;
    private readonly ILogger<UserSaveCommandHandler> _logger;
    private readonly IUserMongoDbRepository _userMongoDbRepository;
    private readonly IValidator<UserSaveCommand> _userValidator;

    public UserSaveCommandHandler(
        IMapper mapper,
        ILoggerFactory logger,
        IUserMongoDbRepository userMongoDbRepository,
        IValidator<UserSaveCommand> userValidator)
    {
        _mapper = mapper;
        _logger = logger.CreateLogger<UserSaveCommandHandler>();
        _userMongoDbRepository = userMongoDbRepository;
        _userValidator = userValidator;
    }

    public async Task<UserSaveCommandResponse> SaveUserAsync(UserSaveCommand command)
    {
        var response = new UserSaveCommandResponse();

        // valida os dados de entrada
        ValidationResult validationResult = _userValidator.Validate(command);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning($"[{nameof(UserSaveCommandHandler)}].Handle - Validação falhou para o usuário: {command.UserName}");
            return response.Error(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
        }
        try
        {
            _logger.LogInformation(
                    $"[{nameof(UserSaveCommandHandler)}].Handle - Início | user: {command.UserName}"
                    );

            command.Password = BCrypt.Net.BCrypt.HashPassword(command.Password);

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
