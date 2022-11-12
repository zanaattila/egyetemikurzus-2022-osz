using System.Text;
using D5BF9U.Containers;
using D5BF9U.Enums;
using D5BF9U.Globals;
using D5BF9U.Handlers;
using Spectre.Console;


namespace D5BF9U.LevelLibraries;

public sealed class LevelZero
{
    
    public static void Level_0_MainMenu(MainMenuOptionsContainer optionsContainer)
    {
        UIOperator.DestroyBuffer();
        Console.Clear();
        string choiceColor = "[mediumvioletred]";
        string titleColor = "[salmon1]";
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
            case "Start New Game":
                Globals.Globals.MySwitch = LevelAdjustingSwitch.LevelOne;
                optionsContainer.SelectedOption = MainMenuOptions.MainMenu;
                break;
            case "Chapter Select":
                optionsContainer.SelectedOption = MainMenuOptions.ChapterSelect;
                break;
            case "Library":
                optionsContainer.SelectedOption = MainMenuOptions.Library;
                break;
            case "Exit":
                Globals.Globals.MySwitch = LevelAdjustingSwitch.Exit;
                optionsContainer.SelectedOption = MainMenuOptions.Exit;
                break;
            default:
                throw new Exception("Unexpected switch case in Level_0_MainMenu");
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
    public static void Level_0_chapter_select(MainMenuOptionsContainer optionsContainer)
    {
        Console.Clear();
        

        string choiceColor = "[mediumvioletred]";
        string titleColor = "[salmon1]";
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
                optionsContainer.SelectedOption = MainMenuOptions.MainMenu;
                break;
            case "Level One":
                optionsContainer.SelectedOption = MainMenuOptions.Level1;
                break;
            case "Leve Two":
                optionsContainer.SelectedOption = MainMenuOptions.Level2;
                break;
            case "Exit":
                Globals.Globals.MySwitch = LevelAdjustingSwitch.Exit;
                optionsContainer.SelectedOption = MainMenuOptions.Exit;
                break;
            default:
                throw new Exception("Unexpected switch case at chapter select");
        }
    }
}