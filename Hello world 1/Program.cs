Console.WriteLine("What is Your name?");
var name = Console.ReadLine();
var currentDate = DateTime.Now;
Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {currentDate:d}");
Console.WriteLine($"{Environment.NewLine}Press any key to exit...");
Console.ReadKey(true);