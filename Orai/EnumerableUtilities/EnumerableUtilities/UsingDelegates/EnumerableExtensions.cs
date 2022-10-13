namespace EnumerableUtilities.UsingDelegates;

// Although these methods provide only the basics of enumerable manipulation,
// they are fully reusable and do not introduce unwanted dependencies
internal static class EnumerableExtensions
{
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
    {
        foreach (var item in enumerable)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<T2> Transform<T1, T2>(this IEnumerable<T1> enumerable, Func<T1, T2> transform)
    {
        foreach (var item in enumerable)
        {
            yield return transform(item);
        }
    }
}