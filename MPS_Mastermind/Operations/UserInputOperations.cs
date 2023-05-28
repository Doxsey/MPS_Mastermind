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
      validateUserInput();
      parseUserGuess();

      return userGuess;
    }

    private static void getRawUserInput(int guessesRemaining)
    {
      Console.WriteLine($"Please enter your guess ({guessesRemaining} Attempts Remaining):");
      rawUserInput = Console.ReadLine();
    }

    private static void validateUserInput()
    {
      var errorFlag = false;

      //Retry loop if error in user input. Max of i tries
      for (int i = 0; i < 5; i++)
      {
        if (checkIfValidInput(rawUserInput))
        {
          errorFlag = false;
          break;
        }
        else
        {
          errorFlag = true;
          Console.WriteLine("Error in Input. Please re-enter guess:");
          rawUserInput = Console.ReadLine();
        }
      }

      if (errorFlag)
      {
        throw new Exception("Error in user input after 5 attempts.");
      }
    }

    public static bool checkIfValidInput(string userInput)
    {
      var validInputFlag = true;

      if (userInput.Length != 4 || Regex.Matches(userInput, @"\D").Count > 0)
      {
        validInputFlag = false;
      }
      if (Regex.Matches(userInput, @"[0-1]|[6-9]").Count > 0)
      {
        validInputFlag = false;
      }

      return validInputFlag;
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

  }
}
