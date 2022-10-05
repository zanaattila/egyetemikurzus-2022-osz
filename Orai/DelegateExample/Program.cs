namespace DelegateExample;

internal class Program
{
    private static void Main(string[] args)
    {
        #region Testing all-in-one parser

        Console.WriteLine();
        Console.WriteLine("Executing the all-in-one parser...");
        Console.WriteLine("================================================================================");

        var allInOneParser = new AllInOne.CommandLineParser(args);
        allInOneParser.Execute();

        #endregion

        #region Testing parser using commands

        Console.WriteLine();
        Console.WriteLine("Executing the parser using commands...");
        Console.WriteLine("================================================================================");

        var commandParser = new UsingCommands.CommandLineParser(args);
        commandParser.AddCommand(new GreetCommand());
        commandParser.AddCommand(new InfoCommand());
        commandParser.Execute();

        #endregion

        #region Testing parser using delegates

        Console.WriteLine();
        Console.WriteLine("Executing the parser using delegates...");
        Console.WriteLine("================================================================================");

        var delegateParser = new UsingDelegates.CommandLineParser(args);
        delegateParser.AddCommand("greet", "Show a greeting message", Greet);
        delegateParser.AddCommand("info", "Show a summary of system information", Info);
        delegateParser.Execute();

        #endregion

        #region Testing parser using lambda expressions

        Console.WriteLine();
        Console.WriteLine("Executing the parser using lambda expressions...");
        Console.WriteLine("================================================================================");

        var lambdaParser = new UsingDelegates.CommandLineParser(args);

        lambdaParser.AddCommand("greet", "Show a greeting message", parameters =>
        {
            if (parameters.Length != 2 || parameters[0] != "--name")
            {
                return false;
            }

            Console.WriteLine($"Greetings to {parameters[1]}!");

            return true;
        });

        lambdaParser.AddCommand("info", "Show a summary of system information", _ =>
        {
            const int padding = -13;

            Console.WriteLine($"{nameof(Environment.OSVersion),padding}{Environment.OSVersion}");
            Console.WriteLine($"{nameof(Environment.MachineName),padding}{Environment.MachineName}");
            Console.WriteLine($"{nameof(Environment.UserName),padding}{Environment.UserName}");

            return true;
        });

        lambdaParser.Execute();

        #endregion
    }

    #region Command implementations

    private static bool Greet(string[] parameters)
    {
        if (parameters.Length != 2 || parameters[0] != "--name")
        {
            return false;
        }

        Console.WriteLine($"Greetings to {parameters[1]}!");

        return true;
    }

    private static bool Info(string[] parameters)
    {
        const int padding = -13;

        Console.WriteLine($"{nameof(Environment.OSVersion),padding}{Environment.OSVersion}");
        Console.WriteLine($"{nameof(Environment.MachineName),padding}{Environment.MachineName}");
        Console.WriteLine($"{nameof(Environment.UserName),padding}{Environment.UserName}");

        return true;
    }

    #endregion
}