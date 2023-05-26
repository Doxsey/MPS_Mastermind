using MPS_Mastermind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MPS_Mastermind.Operations
{
  public static class UserInputOperations
  {
    private static string rawUserInput;
    private static int[] userGuess;

    public static int[] GetUserGuess(GameDataModel gameData)
    {
      getRawUserInput(gameData.NumberOfGuessesRemaining);
      checkUserInput();
      parseUserGuess();

      return userGuess;
    }

    #region Private Methods

    private static void getRawUserInput(int guessesRemaining)
    {
      Console.WriteLine($"Please enter your guess ({guessesRemaining} Attempts Remaining):");
      rawUserInput = Console.ReadLine();
    }

    private static void checkUserInput()
    {
      var errorFlag = false;

      //Retry loop if error in user input. Max of i tries
      for (int i = 0; i < 5; i++)
      {
        if (rawUserInput.Length != 4 || Regex.Matches(rawUserInput, @"\D").Count > 0)
        {
          errorFlag = true;
          Console.WriteLine("Error in Input. Please enter a 4 digit guess:");
          rawUserInput = Console.ReadLine();
        }
        else
        {
          errorFlag = false;
          break;
        }
      }

      if (errorFlag)
      {
        throw new Exception("Error in user input after 5 attempts.");
      }
    }

    private static void parseUserGuess()
    {
      var arrayIndex = 0;
      userGuess = new int[4];

      foreach (var userNumber in rawUserInput)
      {
        userGuess[arrayIndex] = userNumber - '0';
        arrayIndex++;
      }

    }

    #endregion

  }
}
