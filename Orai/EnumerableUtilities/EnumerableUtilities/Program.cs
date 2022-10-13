using EnumerableUtilities;
using EnumerableUtilities.AllInOne;
using EnumerableUtilities.UsingDelegates;

#region Testing the removal of odd values

var numbers = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

ConsoleWriter.WriteLine
(
    numbers.RemoveAllOddValues()
);
ConsoleWriter.WriteLine
(
    numbers.Filter(number => number % 2 == 0)
);
ConsoleWriter.WriteLine();

#endregion

#region Testing the removal of whitespaces

const string text = "H e l l o  W o r l d";

ConsoleWriter.WriteLine
(
    text.RemoveAllWhitespaces()
);
ConsoleWriter.WriteLine
(
    text.Filter(currentChar => !char.IsWhiteSpace(currentChar))
);
ConsoleWriter.WriteLine();

#endregion

#region Testing the extraction of categories

var assets = new Asset[]
{
    new Computer("Apple MacBook Air"),
    new Vehicle("Ford Focus Active")
};

ConsoleWriter.WriteLine
(
    assets.GetAllCategories()
);
ConsoleWriter.WriteLine
(
    assets.Transform(asset => asset.Category)
);
ConsoleWriter.WriteLine();

#endregion