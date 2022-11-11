namespace EnumerableUtilities.AllInOne;

// Although these methods often express what they do in a readable way,
// they are less reusable, and classes that encapsulate such methods
// can accumulate a lot of dependencies and responsibilities
internal static class EnumerableExtensions
{
    public static IEnumerable<char> RemoveAllWhitespaces(this IEnumerable<char> characters)
    {
        foreach (var currentChar in characters)
        {
            if (!char.IsWhiteSpace(currentChar))
            {
                yield return currentChar;
            }
        }
    }

    public static IEnumerable<int> RemoveAllOddValues(this IEnumerable<int> numbers)
    {
        foreach (var number in numbers)
        {
            if (number % 2 == 0)
            {
                yield return number;
            }
        }
    }

    public static IEnumerable<Category> GetAllCategories(this IEnumerable<Asset> assets)
    {
        foreach (var asset in assets)
        {
            yield return asset.Category;
        }
    }
}