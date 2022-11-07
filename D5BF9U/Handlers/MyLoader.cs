using Spectre.Console;

namespace D5BF9U.Handlers;

public sealed class MyLoader
{
    public static void FirstLoad()
    {
        Globals.Globals.MySwitch = 0;
        LoadLevel_0();
    }

    
    public static void LoadLevel_0()
    {
        Console.Clear();
        var fruit = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[salmon1]Welcome to the game Cretin![/]")
                .PageSize(5)
                .HighlightStyle(new Style().Foreground(Color.Orange1))
                .MoreChoicesText("[green](Move up and down to reveal more fruits)[/]") //this line of code doesnt even do anything
                .AddChoices(new[]
                {
                    "[mediumvioletred]Start New Game[/]", "[mediumvioletred]Load Game[/]",
                    "[mediumvioletred]Library[/]", "[mediumvioletred]Exit[/]" 
                }));

        // Echo the fruit back to the terminal
        AnsiConsole.WriteLine($"I agree. {fruit} is tasty!");

    }
}