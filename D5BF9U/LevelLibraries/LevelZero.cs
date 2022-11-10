using System.Text;
using D5BF9U.Handlers;
using Spectre.Console;

namespace D5BF9U.LevelLibraries;

public sealed class LevelZero
{
    
    
    public static int Level_0_MainMenu()
    {
        UIOperator.DestroyBuffer();
        Console.Clear();
        string choiceColor = "[mediumvioletred]";
        string titleColor = "[salmon]";
        string endTag = "[/]";

        var selected = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(ColoredStringBuilder(titleColor,"Welcome to the game of Deviants!",endTag))
                .PageSize(10)
                .HighlightStyle(new Style().Foreground(Color.Orange1))
                .MoreChoicesText("[green](Move up and down to reveal more fruits)[/]") //this line of code doesnt even do anything
                .AddChoices(new[]
                {
                    ColoredStringBuilder(choiceColor,"Start New Game",endTag), ColoredStringBuilder(choiceColor,"Chapter Select",endTag),
                    ColoredStringBuilder(choiceColor,"Library",endTag), ColoredStringBuilder(choiceColor,"Exit",endTag)
                }));

        switch (ColoredStringDemolisher(choiceColor,selected,endTag))
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
    private static string ColoredStringBuilder(string color, string choice, string endTag)
    {
        StringBuilder concatWithColor = new StringBuilder();
        concatWithColor.Append(color);
        concatWithColor.Append(choice);
        concatWithColor.Append(endTag);
        return concatWithColor.ToString();
    }

    private static string ColoredStringDemolisher(string color,string destroyMe, string endTag)
    {
        StringBuilder keywordTrimmer = new StringBuilder();
        keywordTrimmer.Append(destroyMe);
        keywordTrimmer.Replace(color, "");
        keywordTrimmer.Replace(endTag, "");
        return keywordTrimmer.ToString();
    }
    public static int Level_0_chapter_select()
    {
        Console.Clear();
        

        string choiceColor = "[mediumvioletred]";
        string titleColor = "[salmon]";
        string endTag = "[/]";
        


        var selected = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(ColoredStringBuilder(titleColor,"Welcome to the game of Deviants!",endTag))
                .PageSize(5)
                .HighlightStyle(new Style().Foreground(Color.Orange1))
                .MoreChoicesText("[green](Move up and down to reveal more fruits)[/]") //this line of code doesnt even do anything
                .AddChoices(new[]
                {
                    ColoredStringBuilder(choiceColor,"back",endTag), ColoredStringBuilder(choiceColor,"Level One",endTag),
                    ColoredStringBuilder(choiceColor,"Level Two",endTag), ColoredStringBuilder(choiceColor,"Exit",endTag) 
                }));

        

        switch (ColoredStringDemolisher(choiceColor,selected,endTag))
        {// i should use a better approach, but its good for now, atleast will have something to refactor later //edit, i got it
            case "back":
                return 0;
            case "Level One":
                return 1;
            case "Leve Two":
                return 2;
            case "Exit":
                Globals.Globals.MySwitch = -1;
                return -1;
            default:
                return 420;
        }
    }
}