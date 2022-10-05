namespace DelegateExample.UsingCommands;

// Features the command design pattern:
//   it does not know anything about a concrete command,
//   it knows only about the command interface
internal class CommandLineParser
{
    private readonly string[] _arguments;

    private readonly Dictionary<string, ICommand> _commands = new();

    public CommandLineParser(string[] arguments)
    {
        _arguments = arguments;
    }

    // Each command must be added before parsing the arguments
    // and executing the corresponding command
    public void AddCommand(ICommand command)
    {
        _commands.Add(command.Name, command);
    }

    public void Execute()
    {
        if (TryExecute() is false)
        {
            PrintUsage();
        }
    }

    // Here the single responsibility is questionable,
    // since in addition to parsing the arguments,
    // the corresponding command is also executed
    private bool TryExecute()
    {
        return _arguments.Length > 0 &&
               _commands.TryGetValue(_arguments[0], out var command) &&
               command.Execute(_arguments[1..]);
    }

    // Each command provides its name and short description
    // for this help in a uniform way
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