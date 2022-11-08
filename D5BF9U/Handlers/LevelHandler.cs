using System.Runtime.CompilerServices;
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
        //Console.Clear();
        UIOperator.DestroyBuffer();
        Console.WriteLine("you've reached level_1_fight method, its still under construction, please leave");
        Console.ReadKey(true);
    }
    public static void Level_1_Cinematic_1()
    {
        UIOperator.DestroyBuffer();
        Console.Clear();
        var mygrid = new Grid();
        mygrid.Width = 180; //todo only test purpose for now
        string[] catArr = null;
        string[] playerArr = null;
        string cat=String.Empty;
        string player=String.Empty;


        var appDir = AppContext.BaseDirectory;
        //Console.WriteLine(appDir);
        try
        {
            //todo how to do it differently, cos teacher said it should not be done like that
            catArr = File.ReadAllLines(Path.Combine(appDir,"../../../ObjektumReferendum/cat.txt"));
            playerArr =File.ReadAllLines(Path.Combine(appDir, "../../../ObjektumReferendum/me.txt"));
            cat = UIOperator.IntoALine(catArr);
            player = UIOperator.IntoALine(playerArr);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The File doesn't exist");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        } 
        
        mygrid.AddColumn();
        mygrid.AddColumn();
        mygrid.AddColumn();
        AnsiConsole.Live(mygrid).Start(UI =>
        {
            //mygrid.Columns = new GridColumn();
            UI.Refresh();
            mygrid.AddRow(new Markup(cat).LeftAligned(),new Markup(" ").Centered(),new Markup(player).RightAligned());
            UI.Refresh();
            Thread.Sleep(2500);
            mygrid.AddRow(new Text(""), new Markup("[red]This da evilest da fluffiest catgirl whose hp is 100![/]").Centered(), new Text(""));
            UI.Refresh();
            Thread.Sleep(4300);
            mygrid.AddRow(new Text(""), new Markup("[red]But me and my gruppie will take it on![/]").Centered(), new Text(""));
            UI.Refresh();
            Thread.Sleep(3800);
            mygrid.AddRow(new Text(""), new Markup("[red]Guard yourself you cute monster![/]").Centered(), new Text(""));
            UI.Refresh();
            Thread.Sleep(3500);
            mygrid.AddRow(new Text(""), new Markup("[red]CHAAAAAAAAAAAAAAAAAAAAAARGE!!![/]").Centered(), new Text(""));
            UI.Refresh();
            Thread.Sleep(2300);
        });
        
        
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
        UIOperator.DestroyBuffer();
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