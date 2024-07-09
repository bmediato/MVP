namespace Domain.Commands.v1.Login;

public class LoginCommandHandler : ILoginHandlerService
{
    private readonly IUserMongoDbRepository _userMongoDbRepository;
    private readonly JwtSettings _jwtSettings;

    public LoginCommandHandler(IUserMongoDbRepository userMongoDbRepository, JwtSettings jwtSettings)
    {
        _userMongoDbRepository = userMongoDbRepository;
        _jwtSettings = jwtSettings;
    }

    public async Task<LoginCommandResponse> AuthenticateAsync(LoginCommand command)
    {
        var user = await _userMongoDbRepository.GetByEmailAsync(command.Email);

        if (user == null || !VerifyPasswordHash(command.Password, user.Password))
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != passwordHash[i])
                return false;
        }
        return true;
    }

    private string GenerateJwtToken(UserDto user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                    new Claim(ClaimTypes.Name, user.Username),
                    // Adicione mais claims conforme necessário (por exemplo, roles)
                }),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
