namespace D5BF9U;

public sealed class Game
{
    public static async Task GameOn()
    {
        for (int i = 0; i < 1000000; i++)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("im running, making main 1 line");
        
    }
}