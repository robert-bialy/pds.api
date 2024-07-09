using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PDS.API.Services;

namespace PDS.API.Tests;

public class StateServiceTests
{
    [Test]
    public async Task GetStates()
    {
        var fixture = new InfrastructureFixture();
        var stateService = fixture.ServiceProvider.GetService<IStateService>();

        var states = await stateService.GetStates();

        Assert.IsNotNull(states);
        Assert.That(states, Is.Not.Empty);
    }
}