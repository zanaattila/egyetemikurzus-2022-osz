namespace TestFramework.Framework;

public static class Assert
{
    public static void Pass(string message)
    {
        Console.WriteLine($"[PASSED] {message}");
    }

    public static void Fail(string message)
    {
        Console.WriteLine($"[FAILED] {message}");
    }

    public static void IsTrue(bool condition)
    {
        AreEqual(true, condition);
    }

    public static void IsFalse(bool condition)
    {
        AreEqual(false, condition);
    }

    public static void AreEqual(bool expected, bool actual)
    {
        if (actual == expected)
        {
            Pass($"it is {expected} as expected");
        }
        else
        {
            Fail($"it should be {expected}, but it is {actual}");
        }
    }

    public static void AreEqual(object expected, object actual)
    {
        if (Equals(actual, expected))
        {
            Pass($"it is equal to {expected} as expected");
        }
        else
        {
            Fail($"it should be equal to {expected}, but it is {actual}");
        }
    }

    public static void Throws<T>(Action code) where T : Exception
    {
        // Attempts to invoke the code snippet, represented as a delegate,
        // in order to verify that it throws the specified exception
        try
        {
            code();
            Fail($"it should throw {typeof(T)}, but it throws nothing");
        }
        catch (T)
        {
            Pass($"it throws {typeof(T)} as expected");
        }
        catch (Exception e)
        {
            Fail($"it should throw {typeof(T)}, but it throws {e.GetType()}");
        }
    }
}