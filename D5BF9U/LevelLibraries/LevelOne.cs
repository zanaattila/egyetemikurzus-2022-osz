using D5BF9U.Handlers;
using Spectre.Console;

namespace D5BF9U.LevelLibraries;

public sealed class LevelOne
{
 
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

}