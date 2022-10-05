namespace DelegateExample.UsingDelegates;

// Declares a delegate type for encapsulating references to
// methods that take strings as a parameter and return bool
internal delegate bool Command(string[] parameters);

// Declares a type for coupling delegates representing
// commands with their names and descriptions
internal record CommandInfo(string Name, string Description, Command Execute);

// Features delegates:
//   it can invoke methods referenced by delegate objects,
//   without having to know which methods will be invoked
internal class CommandLineParser
{
    private readonly string[] _arguments;

    private readonly Dictionary<string, CommandInfo> _commands = new();

    public CommandLineParser(string[] arguments)
    {
        _arguments = arguments;
    }

    public void AddCommand(string name, string description, Command command)
    {
        _commands.Add(name, new CommandInfo(name, description, command));
    }

    // From there, its implementation is the same as
    // the version that uses the command design pattern
    public void Execute()
    {
        if (TryExecute() is false)
        {
            PrintUsage();
        }
    }

    private bool TryExecute()
    {
        return _arguments.Length > 0 &&
               _commands.TryGetValue(_arguments[0], out var command) &&
               command.Execute(_arguments[1..]);
    }

    private void PrintUsage()
    {
        var appName = AppDomain.CurrentDomain.FriendlyName;

        Console.WriteLine($"usage: {appName} <command> [<args>]");
        Console.WriteLine();
        Console.WriteLine($"These are common {appName} commands used in various situations:");
        Console.WriteLine();

        foreach (var command in _commands.Values)
        {
            Console.WriteLine($"   {command.Name,-10}{command.Description}");
        }
    }
}