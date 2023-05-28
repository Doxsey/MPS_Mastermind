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
    /// <summary>
    /// Gets raw user input as a string.
    /// </summary>
    /// <param name="guessesRemaining"></param>
    /// <returns></returns>
    public static string GetRawUserInput(int guessesRemaining)
    {
      Console.WriteLine($"Please enter your guess ({guessesRemaining} Attempts Remaining):");
      return Console.ReadLine();
    }

    /// <summary>
    /// Validates user input. User has limited attempts at a correct guess.
    /// </summary>
    /// <param name="rawUserInput"></param>
    public static void ValidateUserInput(string rawUserInput)
    {
      var errorFlag = false;

      //Retry loop if error in user input. Max of i tries
      for (int i = 0; i < 5; i++)
      {
        if (CheckIfValidInput(rawUserInput))
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

    /// <summary>
    /// Checks that all characters are digits and between 1 and 6. Returns true if valid, false if invalid.
    /// </summary>
    /// <param name="userInput"></param>
    /// <returns></returns>
    public static bool CheckIfValidInput(string userInput)
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

    /// <summary>
    /// Parses user guess from a string to in int array
    /// </summary>
    /// <param name="rawUserInput"></param>
    /// <returns></returns>
    public static int[] ParseUserGuess(string rawUserInput)
    {
      var arrayIndex = 0;
      var userGuess = new int[4];

      foreach (var userNumber in rawUserInput)
      {
        userGuess[arrayIndex] = userNumber - '0';
        arrayIndex++;
      }

      return userGuess;
    }

  }
}
