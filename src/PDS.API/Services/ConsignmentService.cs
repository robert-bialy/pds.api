using System.Text.Json;
using PDS.API.Models;

namespace PDS.API.Services;

public interface IConsignmentService
{
    Task<Consignment[]?> GetConsignment();
    Task<Consignment?> GetConsignmentById(string id);
}

public class ConsignmentService(HttpClient httpClient) : IConsignmentService
{
    public async Task<Consignment?> GetConsignmentById(string id)
    {
        var response = await httpClient.GetAsync($"http://localhost:5000/api/v1/documents/consignments/{id}");
        var content = await response.Content.ReadAsStringAsync();

        try
        {
            var customerResponse = JsonSerializer.Deserialize<Consignment>(content);
            return customerResponse;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Json deserialization error: {ex.Message}");
        }

        return null;
    }
    public async Task<Consignment[]?> GetConsignment()
    {
        var response = await httpClient.GetAsync("http://localhost:5000/api/v1/documents/consignments?PageSize=1000&PageIndex=0");
        var content = await response.Content.ReadAsStringAsync();

        try
        {
            var customerResponse = JsonSerializer.Deserialize<Response<Consignment>>(content);
            return customerResponse?.Data;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Json deserialization error:{ex.Message}");
        }

        return null;
    }
}