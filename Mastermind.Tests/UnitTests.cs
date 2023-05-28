using MPS_Mastermind.Models;
using MPS_Mastermind.Operations;
using NUnit.Framework;
using System;
using System.Linq;

namespace Mastermind.Tests
{
  public class Tests
  {
    #region User Input Validation Tests

    [Test]
    [TestCase("2222")]
    [TestCase("5555")]
    [TestCase("2345")]
    [TestCase("5432")]
    public void CheckIfValidInput_WithValidInput_ShouldReturnTrue(string testInput)
    {
      Assert.That(UserInputOperations.CheckIfValidInput(testInput), Is.True);
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
      Assert.That(UserInputOperations.CheckIfValidInput(testInput), Is.False);
    }

    #endregion

    #region User Guess Analysis Tests

    [Test]
    [TestCase(2222, 2222, 4)]
    [TestCase(2345, 2435, 2)]
    [TestCase(2345, 5432, 0)]
    [TestCase(3322, 2233, 0)]
    [TestCase(5432, 4325, 0)]
    [TestCase(3232, 2223, 1)]
    public void CheckForPluses_WithTestData_ShouldReturnCorrectNumberOfPluses(int secretCode, int userGuess, int expectedNumberOfPluses)
    {
      var testGameData = generateTestGameData(secretCode, userGuess);
      var testGuessResult = new GuessResultModel();

      GuessOperations.CheckForPluses(testGameData, testGuessResult);

      Assert.That(testGuessResult.NumberOfPluses, Is.EqualTo(expectedNumberOfPluses));

    }

    [Test]
    [TestCase(2222, 2222, new int[] { 1, 1, 1, 1 }, 0)]
    [TestCase(2233, 2323, new int[] { 1, 0, 0, 1 }, 2)]
    [TestCase(5432, 2345, new int[] { 0, 0, 0, 0 }, 4)]
    [TestCase(3232, 2223, new int[] { 0, 1, 0, 0 }, 2)]

    public void CheckForMinuses_WithTestData_ShouldReturnCorrectNumberOfMinuses(int secretCode, int userGuess, int[] matchMask, int expectedNumberOfMinuses)
    {
      var testGameData = generateTestGameData(secretCode, userGuess);
      var testGuessResult = new GuessResultModel();

      testGuessResult.GuessPositionMask = matchMask;

      GuessOperations.CheckForMinuses(testGameData, testGuessResult);

      Assert.That(testGuessResult.NumberOfMinuses, Is.EqualTo(expectedNumberOfMinuses));

    }

    [Test]
    [TestCase(3232, 2223, "+--")]
    [TestCase(2345, 3245, "++--")]
    [TestCase(5443, 4423, "++-")]
    [TestCase(5444, 2332, "")]
    [TestCase(5432, 2345, "----")]
    [TestCase(5432, 5433, "+++")]
    [TestCase(2345, 3245, "++--")]
    public void GetPlusAndMinusString_WithTestData_ShouldReturnCorrectResponse(int secretCode, int userGuess, string expectedResponseString)
    {
      var testGameData = generateTestGameData(secretCode, userGuess);
      var testGuessResult = new GuessResultModel();
      GuessOperations.CheckForPluses(testGameData, testGuessResult);
      GuessOperations.CheckForMinuses(testGameData, testGuessResult);

      var resultString = GuessOperations.GetPlusAndMinusString(testGuessResult);

      Assert.That(resultString, Is.EqualTo(expectedResponseString));
    }

    #endregion

    #region Misc Unit Tests

    [Test]
    public void CreateSecretCode_WhenRandomlyCreated_ShouldBeValid()
    {
      var secretCode = SecretCodeOperations.CreateSecretCode();

      foreach (var secretDigit in secretCode)
      {
        Assert.That(secretDigit, Is.LessThan(6));
        Assert.That(secretDigit, Is.GreaterThan(1));
      }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Creates a GameDataModel for testing. The secretCode and userGuess is converted in an int[] to use in the model.
    /// </summary>
    /// <param name="secretCode"></param>
    /// <param name="userGuess"></param>
    /// <returns></returns>
    private GameDataModel generateTestGameData(int secretCode, int userGuess)
    {
      var gameData = new GameDataModel();

      gameData.SecretCode = secretCode.ToString().Select(o => Convert.ToInt32(o) - 48).ToArray();
      gameData.UserGuess = userGuess.ToString().Select(o => Convert.ToInt32(o) - 48).ToArray();

      return gameData;
    }

    #endregion

  }
}