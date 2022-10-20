namespace Reflection.Commands
{
    internal sealed class TimeCommand : IConsoleCommand
    {
        public string Name => "Time";

        public void Execute()
        {
            Console.WriteLine($"{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}");
        }
    }
}
