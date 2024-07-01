using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PDS.API.Services;

namespace PDS.API.Tests;

public class CustomerServiceTests
{
    [Test]
    public async Task GetCustomers()
    {
        var fixture = new InfrastructureFixture();
        var customerService = fixture.ServiceProvider.GetService<ICustomerService>();

        var customers = await customerService.GetCustomers();

        Assert.That(customers, Is.Not.Empty);
    }
}