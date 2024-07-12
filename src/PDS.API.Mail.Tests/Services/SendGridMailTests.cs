using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PDS.API.Mail.Services;

namespace PDS.API.Mail.Tests.Services;

public class Tests
{
    [Test]
    public async Task SendsEmailSuccessfully()
    {
        var fixture = new InfrastructureFixture();
        var mailService = fixture.ServiceProvider.GetRequiredService<IMailService>();

        var result = await mailService.SendEmail("robert@madmax.consulting", "subject", "siemano!!!");
        Assert.That(result, Is.True);
    }
}