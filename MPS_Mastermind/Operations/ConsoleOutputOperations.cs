using MPS_Mastermind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS_Mastermind.Operations
{
  public static class ConsoleOutputOperations
  {
    public static void DisplayVictory()
    {
      Console.WriteLine("You solved it!");
      Environment.Exit(0);
    }

    public static void DisplayLoss(GameDataModel gameData)
    {
      Console.WriteLine("You lose :(");
      Console.WriteLine($"The correct code is: {gameData.SecretCode[0]}{gameData.SecretCode[1]}{gameData.SecretCode[2]}{gameData.SecretCode[3]}");
      Environment.Exit(0);
    }

    public static void DisplayPlusesAndMinuses(GuessResultModel guessResult)
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

      Console.WriteLine(displayString);
    }

  }
}
