using TestFramework.Framework;

namespace TestFramework;

// In this class, we can implement as many test methods as we need,
// their invocation is handled by the base class
internal class StringTests : Test
{
    public void OrdinaryMethod()
    {
        Console.WriteLine("This should not be invoked by the unit test framework");
    }

    // Each test method is a test case, which consists of the
    // following three steps:
    //   1. Arrange - set up the data and conditions required for testing
    //   2. Act - perform the operations whose effects are tested
    //   3. Assert - verify that the expectations have been met

    [Test]
    public void Contains_ValueIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        const string testee = "Whatever";

        // Act, Assert
        Assert.Throws<ArgumentNullException>(() => testee.Contains(null));
    }

    [Test]
    public void Contains_ValueOccursWithinString_ReturnsTrue()
    {
        // Arrange
        const string testee = "Hello, World!";

        // Act
        var result = testee.Contains("World"); 

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void Contains_ValueDoesNotOccurWithinString_ReturnsFalse()
    {
        // Arrange
        const string testee = "Hello, World!";

        // Act
        var result = testee.Contains("Whatever");

        // Assert
        Assert.IsFalse(result);
    }


    [Test]
    public void Length_StringIsEmpty_ReturnsZero()
    {
        // Arrange
        const string testee = "";

        // Act
        var result = testee.Length;

        // Assert
        Assert.AreEqual(0, result);
    }

    [Test]
    public void Length_StringIsNotEmpty_ReturnsTheNumberOfCharacters()
    {
        // Arrange
        const string testee = "Whatever";

        // Act
        var result = testee.Length;

        // Assert
        Assert.AreEqual(8, result);
    }
}