using System.Reflection;

namespace Reflection
{
    internal class CommandLoader
    {
        public Dictionary<string, IConsoleCommand> Commands { get; }

        public CommandLoader()
        {
            Commands = new Dictionary<string, IConsoleCommand>();

            Assembly? asm = Assembly.GetAssembly(typeof(CommandLoader));
            if (asm == null)
                throw new InvalidOperationException("something went wrong");

            var types = asm.GetTypes()
                .Where(type => type.IsClass
                        && !type.IsAbstract
                        && type.IsAssignableTo(typeof(IConsoleCommand)));

            var types2 = from type in asm.GetTypes()
                         where type.IsClass
                           && !type.IsAbstract
                           && type.IsAssignableTo(typeof(IConsoleCommand))
                         select type;

            try
            {
                foreach (var type in types)
                {
                    if (Activator.CreateInstance(type) is IConsoleCommand command)
                    {
                        Commands.Add(command.Name, command);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
