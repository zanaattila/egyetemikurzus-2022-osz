namespace EnumerableUtilities;

public record Category(string Name)
{
    public static readonly Category Vehicles = new("Vehicles");

    public static readonly Category Computers = new("Computers");
}