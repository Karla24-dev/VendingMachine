
namespace VendingMachine.Service.Shared;

public class ConnectionStringBuilder(IConfiguration config)
{
    public string GetConnectionString()
    {
        var url = config[EnvConfig.Url];
        var port = config[EnvConfig.Port];
        var name = config[EnvConfig.Name];
        var user = config[EnvConfig.User];
        var pw = config[EnvConfig.Password];

        var connectionString =
            $"Host={url};" +
            $"Port={port};" +
            $"Database={name};" +
            $"Username={user};" +
            $"Password={pw};" +
            $"SSL Mode=Require;" +
            $"Trust Server Certificate=true";

        return connectionString ;
    }
}
