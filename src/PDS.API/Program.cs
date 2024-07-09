using PDS.API.Models;
using PDS.API.Services;

namespace PDS.API;

static class Program
{
    public static async Task Main()
    {
        Console.WriteLine("For GetCustomers press 1, for get GetPackages press 2, for get GetConsignments press 3, for GetDetails press 4, " +
            "for GetStates press 5, for GetChannels press 6, for GetCustomerByCustomerKey press 7, for GetPackageByPackageKey press 8, " +
            "for GetConsignmentByConsignmentKey press 9, for GetConsignmentByPackageKey press 10, for GetPackageByCustomerKey press 11, " +
            "for  GetDetailsByPackageKey press 12, for  GetStatisticsByCustomerKey press 13");
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
            await GetDetails();
        }
        if (userInput == "5")
        {
            await GetStates();
        }
        if (userInput == "6")
        {
            await GetChannels();
        }
        if (userInput == "7")
        {
            await GetCustomerByCustomerKey();
        }
        if (userInput == "8")
        {
            await GetPackageByPackageKey();
        }
        if (userInput == "9")
        {
            await GetConsignmentByConsignmentKey();
        }
        if (userInput == "10")
        {
            await GetConsignmentByPackageKey();
        }
        if (userInput == "11")
        {
            await GetPackageByCustomerKey();
        }
        if (userInput == "12")
        {
            await GetDetailsByPackageKey();
        }
        if (userInput == "13")
        {
            await GetStatisticsByCustomerKey();
        }
        else
        {
            Console.WriteLine("Invalid input");
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
        var consignments = await consignmentService.GetConsignments();

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

    private static async Task GetDetails() //WIP
    {
        var httpClient = new HttpClient();
        var detailService = new DetailService(httpClient);
        var details = await detailService.GetDetails();

        foreach (var detail in details)
        {
            Console.WriteLine($"Package key: {detail.PackageKey}");
            foreach (Category categorydata in detail.Categories)
            {
                Console.WriteLine($"Categories:");
                Console.WriteLine($"Channel : {categorydata.Channel}");
                Console.WriteLine($"State : {categorydata.State}");
                Console.WriteLine($"Count : {categorydata.Count}");
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
    private static async Task GetStates() //WIP
    {
        var httpClient = new HttpClient();
        var stateService = new StateService(httpClient);
        var states = await stateService.GetStates();

        foreach (var state in states)
        {
            Console.WriteLine($"Value: {state.Value}");
            Console.WriteLine($"Name: {state.Name}");
            Console.WriteLine(" ");
        }
    }
    private static async Task GetChannels() //WIP
    {
        var httpClient = new HttpClient();
        var channelService = new ChannelService(httpClient);
        var channels = await channelService.GetChannels();

        foreach (var channel in channels)
        {
            Console.WriteLine($"Value: {channel.Value}");
            Console.WriteLine($"Name: {channel.Name}");
            Console.WriteLine(" ");
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
        var packages = await packageService.GetPackageByCustomerKey(customerKey);

        foreach (var package in packages)
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
    private static async Task GetDetailsByPackageKey() //WIP
    {
        Console.WriteLine("Please input the package key");
        string packageKey = Console.ReadLine() ?? "";

        var httpClient = new HttpClient();
        var detailService = new DetailService(httpClient);
        var details = await detailService.GetDetailsByPackageKey(packageKey);

        Console.WriteLine($"Package key: {details.PackageKey}");
        foreach (Category categorydata in details.Categories)
        {
            Console.WriteLine($"Categories:");
            Console.WriteLine($"Channel : {categorydata.Channel}");
            Console.WriteLine($"State : {categorydata.State}");
            Console.WriteLine($"Count : {categorydata.Count}");
            Console.WriteLine(" ");
        }
    }

    private static async Task GetStatisticsByCustomerKey() //WIP
    {
        Console.WriteLine("Please input the customer key");
        string customerKey = Console.ReadLine() ?? "";

        var httpClient = new HttpClient();
        var statisticsService = new StatisticsService(httpClient);
        var statistics = await statisticsService.GetStatisticsByCustomerKey(customerKey);

        Console.WriteLine($"Customer key : {statistics.CustomerKey}");
        Console.WriteLine($"From : {statistics.From}");
        Console.WriteLine($"To : {statistics.To}"); ;
        foreach (Data datadata in statistics.Data)
        {
            Console.WriteLine($"Data:");
            Console.WriteLine($"Date : {datadata.Date}");
            Console.WriteLine($"State : {datadata.State}");
            Console.WriteLine($"Count : {datadata.Channel}");
            Console.WriteLine($"Count : {datadata.Value}");
            Console.WriteLine(" ");
        }
    }
}