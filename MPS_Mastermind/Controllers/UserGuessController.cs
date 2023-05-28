using MPS_Mastermind.Models;
using MPS_Mastermind.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS_Mastermind.Controllers
{
  public static class UserGuessController
  {
    /// <summary>
    /// Gets user guess from console
    /// </summary>
    /// <param name="gameData"></param>
    /// <returns></returns>
    public static int[] GetUserGuess(GameDataModel gameData)
    {
      var rawUserInput = UserInputOperations.GetRawUserInput(gameData.NumberOfGuessesRemaining);
      var validatedUserInput = UserInputOperations.ValidateUserInput(rawUserInput);
      var userGuess = UserInputOperations.ParseUserGuess(validatedUserInput);

      return userGuess;
    }

    /// <summary>
    /// Processes user guess for possible win/loss or plus/minus response.
    /// </summary>
    /// <param name="gameData"></param>
    /// <returns></returns>
    public static GuessResultModel ProcessUserGuess(GameDataModel gameData)
    {
      var guessResult = new GuessResultModel();

      if (GuessOperations.CheckForWinningGuess(gameData))
      {
        guessResult.WinningGuessFlag = true;

        return guessResult;
      }

      gameData.NumberOfGuessesRemaining--;

      if (gameData.NumberOfGuessesRemaining <= 0)
      {
        guessResult.LosingGuessFlag = true;

        return guessResult;
      }

      GuessOperations.CheckForPluses(gameData, guessResult);
      GuessOperations.CheckForMinuses(gameData, guessResult);

      return guessResult;
    }

  }

}
