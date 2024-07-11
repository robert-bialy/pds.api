using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PDS.API.Models;
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

        var consignment = await consignmentService.GetConsignmentByConsignmentKey("dbab46f0-79f7-3c18-50c1-4b7cb18e51ce");

        Assert.That(consignment, Is.Not.Null);
        Assert.That(consignment.Attributes, Is.Not.Null);
        Assert.That(consignment.Attributes, Is.Not.Empty);
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