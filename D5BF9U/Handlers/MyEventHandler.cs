namespace D5BF9U.Handlers;

public sealed class MyEventHandler
{
    public static void HandleMe() // i did in another project just basically tackling the key down switches... seems like it wont follow that pattern
    {
        //LevelHandler levelHandler = new LevelHandler(); i decided to make the handlers methods all statis, so it doesnt have to allocate memory for them each time
        //and i can reach its method everywhere just like a proper class. Maybe this is where i make libs?
        switch (Globals.Globals.MySwitch)
        {
            case 0:
            {
                LevelHandler.Level_0();
                break;
            }
            case 1:
            {
                LevelHandler.Level_1();
                break;
            }
            case 2:
            {
                break;
            }
        }
        
       // Console.WriteLine($"pressed {consoleKey}");
    }
}