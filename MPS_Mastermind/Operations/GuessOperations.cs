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
    public static bool CheckForWinningGuess(GameDataModel gameData)
    {
      return Enumerable.SequenceEqual(gameData.SecretCode, gameData.UserGuess);
    }

    public static void CheckForPluses(GameDataModel gameData, GuessResultModel guessResult)
    {
      int arrayIndex = 0;

      foreach (var userGuessDigit in gameData.UserGuess)
      {
        if (userGuessDigit == gameData.SecretCode[arrayIndex])
        {
          guessResult.NumberOfPluses++;
          guessResult.PositionMatchMask[arrayIndex] = 1;
        }
        arrayIndex++;
      }
    }

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

    private static List<int> getRemainingNonMatchedNumbers(int[] codeArray, GuessResultModel guessResult)
    {
      var remainingNonMatchedNumbers = new List<int>();

      int arrayIndex = 0;

      foreach (var codeDigit in codeArray)
      {
        if (guessResult.PositionMatchMask[arrayIndex] == 0)
        {
          remainingNonMatchedNumbers.Add(codeArray[arrayIndex]);
        }

        arrayIndex++;
      }

      return remainingNonMatchedNumbers;
    }

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
