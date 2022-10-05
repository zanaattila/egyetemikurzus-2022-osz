namespace DelegateExample.AllInOne;

// Violates the single responsibility principle:
//   it is responsible for parsing the arguments
//   as well as implementing and executing the commands
// Violates the open-close principle:
//   every time a new command is added, it is modified,
//   so it is not closed for modifications
internal class CommandLineParser
{
    private readonly string[] _arguments;

    public CommandLineParser(string[] arguments)
    {
        _arguments = arguments;
    }

    // Each new command must be assigned to a case and
    // a method must be implemented that it executes
    public void Execute()
    {
        if (_arguments.Length == 0)
        {
            PrintUsage();
            return;
        }

        switch (_arguments[0])
        {
            case "greet" when _arguments.Length == 3 && _arguments[1] == "--name":
                Greet(_arguments[2]);
                break;

            case "info":
                Info();
                break;

            default:
                PrintUsage();
                break;
        }
    }

    private static void Greet(string name)
    {
        Console.WriteLine($"Greetings to {name}!");
    }

    private static void Info()
    {
        const int padding = -13;

        Console.WriteLine($"{nameof(Environment.OSVersion),padding}{Environment.OSVersion}");
        Console.WriteLine($"{nameof(Environment.MachineName),padding}{Environment.MachineName}");
        Console.WriteLine($"{nameof(Environment.UserName),padding}{Environment.UserName}");
    }

    // Each new command must be added to this help
    // with its short description
    private static void PrintUsage()
    {
        var appName = AppDomain.CurrentDomain.FriendlyName;

        Console.WriteLine($"usage: {appName} <command> [<args>]");
        Console.WriteLine();
        Console.WriteLine($"These are common {appName} commands used in various situations:");
        Console.WriteLine();
        Console.WriteLine("   greet     Show a greeting message");
        Console.WriteLine("   info      Show a summary of system information");
    }
}