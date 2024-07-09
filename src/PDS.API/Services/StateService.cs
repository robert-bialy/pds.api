using System.Text.Json;
using PDS.API.Models;

namespace PDS.API.Services;

public interface IStateService
{
    Task<State[]?> GetStates();
}

public class StateService(HttpClient httpClient) : IStateService
{
    public async Task<State[]?> GetStates()
    {
        var response = await httpClient.GetAsync("api/v1/documents/consignments/states");
        var content = await response.Content.ReadAsStringAsync();

        try
        {
            var stateResponse = JsonSerializer.Deserialize<State[]>(content);
            return stateResponse;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Json deserialization error:{ex.Message}");
        }

        return null;
    }
}