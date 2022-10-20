using Reflection;
using System.Reflection;

Console.WriteLine($"Awesome C# Shell {GetVersion()} BETA!");

string GetVersion()
{
    AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();
    return assemblyName.Version?.ToString() ?? "unknown version";
}

var loader = new CommandLoader();

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
