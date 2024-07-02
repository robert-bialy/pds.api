using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PDS.API.Models;
using PDS.API.Services;

namespace PDS.API.Tests;

public class InfrastructureFixture
{
    public ServiceProvider ServiceProvider { get; private set; }
    public IConfiguration Configuration { get; private set; }
    
    public InfrastructureFixture()
    {
        var services = new ServiceCollection();
        var configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.test.json");
            
        Configuration = configurationBuilder.Build();
        
        var apiUrl = Configuration["Statistics:ApiUrl"];

        Configuration = configurationBuilder.Build();

        services.AddHttpClient<ICustomerService, CustomerService>(client =>
        {
            client.BaseAddress = new Uri(apiUrl);
        });
        ServiceProvider = services.BuildServiceProvider();

        services.AddHttpClient<IPackageService, PackageService>(package =>
        {
            package.BaseAddress = new Uri(apiUrl);
        });
        ServiceProvider = services.BuildServiceProvider();

        services.AddHttpClient<IConsignmentService, ConsignmentService>(consignment =>
        {
            consignment.BaseAddress = new Uri(apiUrl);
        });
        ServiceProvider = services.BuildServiceProvider();
    }
}