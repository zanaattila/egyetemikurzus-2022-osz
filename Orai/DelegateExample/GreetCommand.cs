using DelegateExample.UsingCommands;

namespace DelegateExample;

internal class GreetCommand : ICommand
{
    public string Name => "greet";

    public string Description => "Show a greeting message";

    public bool Execute(string[] parameters)
    {
        if (parameters.Length != 2 || parameters[0] != "--name")
        {
            return false;
        }

        Console.WriteLine($"Greetings to {parameters[1]}!");

        return true;
    }
}