using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PDS.API.Services;

namespace PDS.API.Tests;

public class PackageServiceTests
{
    [Test]
    public async Task GetPackages()
    {
        var fixture = new InfrastructureFixture();
        var packageService = fixture.ServiceProvider.GetService<IPackageService>();

        var packages = await packageService.GetPackages();

        Assert.That(packages, Is.Not.Empty);
    }

    [Test]
    public async Task GetPackageByPackageKey()
    {

        var fixture = new InfrastructureFixture();
        var packageService = fixture.ServiceProvider.GetService<IPackageService>();

        var package = await packageService.GetPackageByPackageKey("fb2bc93a-0e1d-318e-0c96-684c461dbbe1");

        Assert.IsNotNull(package);
        Assert.AreEqual(package.CustomerKey, "31c1652f-412d-c7e5-f374-2371ed6d8479");
        Assert.AreEqual(package.Name, "redundant_generate_546.zip");
        Assert.AreEqual(package.State, 0);

    }

    [Test]
    public async Task GetPackageByCustomerKey()
    {

        var fixture = new InfrastructureFixture();
        var packageService = fixture.ServiceProvider.GetService<IPackageService>();

        var package = await packageService.GetPackageByCustomerKey("31c1652f-412d-c7e5-f374-2371ed6d8479");

        Assert.IsNotNull(package);

    }
}