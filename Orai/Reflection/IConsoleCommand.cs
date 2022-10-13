namespace Reflection
{
    internal interface IConsoleCommand
    {
        string Name { get; }
        void Execute();
    }
}
