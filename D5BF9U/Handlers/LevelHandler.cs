using System.Runtime.CompilerServices;
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
        bool amikeeping = true;
        while (amikeeping)
        {
            switch (LevelZero.Level_0_MainMenu())
            {
                case 0:
                {
                    return;
                }
                case 1:
                {
                    switch (LevelZero.Level_0_chapter_select())
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

    
    
    
}