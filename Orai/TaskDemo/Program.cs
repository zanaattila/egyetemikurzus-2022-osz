using System.Collections.Concurrent;

internal class Program
{
    //private static List<int> Szamok = new();
    private static ConcurrentBag<int> Szamok = new ConcurrentBag<int>();

    private static void Main(string[] args)
    {
        var t1 = Task.Run(() =>
        {
            for (int i = 0; i<100; i += 2)
            {
                Szamok.Add(i);
                /*lock (Szamok)
                {
                    Szamok.Add(i);
                }*/
            }
        });

        var t2 = Task.Run(() =>
        {
            for (int i = 0; i < 100; i += 3)
            {
                Szamok.Add(i);
                /*lock (Szamok)
                {
                    Szamok.Add(i);
                }*/
            }
        });

        Task.WaitAll(t1, t2);

        foreach (var szam in Szamok)
        {
            Console.WriteLine(szam);
        }

        Console.WriteLine("Hello, World!");
    }
}