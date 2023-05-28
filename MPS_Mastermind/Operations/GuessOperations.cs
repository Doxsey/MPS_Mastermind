using MPS_Mastermind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS_Mastermind.Operations
{
  public static class GuessOperations
  {
    /// <summary>
    /// Checks if user guess is a winner. Returns true for winner.
    /// </summary>
    /// <param name="gameData"></param>
    /// <returns></returns>
    public static bool CheckForWinningGuess(GameDataModel gameData)
    {
      return Enumerable.SequenceEqual(gameData.SecretCode, gameData.UserGuess);
    }

    /// <summary>
    /// Analyzes the user guess for the appropriate number of pluses to assign and sets the number in the active GuessResultModel.
    /// </summary>
    /// <param name="gameData"></param>
    /// <param name="guessResult"></param>
    public static void CheckForPluses(GameDataModel gameData, GuessResultModel guessResult)
    {
      int arrayIndex = 0;

      foreach (var userGuessDigit in gameData.UserGuess)
      {
        if (userGuessDigit == gameData.SecretCode[arrayIndex])
        {
          guessResult.NumberOfPluses++;
          guessResult.GuessPositionMask[arrayIndex] = 1;
        }
        arrayIndex++;
      }
    }

    /// <summary>
    /// Analyzes the user guess for the appropriate number of minuses to assign and sets the number in the active GuessResultModel.
    /// </summary>
    /// <param name="gameData"></param>
    /// <param name="guessResult"></param>
    public static void CheckForMinuses(GameDataModel gameData, GuessResultModel guessResult)
    {
      List<int> remainingNonMatchedNumbersFromSecretCode = getRemainingNonMatchedNumbers(gameData.SecretCode, guessResult);
      List<int> remainingNonMatchedNumbersFromUserGuess = getRemainingNonMatchedNumbers(gameData.UserGuess, guessResult);

      foreach (var userGuessDigit in remainingNonMatchedNumbersFromUserGuess)
      {
        if (remainingNonMatchedNumbersFromSecretCode.Contains(userGuessDigit))
        {
          guessResult.NumberOfMinuses++;
          remainingNonMatchedNumbersFromSecretCode.Remove(userGuessDigit);
        }
      }

    }

    /// <summary>
    /// Returns a list of eligible numbers to be matched. Uses a mask array to determine eligibility.
    /// </summary>
    /// <param name="codeArray"></param>
    /// <param name="guessResult"></param>
    /// <returns></returns>
    private static List<int> getRemainingNonMatchedNumbers(int[] codeArray, GuessResultModel guessResult)
    {
      var remainingNonMatchedNumbers = new List<int>();

      int arrayIndex = 0;

      foreach (var codeDigit in codeArray)
      {
        if (guessResult.GuessPositionMask[arrayIndex] == 0)
        {
          remainingNonMatchedNumbers.Add(codeArray[arrayIndex]);
        }

        arrayIndex++;
      }

      return remainingNonMatchedNumbers;
    }

    /// <summary>
    /// Translates the integer number of pluses and minuses to a display string
    /// </summary>
    /// <param name="guessResult"></param>
    /// <returns></returns>
    public static string GetPlusAndMinusString(GuessResultModel guessResult)
    {
      var displayString = "";

      for (int i = 0; i < guessResult.NumberOfPluses; i++)
      {
        displayString = displayString + "+";
      }

      for (int i = 0; i < guessResult.NumberOfMinuses; i++)
      {
        displayString = displayString + "-";
      }

      return displayString;
    }

  }
}
