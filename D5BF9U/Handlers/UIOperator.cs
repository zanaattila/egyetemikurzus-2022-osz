namespace D5BF9U.Handlers;

public static class UIOperator
{
    public static string IntoALine(string [] input)
    {
        string retme=String.Empty;
        foreach (var line in input)
        {
            retme=String.Concat(retme,line + "\n");
        }
        int tmp = retme.Length-1;
        return retme.Substring(0,tmp);
    }
    
    
    /// <summary>
    /// Untill a Console.ReadKey is done, whatever key is pressed is kept in the buffer which can
    /// stack up in an asleep thread. this method, reads them all and basically destroys them
    /// </summary>
    public static void DestroyBuffer()
    {
        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }
    }
}