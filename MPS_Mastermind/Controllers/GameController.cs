using MPS_Mastermind.Models;
using MPS_Mastermind.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS_Mastermind.Controllers
{
  public static class GameController
  {
    private static GameDataModel gameData;

    /// <summary>
    /// Starting point of a new game.
    /// </summary>
    public static void PlayGame()
    {
      initialize();
      runMainGameLoop();
    }

    #region Private Methods

    /// <summary>
    /// Initialize game data for a new game.
    /// </summary>
    private static void initialize()
    {
      gameData = new GameDataModel();
      gameData.SecretCode = SecretCodeOperations.CreateSecretCode();
      //gameData.SecretCode = new int[] { 4, 2, 2, 5 };
      gameData.NumberOfGuessesRemaining = 12;
    }

    /// <summary>
    /// Main game loop.
    /// </summary>
    private static void runMainGameLoop()
    {
      for (int i = 0; i < 12; i++)
      {
        gameData.UserGuess = UserGuessController.GetUserGuess(gameData);
        var guessResult = UserGuessController.ProcessUserGuess(gameData);

        if (guessResult.WinningGuessFlag)
        {
          ConsoleOutputOperations.DisplayVictory();
        }
        if (guessResult.LosingGuessFlag)
        {
          ConsoleOutputOperations.DisplayLoss(gameData);
        }

        ConsoleOutputOperations.DisplayPlusesAndMinuses(guessResult);

      }

      throw new Exception("Exception in the number of guesses");
    }

    #endregion

  }
}
