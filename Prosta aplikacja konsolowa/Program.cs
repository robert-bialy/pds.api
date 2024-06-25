using System;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonExample
{
    class Program
    {
        public static async Task Main()
        {
            Console.WriteLine("For get documents/ customers press 1, for get documents/ packages press 2, for get documents/ cosignments press 3");
            string UserInput = Console.ReadLine() ??"";
            if (UserInput == "1")
            {
               await GetCustomers();
            }
            if (UserInput == "2")
            {
                await GetPackages();
            }
            else
            {
                await GetCosignments();
            }   
        }

        static async Task GetCustomers() //Get customers
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://localhost:5000/api/v1/documents/customers?PageSize=1000&PageIndex=0");//GetDocumentCustomer
            var content = await response.Content.ReadAsStringAsync();

            try
            {
                Response<Customer> customerResponse = JsonSerializer.Deserialize<Response<Customer>>(content);
                Customer[] Customers = customerResponse.data;

                foreach (Customer Customer in Customers)
                {
                    Console.WriteLine($"Customer key: {Customer.CustomerKey}");
                    Console.WriteLine($"Name: {Customer.Name}");
                    Console.WriteLine($"Number: {Customer.Number}");
                    Console.WriteLine($"Created at: {Customer.CreatedAt}");
                    Console.WriteLine(" ");
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Json deserialization error:{ex.Message}");
            }
        }

        static async Task GetPackages() //Get packages
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://localhost:5000/api/v1/documents/packages?PageSize=1000&PageIndex=0"); //GetDocumentPackage
            var content = await response.Content.ReadAsStringAsync();

            try
            {
                Response<Package> customerResponse = JsonSerializer.Deserialize<Response<Package>>(content);
                Package[] packages = customerResponse.data;

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
            catch (JsonException ex)
            {
                Console.WriteLine($"Json deserialization error:{ex.Message}");
            }
        }
        static async Task GetCosignments() //Get cosignment
        {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("http://localhost:5000/api/v1/documents/consignments?PageSize=1000&PageIndex=0");  //GetDocumentCosignment
                var content = await response.Content.ReadAsStringAsync();

            try
            {
                Response<Consignment> cosignmentResponse = JsonSerializer.Deserialize<Response<Consignment>>(content);
                Consignment[] cosignments = cosignmentResponse.data;

                foreach (Consignment consignment in cosignments)
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
            catch (JsonException ex)
            {
                Console.WriteLine($"Json deserialization error:{ex.Message}");
            }
        }

    }
}

