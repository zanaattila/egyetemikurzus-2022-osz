namespace EnumerableUtilities;

public record Asset(Category Category, string Name);

public record Computer(string Name) : Asset(Category.Computers, Name);

public record Vehicle(string Name) : Asset(Category.Vehicles, Name);