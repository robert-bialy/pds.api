using System.Text.Json;
using PDS.API.Models;

namespace PDS.API.Services;

public interface IStatisticsService
{
    Task<Statistics?> GetStatisticsByCustomerKey(string customerKey);
}

public class StatisticsService(HttpClient httpClient) : IStatisticsService
{
    public async Task<Statistics?> GetStatisticsByCustomerKey(string customerKey)
    {
        var response = await httpClient.GetAsync($"api/v1/documents/customers/{customerKey}/statistics");
        var content = await response.Content.ReadAsStringAsync();

        try
        {
            var statisticsResponse = JsonSerializer.Deserialize<Statistics>(content);
            return statisticsResponse;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Json deserialization error:{ex.Message}");
        }

        return null;
    }
}