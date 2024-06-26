﻿using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PDS.API.Models;

public interface IConsignmentService
{
    Task<Consignment[]?> GetConsignment();
    Task<Consignment?> GetConsignmentByConsignmentKey(string consignmentKey);
    Task<Consignment[]?> GetConsignmentByPackageKey(string packageKey);

}

public class ConsignmentService(HttpClient httpClient) : IConsignmentService
{
    public async Task<Consignment[]?> GetConsignmentByPackageKey(string packageKey)
    {
        var response = await httpClient.GetAsync($"http://localhost:5000/api/v1/documents/packages/{packageKey}/consignments");
        var content = await response.Content.ReadAsStringAsync();

        try
        {
            var cosignmentResponse = JsonSerializer.Deserialize<Response<Consignment>>(content);
            return cosignmentResponse.Data;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Json deserialization error: {ex.Message}");
        }

        return null;
    }
    public async Task<Consignment?> GetConsignmentByConsignmentKey(string consignmentKey)
    {
        var response = await httpClient.GetAsync($"http://localhost:5000/api/v1/documents/consignments/{consignmentKey}");
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
            var consignmentResponse = JsonSerializer.Deserialize<Response<Consignment>>(content);
            return consignmentResponse?.Data;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Json deserialization error:{ex.Message}");
        }

        return null;
    }
}