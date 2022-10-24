namespace Reflection.Commands
{
    internal class ExitCommand : IConsoleCommand
    {
        public string Name => "Exit";

        public void Execute() 
        {
            Environment.Exit(0);
        }
    }
}
