using System.Text.Json;
using PDS.API.Models;

namespace PDS.API.Services;

public interface IDetailService
{
    Task<Detail?> GetDetailsByPackageKey(string packageKey);
}

public class DetailService(HttpClient httpClient) : IDetailService
{
    public async Task<Detail?> GetDetailsByPackageKey(string packageKey)
    {
        var response = await httpClient.GetAsync($"api/v1/documents/packages/{packageKey}/details");
        var content = await response.Content.ReadAsStringAsync();

        try
        {
            var detailResponse = JsonSerializer.Deserialize<Detail>(content);
            return detailResponse;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Json deserialization error: {ex.Message}");
        }

        return null;
    }
}