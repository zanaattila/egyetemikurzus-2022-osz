using System.Security.Principal;
using System.Text;
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

    private int TableRows => 13;
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

    private BarChart CooldownBarChart(Creature creature)
    {
        BarChart retme = new BarChart();
        if (DateTime.Now.Subtract(creature.GetLastGCDTrigger()).TotalMilliseconds < creature.BaseGlobalCoolDownMs*creature.GetHaste())
        {
            retme.AddItem("CD", DateTime.Now.Subtract(creature.GetLastGCDTrigger()).TotalMilliseconds * 0.01)
                .WithMaxValue(creature.BaseGlobalCoolDownMs * creature.GetHaste() * 0.01);
        }

        return retme;
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
        
        //this might cause error


        retme.AddRow(new Markup[]
        {
            new Markup(UIOperator.ColoredStringBuilder(PlayerColor,Player.GetSpeechBox(),EndTag)),
            new Markup(UIOperator.ColoredStringBuilder(PlayerColor,Player.Name,EndTag))
            
        });
        return retme;
    }

    private Table CreatureTableMaker(Creature creature)
    {
        Table creatureTable = new Table();
        creatureTable.AddColumn(new TableColumn(new Markup(UIOperator.ColoredStringBuilder("[darkmagenta]",creature.Name,"[/]"))));
        for (int i = 0; i < TableRows; i++)
        {
            creatureTable.AddEmptyRow();
        }
        BarChart[] creatureBarChart = CreatureBarChartMaker(creature);
        for (int i = 0; i < creatureBarChart.Length || i < TableRows; i++)
        {
            creatureTable.UpdateCell(i, 0, creatureBarChart[i]);
        }
        Panel creaturePanel = CreaturePanel(creature);
        creatureTable.AddRow(creaturePanel); // this row is the last one, so can use it as @tableRows
        return creatureTable;
    }

    private string ListPlayerSkills()
    {
        string space8 = "        "; //8 times 
        int counter = 1;
        //IOrderedEnumerable<string> skills = Player.SkillLists.Keys.ToList().OrderDescending();
        StringBuilder sb = new StringBuilder();
        foreach (var skill in Player.SkillKeysOrdered)
        {
            sb.Append(skill);
            sb.Append($" ~ {counter}");
            sb.Append(space8);
            ++counter;
        }

        sb.Length -= 8;
        string color = "[lightsalmon3_1]";
        string endTag = "[/]";
        return UIOperator.ColoredStringBuilder(color, sb.ToString(), endTag);
    }
    
    
    public async Task<Creature> FightUI()
    {
               
        //player tables, right side

        Table playerTable = CreatureTableMaker(Player);

       
        //error might occour with rows being blank

        //npc tables, right side
        Table npcTable = CreatureTableMaker(Npc);

        
        //GUI
        Grid GUI = GridUserInterface();


        Table wrapperRoot = new Table();
        wrapperRoot.AddColumns("if you see this header rendered", "then consider it an easter egg", "cos it means i fucked up bad");
        wrapperRoot.HideHeaders();

        wrapperRoot.AddEmptyRow();
        wrapperRoot.AddEmptyRow();

        wrapperRoot.UpdateCell(0, 0, playerTable);
        wrapperRoot.UpdateCell(0, 1, GUI);
        wrapperRoot.UpdateCell(0, 2, npcTable);

        wrapperRoot.UpdateCell(1, 0, CooldownBarChart(Player));
        wrapperRoot.UpdateCell(1, 1, new Markup(ListPlayerSkills()));
        wrapperRoot.UpdateCell(1, 2, CooldownBarChart(Npc));

        

        AnsiConsole.Live(wrapperRoot).Start(ui =>
        {
            while (Npc.GetHealth()> 0 && Player.GetHealth() >0 )
            {
                
                wrapperRoot.UpdateCell(0, 0, CreatureTableMaker(Player));
                wrapperRoot.UpdateCell(0, 1, GridUserInterface());
                wrapperRoot.UpdateCell(0, 2, CreatureTableMaker(Npc));

                wrapperRoot.UpdateCell(1, 0, CooldownBarChart(Player));
                //wrapperRoot.UpdateCell(1, 1, new Markup(ListPlayerSkills()));
                wrapperRoot.UpdateCell(1, 2, CooldownBarChart(Npc));
                
                Thread.Sleep(14); //to give it near 60 fps
            }
            
        });
        
        
        
        return (Npc.GetHealth() == 0 ? Player : Npc );
    }
}