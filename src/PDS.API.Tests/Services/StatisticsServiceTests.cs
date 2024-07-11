using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PDS.API.Services;

namespace PDS.API.Tests.Services;

public class StatisticsServiceTests
{

    [Test]
    [Ignore("The endpoint is not working yet")]
    public async Task GetStatisticsByCustomerKey()
    {

        var fixture = new InfrastructureFixture();
        var statisticsService = fixture.ServiceProvider.GetRequiredService<IStatisticsService>();

        var statistics = await statisticsService.GetStatisticsByCustomerKey("31c1652f-412d-c7e5-f374-2371ed6d8479");

        Assert.That(statistics, Is.Not.Null);
        Assert.That(statistics.CustomerKey, Is.EqualTo("31c1652f-412d-c7e5-f374-2371ed6d8479"));
    }
}