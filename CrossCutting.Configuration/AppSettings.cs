namespace CrossCutting.Configuration;

public class AppSettings : IAppSettings
{
    public DatabaseConfig DatabaseConfig { get; set; }
    public JwtSettings JwtSettings { get; set; }
}
