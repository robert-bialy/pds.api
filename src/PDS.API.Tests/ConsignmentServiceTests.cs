using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PDS.API.Services;

namespace PDS.API.Tests;

public class ConsignmentServiceTests
{
    [Test]
    public async Task GetConsignment()
    {
        var fixture = new InfrastructureFixture();
        var consignmentService = fixture.ServiceProvider.GetService<IConsignmentService>();

        var consignments = await consignmentService.GetConsignment();

        Assert.That(consignments, Is.Not.Empty);
    }

    [Test]
    public async Task GetConsignmentByConsignmentKey()
    {
        var fixture = new InfrastructureFixture();
        var consignmentService = fixture.ServiceProvider.GetService<IConsignmentService>();

        var consignment = await consignmentService.GetConsignmentByConsignmentKey("4c70e393-093c-2ad9-58bd-06ac99e0c1a5");

        Assert.IsNotNull(consignment);
        Assert.AreEqual(consignment.PackageKey, "690c1058-c335-8d1f-e7c7-6ba52a6f4673");
        Assert.AreEqual(consignment.Name, "interface_822.pdf");
        Assert.AreEqual(consignment.State, 5);
        Assert.AreEqual(consignment.Channel, 3);
    }

    [Test]
    public async Task GetConsignmentByPackageKey()
    {
        var fixture = new InfrastructureFixture();
        var consignmentService = fixture.ServiceProvider.GetService<IConsignmentService>();

        var consignment = await consignmentService.GetConsignmentByPackageKey("690c1058-c335-8d1f-e7c7-6ba52a6f4673");

        Assert.IsNotNull(consignment);
    }
}