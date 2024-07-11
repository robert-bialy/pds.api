using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PDS.API.Services;

namespace PDS.API.Tests.Services;

public class ChannelServiceTests
{
    [Test]
    public async Task GetChannels()
    {
        var fixture = new InfrastructureFixture();
        var channelService = fixture.ServiceProvider.GetRequiredService<IChannelService>();

        var channels = await channelService.GetChannels();

        Assert.That(channels, Is.Not.Null);
        Assert.That(channels, Is.Not.Empty);
    }
}