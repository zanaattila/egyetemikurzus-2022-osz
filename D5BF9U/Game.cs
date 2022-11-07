using System.Collections.Concurrent;
using D5BF9U.Handlers;
using Spectre.Console;
using Spectre.Console.Rendering;


namespace D5BF9U;

public sealed class Game
{
    
    #region tmp
    
    
    
    /*
    public class MyClass :IRenderable
    {
        
        public string meine;
        public ConcurrentQueue<int> outwithme = new ConcurrentQueue<int>();
        
        

        public MyClass()
        {
            outwithme.Enqueue(88888888);
            meine = "Leftie";
        }

        public Measurement Measure(RenderContext context, int maxWidth)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Segment> Render(RenderContext context, int maxWidth)
        {
            throw new NotImplementedException();
        }
    }


    public static async Task Teszme(MyClass addme)
    {
        await Task.Run(() =>
        {
            for (int i = 500000000; i < 1000000000; i += 20)
            {
                addme.outwithme.Enqueue(i);
            }
            
        });

    }
    
    public static async Task Teszme2(MyClass addme)
    {
        await Task.Run(() =>
        {
            for (int i = 0; i < 100000000; i += 3)
            {
                addme.outwithme.Enqueue(i);
            }
            
        });

    }

    public static async Task OLD_Teszting()
    {
        MyClass csacsi = new MyClass();
        /*ConcurrentQueue<int> outwithme = new ConcurrentQueue<int>();
        
        outwithme.Enqueue(88888888);#1#
        var tusk1 = Teszme(csacsi);
        var tusk2 = Teszme2(csacsi);
        int tmp = 0;
        var task3 = Task.Run(() =>
        {
            while (!csacsi.outwithme.IsEmpty)
            {
                csacsi.outwithme.TryDequeue(out tmp);
                Console.WriteLine($"reading enque {tmp}");
                
            }
        });
        Task.WaitAll(tusk1, tusk2, task3);
        Table nuncsaku = new Table();
        nuncsaku.AddColumns(csacsi.outwithme.TryDequeue(out tmp).ToString());

        AnsiConsole.Live(nuncsaku).Start(ui =>
        {
            
        });


        /*for (int i = 0; i < 250000; i++)
        {
            Console.WriteLine(i);
        }#1#

        Console.WriteLine("im running, making main 1 line");
        Table valami = new Table();
        Table valami2 = new Table();
        
        
        ConcurrentBag<int> GudSzamok = new ConcurrentBag<int>(); // ő a lista
        ConcurrentDictionary<int,int> mydict = new ConcurrentDictionary<int, int>();
        //todo, fontos, optimalizálásnak
        /*int i = i++;  //ez lassabb
        ++i;#1# //ez gyorsabb, ez elemi művelet


        foreach (var szam in GudSzamok)
        {
            Console.WriteLine(szam);
        }


        Console.WriteLine(GudSzamok.Count);
        string meine = "Rightie";
        valami.AddColumns(csacsi.meine ,meine);
        valami2.AddColumns("nincs");

        //a második már nem megy bele,
        valami.AddRow("ftesztelek", "valamait");
        //valami2.AddRow(new Markup("fa"), valami);
        //valami2.AddRow("fa", valami); this is wrong, seemslike and overloading function missing,  but other than that it works on a diff approach
        valami2.AddRow(valami);


        var t2 =Task.Run(() =>
        {
            for (int i = 0; i < 10000000000; i+=3)
            {
                valami.Rows.Update(0,1,new Markup( i.ToString()));
            }
        });

        var t1 = Task.Run(() =>
        {
            for (int i = 0; i < 10000000000; i += 20)
            {
                valami.Rows.Update(0, 0, new Markup(i.ToString()));
            }

        });
        //so ive been wondering if this is thread safe or not, tho as the table shows below, the left panels last digit
        //stays 0, which means no number 3 gets passed to it.
        //oooookay, so it should work then, right?
        //well i hope so cos ill need to do make tasks like these from now on and if a skills is switched or a value
        //during its use then everything breaks
        
        var t3 = Task.Run(() =>
        {
            AnsiConsole.Live(valami2).Start(UI =>
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
            });
        });


        Task.WaitAll(t1, t2, t3);
        
        
        
        Console.WriteLine();
    }*/
    
    #endregion
    
    
    
    public static async Task GameOn()
    {
        MyLoader.FirstLoad();

        await Task.Run(() =>
        {
            while (Globals.Globals.MySwitch!=-1)
            {
                MyEventHandler.HandleMe(Console.ReadKey().Key);
            }
        });
        /*for (int i = 0; i < 1000000; i++)
        {
            Console.WriteLine(i);
        }*/
    }
}