using System.Security.Principal;
using D5BF9U.Creatures;
using D5BF9U.Handlers;
using Spectre.Console;

namespace D5BF9U.AutoTasks;

public sealed class UIUpdater
{
    private Creature Player { get; set; }
    private Creature Npc { get; set; }
    string CatColor => "[deeppink3_1]";
    string PlayerColor => "[orangered1]";
    string EndTag => "[/]"; 
    public UIUpdater(Creature player, Creature npc)
    {
        Player = player;
        Npc = npc;
    }

    private Panel CreaturePanel(Creature creature)
    {
        //this is the log
        //this isnt thread safe i guess, but im just reading so  ¯\_(ツ)_/¯ not that crucial
        return new Panel(UIOperator.IntoALineWithNewLine(creature.PersonalCombatLog.PlaceHolders));
    }
    private BarChart[] CreatureBarChartMaker(Creature creature)
    {
        List<BarChart> barCharts = new List<BarChart>();
        barCharts.Add(new BarChart().AddItem("Health", creature.GetHealth(),Color.Green).WithMaxValue(creature.GetMaxHealth()));
        //well this is ugly, but i just realized that a set has no order, so it wont guarantee that i will get the same order for the same buffs, ie: these will jump around causing a seizure
        foreach (var item in creature.StatusAilments.ToArray().OrderDescending())
        {
            barCharts.Add(new BarChart().AddItem(item.Key,
                Math.Round((item.Value.DurationMillisec - (DateTime.Now.Subtract(item.Value.TimeOfAcquisition).TotalMilliseconds)) * 0.01,0), //divided by 100 so 2 digits shown, scratch that, multiplication is faster
                Color.Aquamarine1).WithMaxValue(Math.Round((item.Value.DurationMillisec*0.01),0)));
        }

        return barCharts.ToArray();
    }

    private Grid GridUserInterface()
    {
        Grid retme = new Grid();
        retme.AddColumn(); //one for  pic one for text box
        retme.AddColumn();

        retme.AddRow(new Markup[]
        {
            new Markup(UIOperator.ColoredStringBuilder(CatColor,Npc.Name,EndTag)),
            new Markup(UIOperator.ColoredStringBuilder(CatColor,Npc.GetSpeechBox(),EndTag))
        });


        retme.AddRow(new Markup[]
        {
            new Markup(UIOperator.ColoredStringBuilder(PlayerColor,Player.GetSpeechBox(),EndTag)),
            new Markup(UIOperator.ColoredStringBuilder(PlayerColor,Player.Name,EndTag))
            
        });
        return retme;
    }
    
    public async Task<Creature> FightUI()
    {
        int tableRows = 13;
        Table root = new Table();
        //add table last

        //add player stuffs
        /*Table playerTable = new Table();
        playerTable.AddColumn(new TableColumn(player.Name).Centered());*/
        
        //player tables, right side
        Table playerTable = new Table();
        playerTable.AddColumn(new TableColumn(new Markup(UIOperator.ColoredStringBuilder("[darkmagenta]",Player.Name,"[/]"))));
        for (int i = 0; i < tableRows; i++)
        {
            playerTable.AddEmptyRow();
        }
        BarChart[] playerBarCharts = CreatureBarChartMaker(Player);
        for (int i = 0; i < playerBarCharts.Length || i < tableRows; i++)
        {
            playerTable.UpdateCell(i, 0, playerBarCharts[i]);
        }
        Panel playerLog = CreaturePanel(Player);
        playerTable.AddRow(playerLog); // this row is the last one, so can use it as @tableRows
        
        
        //error might occour with rows being blank

        //npc tables, right side
        Table npcTable = new Table();
        npcTable.AddColumn(new TableColumn(new Markup(UIOperator.ColoredStringBuilder("[darkmagenta]",Npc.Name,"[/]"))));
        for (int i = 0; i < tableRows; i++)
        {
            npcTable.AddEmptyRow();
        }
        BarChart[] npcBarCharts = CreatureBarChartMaker(Npc);
        for (int i = 0; i < npcBarCharts.Length || i < tableRows; i++)
        {
            npcTable.UpdateCell(i, 0, npcBarCharts[i]);
        }
        Panel npcLog = CreaturePanel(Npc);
        npcTable.AddRow(npcLog);
        
        
        //gui from here

        Grid GUI = GridUserInterface();
        
        
        
        //todo next is to assemble these into a 3 column table
        

       


        /*AnsiConsole.Live(valami2).Start(UI =>
        {

            for (int i = 0; i < 500000000; i++)
            {
                    
                UI.Refresh();
            }

            UI.Refresh();
            Thread.Sleep(1150);
            //valami2.AddRow(valami, valami);

            meine = "anyaaaaaaaad";
            UI.UpdateTarget(valami);
            UI.UpdateTarget(valami2);
            Thread.Sleep(1150);
            meine = "namivan, megy?";

            valami.Rows.Update(0, 0, new Markup(meine));
            UI.UpdateTarget(valami);
            UI.UpdateTarget(valami2);
            //UI.Refresh();
            Thread.Sleep(1250);
            valami.BorderColor(Color.Yellow);

            valami.Rows.Update(0, 1, new Markup("úgy néz ki igen"));
            //valami2[0][0]=
            UI.Refresh();
            Thread.Sleep(1250);
        });*/
        
        
        
        return (Npc.GetHealth() == 0 ? Player : Npc );
    }
}