using CrossCutting.Configuration.Models;
using Domain.Interfaces.v1.Configurations;

namespace CrossCutting.Configuration.Interfaces;

public interface IAppSettings
{
    DatabaseConfig DatabaseConfig { get; }
    JwtSettings JwtSettings { get; }
}
