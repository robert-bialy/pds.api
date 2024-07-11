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
        var stateService = fixture.ServiceProvider.GetRequiredService<IStateService>();

        var states = await stateService.GetStates();

        Assert.That(states, Is.Not.Null);
        Assert.That(states, Is.Not.Empty);
    }
}