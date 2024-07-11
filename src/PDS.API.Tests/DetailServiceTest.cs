using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PDS.API.Services;

namespace PDS.API.Tests;

public class DetailServiceTests
{

    [Test]
    public async Task GetDetailsByPackageKey()
    {

        var fixture = new InfrastructureFixture();
        var detailService = fixture.ServiceProvider.GetRequiredService<IDetailService>();

        var detail = await detailService.GetDetailsByPackageKey("8f74734a-6a6c-1520-61a3-57bc022100cc");

        Assert.That(detail, Is.Not.Null);
        Assert.That(detail.PackageKey, Is.EqualTo("8f74734a-6a6c-1520-61a3-57bc022100cc"));
    }
}