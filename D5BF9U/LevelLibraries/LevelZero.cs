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
                .Title(UIOperator.ColoredStringBuilder(titleColor,"Welcome to the game of Deviants!",endTag))
                .PageSize(10)
                .HighlightStyle(new Style().Foreground(Color.Orange1))
                .MoreChoicesText("[green](this line of code is not even shown)[/]") //this line of code doesnt even do anything
                .AddChoices(new[]
                {
                    UIOperator.ColoredStringBuilder(choiceColor,"Start New Game",endTag), UIOperator.ColoredStringBuilder(choiceColor,"Chapter Select",endTag),
                    UIOperator.ColoredStringBuilder(choiceColor,"Library",endTag), UIOperator.ColoredStringBuilder(choiceColor,"Exit",endTag)
                }));

        switch (UIOperator.ColoredStringDemolisher(choiceColor,selected,endTag))
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
    
    public static void Level_0_chapter_select(MainMenuOptionsContainer optionsContainer)
    {
        Console.Clear();
        

        string choiceColor = "[mediumvioletred]";
        string titleColor = "[salmon1]";
        string endTag = "[/]";
        


        var selected = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(UIOperator.ColoredStringBuilder(titleColor,"Welcome to the game of Deviants!",endTag))
                .PageSize(5)
                .HighlightStyle(new Style().Foreground(Color.Orange1))
                .MoreChoicesText("[green](Move up and down to reveal more fruits)[/]") //this line of code doesnt even do anything
                .AddChoices(new[]
                {
                    UIOperator.ColoredStringBuilder(choiceColor,"back",endTag), UIOperator.ColoredStringBuilder(choiceColor,"Level One",endTag),
                    UIOperator.ColoredStringBuilder(choiceColor,"Level Two",endTag), UIOperator.ColoredStringBuilder(choiceColor,"Exit",endTag) 
                }));

        

        switch (UIOperator.ColoredStringDemolisher(choiceColor,selected,endTag))
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