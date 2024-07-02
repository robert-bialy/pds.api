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

    [Test]
    public async Task GetCustomerByCustomerKey()
    {
        //int x = 5;
        //Assert.AreEqual(x, 1);
        //Assert.IsNotNull(new object());

        var fixture = new InfrastructureFixture();
        var customerService = fixture.ServiceProvider.GetService<ICustomerService>();

        var customer = await customerService.GetCustomerByCustomerKey("31c1652f-412d-c7e5-f374-2371ed6d8479");

        Assert.IsNotNull(customer);
        Assert.AreEqual(customer.Number, 778510);
        Assert.AreEqual(customer.Name, "Lindberg - Gunnarsson");
    }
}