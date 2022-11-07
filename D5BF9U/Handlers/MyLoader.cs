using System.Diagnostics;
using Spectre.Console;

namespace D5BF9U.Handlers;

public sealed class MyLoader
{
    public static void FirstLoad()
    {
        AnsiConsole.Status()
            .Start("[mediumvioletred]loading deviancy[/]", ctx => 
            {
                Globals.Globals.MySwitch = 0;
                //todo later when saves or unlocks are done, implement the chapter system too, along with the library
                
                //todo for faster production ima reduce these to tenth of a value, 
                Thread.Sleep(100);
                AnsiConsole.MarkupLine("are you sure you want to play this?");
                Thread.Sleep(200);
                AnsiConsole.MarkupLine("It contains [red]18+[/] elements");
                Thread.Sleep(200);
                AnsiConsole.MarkupLine("yes, even tho its just some ascii stuff");
                Thread.Sleep(200);

            });

        var answer = AnsiConsole.Prompt(new TextPrompt<string>("are you really want to run this game?")
            .ChoicesStyle(new Style().Foreground(Color.Orange1))
            .AddChoices(new[]
            {
                "mhmmm", "nah im good", "sure", "oh hell no!"
            }));
        
        if (answer.Equals("mhmmm")|| answer.Equals("sure"))
        {
            AnsiConsole.MarkupLine("[magenta]as you wish[/]");
            Thread.Sleep(1500);
            AnsiConsole.MarkupLine("[magenta]then please, cum in[/]");
            Thread.Sleep(3000);
        }
        else
        {
            AnsiConsole.MarkupLine("understandable");
            Thread.Sleep(900);
            AnsiConsole.MarkupLine("have a nice day");
            Thread.Sleep(1300);
            Globals.Globals.MySwitch = -1;
        }
    }

    
    public static int LoadLevel_0()
    {
        Console.Clear();

        var selected = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[salmon1]Welcome to the game Cretin![/]")
                .PageSize(10)
                .HighlightStyle(new Style().Foreground(Color.Orange1))
                .MoreChoicesText("[green](Move up and down to reveal more fruits)[/]") //this line of code doesnt even do anything
                .AddChoices(new[]
                {
                    "[mediumvioletred]Start New Game[/]", "[mediumvioletred]Chapter Select[/]",
                    "[mediumvioletred]Library[/]", "[mediumvioletred]Exit[/]" 
                }));

        switch (selected)
        {// i should use a better approach, but its good for now, atleast will have something to refactor later
            case "[mediumvioletred]Start New Game[/]":
                Globals.Globals.MySwitch = 1;
                return 0;
            case "[mediumvioletred]Chapter Select[/]":
                return 1;
            case "[mediumvioletred]Library[/]":
                return 2;
            case "[mediumvioletred]Exit[/]":
                Globals.Globals.MySwitch = -1;
                return -1;
            default:
                return 420;
        }

        
    }
}