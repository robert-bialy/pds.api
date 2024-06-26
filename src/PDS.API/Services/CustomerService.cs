using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PDS.API.Models;

public interface ICustomerService
{
    Task<Customer[]?> GetCustomers();
    Task<Customer?> GetCustomerById(string id);
}

public class CustomerService(HttpClient httpClient) : ICustomerService
{
    public async Task<Customer?> GetCustomerById(string id)
    {
        var response = await httpClient.GetAsync($"http://localhost:5000/api/v1/documents/customers/{id}");
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
        var response = await httpClient.GetAsync("http://localhost:5000/api/v1/documents/customers");
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