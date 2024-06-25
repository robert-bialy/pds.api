using System.Text.Json;
using PDS.API.Models;

namespace PDS.API.Services;

public interface ICustomerService
{
    Task<Customer[]?> GetCustomers();
}

public class CustomerService(HttpClient httpClient) : ICustomerService
{
    public async Task<Customer[]?> GetCustomers()
    {
        var response = await httpClient.GetAsync("http://localhost:5000/api/v1/documents/customers?PageSize=1000&PageIndex=0");
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