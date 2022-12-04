using System.Collections.Concurrent;
using D5BF9U.Enums;
using D5BF9U.Globals;
using D5BF9U.Handlers;
using Spectre.Console;
using Spectre.Console.Rendering;


namespace D5BF9U;

public sealed class Game
{
    public static async Task GameOn()
    {
        MyLoader.FirstLoad();

        await Task.Run(() =>
        {
            while (Globals.Globals.MySwitch!= LevelAdjustingSwitch.Exit)
            {
                MyEventHandler.HandleMe();
            }
        });
        Console.WriteLine("goodbye, thank you for playing");
    }
}