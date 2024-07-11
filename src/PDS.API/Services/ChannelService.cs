using System.Text.Json;
using System.Threading.Channels;
using PDS.API.Models;
using Channel = PDS.API.Models.Channel;

namespace PDS.API.Services;

public interface IChannelService
{
    Task<Channel[]?> GetChannels();
}
public class ChannelService(HttpClient httpClient) : IChannelService
{
    public async Task<Channel[]?> GetChannels()
    {
        var response = await httpClient.GetAsync("/api/v1/documents/consignments/channels");
        var content = await response.Content.ReadAsStringAsync();

        try
        {
            var channelResponse = JsonSerializer.Deserialize<Channel[]>(content);
            return channelResponse;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Json deserialization error:{ex.Message}");
        }

        return null;
    }
}