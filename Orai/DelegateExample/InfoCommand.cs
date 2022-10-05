using DelegateExample.UsingCommands;

namespace DelegateExample;

internal class InfoCommand : ICommand
{
    public string Name => "info";
    public string Description => "Show a summary of system information";

    public bool Execute(string[] parameters)
    {
        const int padding = -13;

        Console.WriteLine($"{nameof(Environment.OSVersion),padding}{Environment.OSVersion}");
        Console.WriteLine($"{nameof(Environment.MachineName),padding}{Environment.MachineName}");
        Console.WriteLine($"{nameof(Environment.UserName),padding}{Environment.UserName}");

        return true;
    }
}