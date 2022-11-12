using D5BF9U;
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



var g1 =Game.GameOn();
Task.WaitAll(g1);