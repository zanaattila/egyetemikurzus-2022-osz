using D5BF9U.Enums;
using D5BF9U.Globals;

namespace D5BF9U.Handlers;

public sealed class MyEventHandler
{
    public static void HandleMe() 
    {
        switch (Globals.Globals.MySwitch)
        {
            case LevelAdjustingSwitch.MainMenu:
            {
                LevelHandler.Level_0();
                break;
            }
            case LevelAdjustingSwitch.LevelOne:
            {
                LevelHandler.Level_1();
                break;
            }
            /*case 2:
            {
                break;
            }*/
        }
    }
}