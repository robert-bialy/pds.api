using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PDS.API.Mail.Extensions;

namespace PDS.API.Mail.Tests;

public class InfrastructureFixture
{
    public ServiceProvider ServiceProvider { get; private set; }
    public IConfiguration Configuration { get; private set; }
    
    public InfrastructureFixture()
    {
        var services = new ServiceCollection();
        var configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.test.json");

        services.AddMailingServices();
        Configuration = configurationBuilder.Build();
        ServiceProvider = services.BuildServiceProvider();
    }
}