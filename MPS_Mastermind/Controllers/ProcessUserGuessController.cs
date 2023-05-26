using MPS_Mastermind.Models;
using MPS_Mastermind.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS_Mastermind.Controllers
{
  public class ProcessUserGuessController
  {

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

      //TODO: handle if after this guess the game ends
    }

  }

}
