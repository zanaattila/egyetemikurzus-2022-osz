using System.Reflection;

namespace TestFramework.Framework;

internal abstract class Test
{
    // Here we provide the possibility to invoke all test methods
    // without knowing how many of them are implemented
    public void RunAllTests()
    {
        foreach (var test in GetAllTests())
        {
            Console.WriteLine($"Running {test.Name}...");

            test.Invoke(this, Array.Empty<object>());

            Console.WriteLine();
        }
    }

    // Here we define what is considered a test method. Currently,
    // the methods that have the Test attribute are test methods,
    // but they could also be the methods whose name starts with
    // "Test" or something like that
    private IEnumerable<MethodInfo> GetAllTests()
    {
        var publicMethods = GetType().GetMethods();

        return publicMethods.Where(HasTestAttribute);
    }

    private static bool HasTestAttribute(MethodInfo method)
    {
        return method.IsDefined(typeof(TestAttribute));
    }
}