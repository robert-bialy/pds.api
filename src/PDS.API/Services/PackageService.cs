using System.Text.Json;
using PDS.API.Models;

namespace PDS.API.Services;

public interface IPackageService
{
    Task<Package[]?> GetPackages();
    Task<Package?> GetPackageById(string id);
}

public class PackageService(HttpClient httpClient) : IPackageService
{
    public async Task<Package?> GetPackageById(string id)
    {
        var response = await httpClient.GetAsync($"http://localhost:5000/api/v1/documents/packages/{id}");
        var content = await response.Content.ReadAsStringAsync();

        try
        {
            var customerResponse = JsonSerializer.Deserialize<Package>(content);
            return customerResponse;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Json deserialization error: {ex.Message}");
        }

        return null;
    }
    public async Task<Package[]?> GetPackages()
    {
        var response = await httpClient.GetAsync("http://localhost:5000/api/v1/documents/packages?PageSize=1000&PageIndex=0");
        var content = await response.Content.ReadAsStringAsync();

        try
        {
            var customerResponse = JsonSerializer.Deserialize<Response<Package>>(content);
            return customerResponse?.Data;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Json deserialization error:{ex.Message}");
        }

        return null;
    }
}