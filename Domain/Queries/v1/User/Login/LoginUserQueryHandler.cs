namespace Domain.Queries.v1.User.Login;

public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginUserQueryResponse>
{
    private readonly IUserMongoDbRepository _userMongoDbRepository;
    private readonly JwtSettings _jwtSettings;

    public LoginUserQueryHandler(IUserMongoDbRepository userMongoDbRepository, JwtSettings jwtSettings)
    {
        _userMongoDbRepository = userMongoDbRepository;
        _jwtSettings = jwtSettings;
    }

    public async Task<LoginUserQueryResponse> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var response = new LoginUserQueryResponse();
        var user = await _userMongoDbRepository.GetByEmailAsync(request.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            return response.Error("Invalid email or password");
        }
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpiryMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        response.Token = tokenHandler.WriteToken(token);

        return response;
    }
}
