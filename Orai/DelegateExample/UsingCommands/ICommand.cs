namespace DelegateExample.UsingCommands;

internal interface ICommand
{
    string Name { get; }

    string Description { get; }

    bool Execute(string[] parameters);
}