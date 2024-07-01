using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text.Json;
using PDS.API.Models;

namespace PDS.API;

static class Program
{
    public static async Task Main()
    {
        Console.WriteLine("For get documents/ customers press 1, for get documents/ packages press 2, for get documents/ cosignments press 3, for GetCustomerByCustomerKey press 4, for GetPackageByPackageKey press 5, for GetConsignmentByConsignmentKey press 6, for GetConsignmentByPackageKey press 7, for GetPackageByCustomerKey press 8");
        var userInput = Console.ReadLine() ?? "";
        if (userInput == "1")
        {
            await GetCustomers();
        }
        if (userInput == "2")
        {
            await GetPackages();
        }
        if (userInput == "3")
        {
            await GetConsignments();
        }
        if (userInput == "4")
        {
            await GetCustomerByCustomerKey();
        }
        if (userInput == "5")
        {
            await GetPackageByPackageKey();
        }
        if (userInput == "6")
        {
            await GetConsignmentByConsignmentKey();
        }
        if (userInput == "7")
        {
            await GetConsignmentByPackageKey();
        }
        else
        {
            await GetPackageByCustomerKey();
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

    private static async Task GetCustomerByCustomerKey()
    {
        Console.WriteLine("Please input the customer key");
        string customerKey = Console.ReadLine() ?? "";

        var httpClient = new HttpClient();
        var customerService = new CustomerService(httpClient);
        var customer = await customerService.GetCustomerByCustomerKey(customerKey);

        if (customer != null)
        {
            Console.WriteLine($"Customer key: {customer.CustomerKey}");
            Console.WriteLine($"Name: {customer.Name}");
            Console.WriteLine($"Number: {customer.Number}");
            Console.WriteLine($"Created at: {customer.CreatedAt}");
            Console.WriteLine(" ");
        }
        else
        {
            Console.WriteLine("Customer not found.");
        }
    }

    private static async Task GetPackageByPackageKey()
    {
        Console.WriteLine("Please input the package key");
        string packageKey = Console.ReadLine() ?? "";

        var httpClient = new HttpClient();
        var packageService = new PackageService(httpClient);
        var package = await packageService.GetPackageByPackageKey(packageKey);

        if (package != null)
        {
            Console.WriteLine($"Package key : {package.PackageKey}");
            Console.WriteLine($"Customer key : {package.CustomerKey}");
            Console.WriteLine($"Name : {package.Name}");
            Console.WriteLine($"State : {package.State}");
            Console.WriteLine($"Created at : {package.CreatedAt}");
            Console.WriteLine($"Updated at : {package.UpdatedAt}");
            Console.WriteLine(" ");
        }
        else
        {
            Console.WriteLine("Customer not found.");
        }
    }

    private static async Task GetConsignmentByConsignmentKey()
    {
        Console.WriteLine("Please input the consignment key");
        string consignmentKey = Console.ReadLine() ?? "";

        var httpClient = new HttpClient();
        var consignmentService = new ConsignmentService(httpClient);
        var consignment = await consignmentService.GetConsignmentByConsignmentKey(consignmentKey);

        if (consignment != null)
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
                Console.WriteLine($"Created at : {eventdata.CreatedAt}");
                Console.WriteLine(" ");
            }
        }
        else
        {
            Console.WriteLine("Consignment not found.");
        }
    }

    private static async Task GetConsignmentByPackageKey()
    {
        Console.WriteLine("Please input the package key");
        string packageKey = Console.ReadLine() ?? "";

        var httpClient = new HttpClient();
        var consignmentService = new ConsignmentService(httpClient);
        var consignments = await consignmentService.GetConsignmentByPackageKey(packageKey);

        foreach (var consignment in consignments)
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
                Console.WriteLine($"Created at : {eventdata.CreatedAt}");
                Console.WriteLine(" ");
            }
        }
    }

    private static async Task GetPackageByCustomerKey()
    {
        Console.WriteLine("Please input the customer key");
        string customerKey = Console.ReadLine() ?? "";

        var httpClient = new HttpClient();
        var packageService = new PackageService(httpClient);
        var package = await packageService.GetPackageByCustomerKey(customerKey);

        if (package != null)
        {
            Console.WriteLine($"Package key : {package.PackageKey}");
            Console.WriteLine($"Customer key : {package.CustomerKey}");
            Console.WriteLine($"Name : {package.Name}");
            Console.WriteLine($"State : {package.State}");
            Console.WriteLine($"Created at : {package.CreatedAt}");
            Console.WriteLine($"Updated at : {package.UpdatedAt}");
            Console.WriteLine(" ");
        }
        else
        {
            Console.WriteLine("Customer not found.");
        }
    }
}