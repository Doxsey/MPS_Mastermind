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

    public static void PlayGame()
    {
      initialize();
      runMainGameLoop();
    }

    #region Private Methods

    private static void initialize()
    {
      gameData = new GameDataModel();
      gameData.SecretCode = SecretCodeOperations.CreateSecretCode();
      gameData.NumberOfGuessesRemaining = 12;
    }

    private static void runMainGameLoop()
    {
      for (int i = 0; i < 12; i++)
      {
        gameData.UserGuess = UserInputOperations.GetUserGuess(gameData);
        var guessResult = ProcessUserGuessController.ProcessUserGuess(gameData);

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
