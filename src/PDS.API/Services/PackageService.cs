using System.Text.Json;
using PDS.API.Models;

namespace PDS.API.Services;

public interface IPackageService
{
    Task<Package[]?> GetPackages();
    Task<Package?> GetPackageByPackageKey(string packageKey);
    Task<Package[]> GetPackageByCustomerKey(string customerKey);
}


public class PackageService(HttpClient httpClient) : IPackageService
{
    public async Task<Package[]> GetPackageByCustomerKey(string customerKey)
    {
        var response = await httpClient.GetAsync($"/api/v1/documents/customers/{customerKey}/packages");
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }

        var content = await response.Content.ReadAsStringAsync();

        try
        {
            var packageResponse = JsonSerializer.Deserialize<Response<Package>>(content);
            return packageResponse.Data;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Json deserialization error: {ex.Message}");
        }

        return null;
    }

    public async Task<Package?> GetPackageByPackageKey(string packageKey)
    {
        var response = await httpClient.GetAsync($"/api/v1/documents/packages/{packageKey}");
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }

        var content = await response.Content.ReadAsStringAsync();

        try
        {
            var packageResponse = JsonSerializer.Deserialize<Package>(content);
            return packageResponse;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Json deserialization error: {ex.Message}");
        }

        return null;
    }

    public async Task<Package[]?> GetPackages()
    {
        var response = await httpClient.GetAsync("/api/v1/documents/packages?PageSize=1000&PageIndex=0");
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }

        var content = await response.Content.ReadAsStringAsync();

        try
        {
            var packageResponse = JsonSerializer.Deserialize<Response<Package>>(content);
            return packageResponse?.Data;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Json deserialization error:{ex.Message}");
        }

        return null;
    }
}