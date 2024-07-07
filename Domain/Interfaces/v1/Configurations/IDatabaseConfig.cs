namespace Domain.Interfaces.v1.Configurations;

public interface IDatabaseConfig
{
    string DatabaseName { get; set; }

    string ConnectionString { get; set; }
}
