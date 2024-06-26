using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PDS.API.Models;

public interface IPackageService
{
    Task<Package[]?> GetPackages();
    Task<Package?> GetPackageByPackageKey(string packageKey);
    Task<Package?> GetPackageByCustomerKey(string customerKey);
}


public class PackageService(HttpClient httpClient) : IPackageService
{
    public async Task<Package?> GetPackageByCustomerKey(string customerKey)
    {
        var response = await httpClient.GetAsync($"http://localhost:5000/api/v1/documents/customers/{customerKey}/packages");
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
    public async Task<Package?> GetPackageByPackageKey(string packageKey)
    {
        var response = await httpClient.GetAsync($"http://localhost:5000/api/v1/documents/packages/{packageKey}");
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