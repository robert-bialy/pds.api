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
        var customerService = fixture.ServiceProvider.GetRequiredService<ICustomerService>();

        var customers = await customerService.GetCustomers();

        Assert.That(customers, Is.Not.Empty);
    }

    [Test]
    public async Task GetCustomerByCustomerKey()
    {
        var fixture = new InfrastructureFixture();
        var customerService = fixture.ServiceProvider.GetRequiredService<ICustomerService>();

        var customer = await customerService.GetCustomerByCustomerKey("31c1652f-412d-c7e5-f374-2371ed6d8479");

        Assert.That(customer, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(customer.Number, Is.EqualTo(778510));
            Assert.That(customer.Name, Is.EqualTo("Lindberg - Gunnarsson"));
        });
    }
}