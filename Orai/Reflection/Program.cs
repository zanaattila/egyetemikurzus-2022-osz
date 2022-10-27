using Reflection;
using System.Reflection;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine($"Awesome C# Shell {GetVersion()} BETA!");

        string GetVersion()
        {
            AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();
            return assemblyName.Version?.ToString() ?? "unknown version";
        }

        var loader = new CommandLoader();

        try
        {
            while (true)
            {
                Console.Write("Type command: ");
                string? command = Console.ReadLine();
                if (!string.IsNullOrEmpty(command)
                    && loader.Commands.ContainsKey(command))
                {
                    loader.Commands[command].Execute();
                }
                else
                {
                    Console.WriteLine("Something went wrong");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hiba: {ex.Message}");
        }

        await Task.Delay(1000);
    }
}