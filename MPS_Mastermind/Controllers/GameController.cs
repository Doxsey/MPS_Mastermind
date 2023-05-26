using MPS_Mastermind.Models;
using MPS_Mastermind.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS_Mastermind.Controllers
{
  public class GameController
  {
    private static GameDataModel gameData;

    public static void PlayGame()
    {
      initialize();

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

      Console.WriteLine($"You should never see me");


    }

    #region Private Methods

    private static void initialize()
    {

      gameData = new GameDataModel();
      gameData.SecretCode = SecretCodeOperations.CreateSecretCode();
      //gameData.SecretCode = new int[] { 3, 2, 3, 2 };
      gameData.NumberOfGuessesRemaining = 12;

      //Console.WriteLine($"Secret Code: {gameData.SecretCode[0]}{gameData.SecretCode[1]}{gameData.SecretCode[2]}{gameData.SecretCode[3]}");
      //gameData.MatchingGuess = false;
    }

    #endregion

  }
}
