using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PDS.API.Mail.Services;

namespace PDS.API.Mail.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddMailingServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IMailService, SendGridMailService>();
        return serviceCollection;
    }
}