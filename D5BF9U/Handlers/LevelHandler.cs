using Spectre.Console;

namespace D5BF9U.Handlers;

public sealed class LevelHandler
{
    public static void Level_1()
    {
        //cinematic of pre
        Level_1_Cinematic_1();
        //fight
        Level_1_Fight();
        //win or lose
        Level_1_Win();
        Level_1_Lose();
        //post cinematic
        Level_1_Cinematic_2();
    }

    public static void Level_1_Fight()
    {
        
    }
    public static void Level_1_Cinematic_1()
    {
        Console.Clear();
    }


    public static void Level_1_Win()
    {
        
    }

    public static void Level_1_Lose()
    {
        
    }

    public static void Level_1_Cinematic_2()
    {
        
    }

    public static int Level_0_MainMenu()
    {
        Console.Clear();

        var selected = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[salmon1]Welcome to the game of Deviants![/]")
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
    
    public static void Level_0()
    {
        bool amikeeping = true;
        while (amikeeping)
        {
            switch (Level_0_MainMenu())
            {
                case 0:
                {
                    return;
                }
                case 1:
                {
                    switch (Level_0_chapter_select())
                    {
                        case 0:
                        {
                            break;
                        }
                    }
                
                    break; //todo, when ill get home i should check spectre cos i might gonna use a tree sheet or something alike.
                }
                case 2:
                {
                    return; //todo this will be the skills list
                }
                case -1:
                {
                    return; //end
                }
                case 420:
                {
                    throw new Exception("Something went bonkers");
                }
            }
        }
    }

    
    
    public static int Level_0_chapter_select()
    {
        Console.Clear();
        string choice_color = "[mediumvioletred]";
        string end_tag = "[/]";

        var selected = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[salmon1]Welcome to the game of Deviants![/]")
                .PageSize(5)
                .HighlightStyle(new Style().Foreground(Color.Orange1))
                .MoreChoicesText("[green](Move up and down to reveal more fruits)[/]") //this line of code doesnt even do anything
                .AddChoices(new[]
                {
                    "[mediumvioletred]back[/]", "[mediumvioletred]Chap12eter Select[/]",
                    "[mediumvioletred]Libsssssrary[/]", "[mediumvioletred]Exsssit[/]" 
                }));

        switch (selected)
        {// i should use a better approach, but its good for now, atleast will have something to refactor later
            case "[mediumvioletred]back[/]":
                
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