using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PDS.API.Services;

namespace PDS.API.Tests;

public class ChannelServiceTests
{
    [Test]
    public async Task GetChannels()
    {
        var fixture = new InfrastructureFixture();
        var stateService = fixture.ServiceProvider.GetService<IChannelService>();

        var states = await stateService.GetChannels();

        Assert.IsNotNull(states);
        Assert.That(states, Is.Not.Empty);
    }
}