using System.Text.Json;
using D5BF9U;
using D5BF9U.AutoTasks;
using Spectre.Console;

/*
Table valami = new Table();
int x = 0;
BarChart chart = new BarChart().Width(60)
    .Label("[green bold underline]Number of fruits[/]")
    .CenterLabel()
    .AddItem("Apple", x, Color.Yellow)
    .AddItem("Orange", 54, Color.Green)
    .AddItem("Banana", 33, Color.Red);


valami.AddColumn("foo");
valami.AddRow(chart);

AnsiConsole.Live(valami)
    .Start(ctx => 
    {
        ctx.Refresh();
        for (int i = 0; i < 80; i++)
        {
            x = i;
            ctx.UpdateTarget(valami);
            Thread.Sleep(30);
        }
        
        
        ctx.Refresh();
        Thread.Sleep(1000);
    });
    */ //todo test later on stable release, tho supposed to work

string[] nem = new[] { "ceh", "nem", "igen", "minek" };

Table root = new Table();
root.AddColumn("Name").Width(40);
/*root.AddColumn("");
root.AddColumn("npc.Name"); ;
Panel vala = new Panel("player \nsmlaks\nlehulelel");
vala.Header = new PanelHeader("info log");
root.Caption = new TableTitle("alulvonás");*/
string valak = "mivan???";
//root.AddRow(,new Markup("csa"),new Markup("ha"));
BarChart fave = new BarChart().Width(50).AddItem(valak, 20, color: Color.Green);
//root.AddRow(new BarChart().Width(20).AddItem("health",20,color: Color.Green));
double i = 0;
root.AddRow(fave);
//root.UpdateCell(0,2,)
AnsiConsole.Live(root).Start(ui =>
{
    while (true)
    {
        //root.UpdateCell(0,2,)
        ui.Refresh();
        
        i = (i +0.1) % 40;
        //TODO WITH MAX VALUE!!!! damn it took 2 and a half hours just finding it and in the end i found a description in the github issues
        //https://github.com/spectreconsole/spectre.console/pull/545
        valak = "heeeeee?";
        root.UpdateCell(0,0,new BarChart().Width(40).AddItem("123456", Math.Round(i,1), Color.Green).WithMaxValue(20));
        
        // fave.Data[0] = new BarChartItem("health", i, Color.Green);
        ui.UpdateTarget(root);
        ui.Refresh();
        Thread.Sleep(14);
        Console.ReadKey();
        
            /*root.Rows.Update(0,0,
    ui.UpdateTarget(root.UpdateCell(0));*/ ;
    }
});

string valami = "hello";
string tmp = valami;
string v2 = "world";
//okay it works, but had to update to dotnet 7
Console.WriteLine(Interlocked.CompareExchange(ref valami,v2,valami));
Console.WriteLine(valami);
//i see now ahaaa

Console.ReadKey();
var g1 =Game.GameOn();
Task.WaitAll(g1);