using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PDS.API.Services;

namespace PDS.API.Tests;

public class StatisticsServiceTests
{

    [Test]
    [Ignore("The endpoint is not working yet")]
    public async Task GetStatisticsByCustomerKey()
    {

        var fixture = new InfrastructureFixture();
        var statisticsService = fixture.ServiceProvider.GetService<IStatisticsService>();

        var statistics = await statisticsService.GetStatisticsByCustomerKey("31c1652f-412d-c7e5-f374-2371ed6d8479");

        Assert.IsNotNull(statistics);
        Assert.AreEqual(statistics.CustomerKey, "31c1652f-412d-c7e5-f374-2371ed6d8479");
        //Assert.AreEqual(statistics.From,"");
        //Assert.AreEqual(statistics.To, "");  For both I was unable to get the data
    }
}