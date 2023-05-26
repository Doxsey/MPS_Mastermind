using MPS_Mastermind.Operations;
using NUnit.Framework;

namespace Mastermind.Tests
{
  public class Tests
  {
    [Test]
    [TestCase("2222")]
    [TestCase("5555")]
    [TestCase("2345")]
    [TestCase("5432")]
    public void CheckIfValidInput_WithValidInput_ShouldReturnTrue(string testInput)
    {
      Assert.That(UserInputOperations.checkIfValidInput(testInput), Is.True);
    }

    [Test]
    [TestCase("1234")]
    [TestCase("0123")]
    [TestCase("3456")]
    [TestCase("345")]
    [TestCase("a333")]
    [TestCase("33445")]
    [TestCase("")]
    [TestCase("four")]
    [TestCase(".445")]
    public void CheckIfValidInput_WithInvalidInput_ShouldReturnFalse(string testInput)
    {
      Assert.That(UserInputOperations.checkIfValidInput(testInput), Is.False);
    }
  }
}