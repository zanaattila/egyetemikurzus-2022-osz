using D5BF9U.Creatures;
using Spectre.Console;

namespace D5BF9U.AutoTasks;

public sealed class UIUpdater
{

    private BarChart[] PlayerBarChartMaker(Creature creature)
    {
        List<BarChart> barCharts = new List<BarChart>();
       // barCharts.Add(new BarChart().Width(30).AddItem("Health", creature.GetHealth())
        //well this is ugly, but i just realized that a set has no order, so it wont guarantee that i will get the same order for the same buffs, ie: these will jump around causing a seizure
        foreach (var item in creature.StatusAilments.ToArray().OrderDescending())
        {
            barCharts.Add(new BarChart().Width(30).AddItem(item.Key,
                Math.Round((item.Value.DurationMillisec - (DateTime.Now.Subtract(item.Value.TimeOfAcquisition).TotalMilliseconds)) * 0.01,0), //divided by 100 so 2 digits shown, scratch that, multiplication is faster
                Color.Aquamarine1).WithMaxValue(Math.Round((item.Value.DurationMillisec*0.01),0)));
        }

        return barCharts.ToArray();
    }
    
    public async Task<Creature> FightUI(Creature player, Creature npc)
    {
        Table root = new Table();
        //add table last

        //add player stuffs
        Table playerTable = new Table();
        playerTable.AddColumn(new TableColumn(player.Name).Centered());
        
        
        Table playerBarcharTable = new Table();
        playerBarcharTable.AddColumn(new TableColumn(new BarChart().Width(20).AddItem("health",20,color: Color.Green)));
        BarChart[] playerBarCharts;//todo
        
        
                
        Table PlayerStatus = new Table();
        Panel vala = new Panel("player log");
        root.AddRow(vala);
        
        
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
        
        
        
        return (npc.GetHealth() == 0 ? player : npc );
    }
}