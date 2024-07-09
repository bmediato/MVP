namespace CrossCutting.Configuration.Interfaces;

public interface IJwtSettings
{
    string Secret { get; set; }
    string Issuer { get; set; }
    string Audience { get; set; }
    int ExpiryMinutes { get; set; }
}
