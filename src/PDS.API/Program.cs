using System.Text.Json;
using PDS.API.Models;
using PDS.API.Services;

namespace PDS.API;

static class Program
{
    public static async Task Main()
    {
        Console.WriteLine("For get documents/ customers press 1, for get documents/ packages press 2, for get documents/ cosignments press 3");
        var userInput = Console.ReadLine() ??"";
        if (userInput == "1")
        {
            await GetCustomers();
        }
        if (userInput == "2")
        {
            await GetPackages();
        }
        else
        {
            await GetConsignments();
        }   
    }

    private static async Task GetCustomers()
    {
        var httpClient = new HttpClient();
        var customerService = new CustomerService(httpClient);
        var customers = await customerService.GetCustomers();
        
        foreach (var customer in customers)
        {
            Console.WriteLine($"Customer key: {customer.CustomerKey}");
            Console.WriteLine($"Name: {customer.Name}");
            Console.WriteLine($"Number: {customer.Number}");
            Console.WriteLine($"Created at: {customer.CreatedAt}");
            Console.WriteLine(" ");
        }
    }

    private static async Task GetPackages()
    {
        var httpClient = new HttpClient();
        var packageService = new PackageService(httpClient);
        var packages = await packageService.GetPackages();

        foreach (Package package in packages)
        {
            Console.WriteLine($"Package key : {package.PackageKey}");
            Console.WriteLine($"Customer key : {package.CustomerKey}");
            Console.WriteLine($"Name : {package.Name}");
            Console.WriteLine($"State : {package.State}");
            Console.WriteLine($"Created at : {package.CreatedAt}");
            Console.WriteLine($"Updated at : {package.UpdatedAt}");
            Console.WriteLine(" ");
        }

    }

    private static async Task GetConsignments()
    {
        var httpClient = new HttpClient();
        var consignmentService = new ConsignmentService(httpClient);
        var consignments = await consignmentService.GetConsignment();

        foreach (Consignment consignment in consignments)
        {
            Console.WriteLine($"Consignment key : {consignment.ConsignmentKey}");
            Console.WriteLine($"Package key : {consignment.PackageKey}");
            Console.WriteLine($"Name : {consignment.Name}");
            Console.WriteLine($"State : {consignment.State}");
            Console.WriteLine($"Channel : {consignment.Channel}");
            Console.WriteLine($"Created at : {consignment.CreatedAt}");
            Console.WriteLine($"Updated at : {consignment.UpdatedAt}");
            foreach (Event eventdata in consignment.Events)
            {
                Console.WriteLine($"Events:");
                Console.WriteLine($"State : {eventdata.State}");
                Console.WriteLine($"Text : {eventdata.Text}");
                Console.WriteLine($"Text : {eventdata.CreatedAt}");
                Console.WriteLine(" ");

            }
        }


    }

}