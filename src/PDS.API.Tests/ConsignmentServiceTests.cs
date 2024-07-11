using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PDS.API.Services;

namespace PDS.API.Tests;

public class ConsignmentServiceTests
{
    [Test]
    public async Task GetConsignments()
    {
        var fixture = new InfrastructureFixture();
        var consignmentService = fixture.ServiceProvider.GetRequiredService<IConsignmentService>();

        var consignments = await consignmentService.GetConsignments();

        Assert.IsNotNull(consignments);
        Assert.That(consignments, Is.Not.Empty);
    }

    [Test]
    public async Task GetConsignmentByConsignmentKey()
    {
        var fixture = new InfrastructureFixture();
        var consignmentService = fixture.ServiceProvider.GetRequiredService<IConsignmentService>();

        var consignment = await consignmentService.GetConsignmentByConsignmentKey("c7f3aafa-0e19-f95f-c8b6-e0c12645744e");

        Assert.That(consignment, Is.Not.Null);
    }

    [Test]
    public async Task GetConsignmentByPackageKey()
    {
        var fixture = new InfrastructureFixture();
        var consignmentService = fixture.ServiceProvider.GetRequiredService<IConsignmentService>();

        var consignment = await consignmentService.GetConsignmentByPackageKey("690c1058-c335-8d1f-e7c7-6ba52a6f4673");

        Assert.That(consignment, Is.Not.Null);
    }
}