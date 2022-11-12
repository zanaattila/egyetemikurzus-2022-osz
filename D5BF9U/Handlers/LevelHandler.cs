using System.Runtime.CompilerServices;
using D5BF9U.Containers;
using D5BF9U.Enums;
using D5BF9U.LevelLibraries;
using Spectre.Console;

namespace D5BF9U.Handlers;

public sealed class LevelHandler
{
    public static void Level_1()
    {
        //cinematic of pre
        LevelOne.Level_1_Cinematic_1();
        //fight
        LevelOne.Level_1_Fight();
        //win or lose
        LevelOne.Level_1_Win();
        LevelOne.Level_1_Lose();
        //post cinematic
        LevelOne.Level_1_Cinematic_2();
    }
    
    
    public static void Level_0()
    {
        MainMenuOptionsContainer localSwitch = new MainMenuOptionsContainer();
        while (true)
        {
            switch ( localSwitch.SelectedOption)
            {
                case MainMenuOptions.MainMenu:
                {
                    LevelZero.Level_0_MainMenu(localSwitch);
                    break;
                }
                case MainMenuOptions.StartNewGame:
                {
                    return;
                }
                case MainMenuOptions.ChapterSelect:
                {
                    LevelZero.Level_0_chapter_select(localSwitch);
                    break;
                }
                case MainMenuOptions.Library:
                {
                    
                    break; //todo this will be the skills list
                }
                case MainMenuOptions.Exit:
                {
                    return; //end
                }
                default:
                {
                    throw new Exception("Level handler has unexpected case.");
                }
            }
        }
    }

    
    
    
}