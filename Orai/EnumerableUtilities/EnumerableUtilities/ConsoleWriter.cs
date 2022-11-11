namespace EnumerableUtilities;

internal static class ConsoleWriter
{
    public static void WriteLine(IEnumerable<char> characters)
    {
        Console.WriteLine($@"""{string.Concat(characters)}""");
    }

    public static void WriteLine<T>(IEnumerable<T> enumerable)
    {
        Console.WriteLine($@"{{ {string.Join(", ", enumerable)} }}");
    }

    public static void WriteLine()
    {
        Console.WriteLine();
    }
}