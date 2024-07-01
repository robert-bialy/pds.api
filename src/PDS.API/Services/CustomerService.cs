using System.Text.Json;
using PDS.API.Models;

namespace PDS.API.Services;

public interface ICustomerService
{
    Task<Customer[]?> GetCustomers();
    Task<Customer?> GetCustomerByCustomerKey(string customerKey);
}

public class CustomerService(HttpClient httpClient) : ICustomerService
{
    public async Task<Customer?> GetCustomerByCustomerKey(string customerKey)
    {
        var response = await httpClient.GetAsync($"api/v1/documents/customers/{customerKey}");
        var content = await response.Content.ReadAsStringAsync();

        try
        {
            var customerResponse = JsonSerializer.Deserialize<Customer>(content);
            return customerResponse;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Json deserialization error: {ex.Message}");
        }

        return null;
    }

    public async Task<Customer[]?> GetCustomers()
    {
        var response = await httpClient.GetAsync("api/v1/documents/customers");
        var content = await response.Content.ReadAsStringAsync();

        try
        {
            var customerResponse = JsonSerializer.Deserialize<Response<Customer>>(content);
            return customerResponse?.Data;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Json deserialization error:{ex.Message}");
        }

        return null;
    }
}