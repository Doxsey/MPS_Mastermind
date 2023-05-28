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
    /// <summary>
    /// Prints to console for a solved puzzle
    /// </summary>
    public static void DisplayVictory()
    {
      Console.WriteLine("You solved it!");
      Environment.Exit(0);
    }

    /// <summary>
    /// Prints to console when a game is lost
    /// </summary>
    /// <param name="gameData"></param>
    public static void DisplayLoss(GameDataModel gameData)
    {
      Console.WriteLine("You lose :(");
      Console.WriteLine($"The correct code is: {gameData.SecretCode[0]}{gameData.SecretCode[1]}{gameData.SecretCode[2]}{gameData.SecretCode[3]}");
      Environment.Exit(0);
    }

    /// <summary>
    /// Prints the number of plus and minus signs to the console window
    /// </summary>
    /// <param name="guessResult"></param>
    public static void DisplayPlusesAndMinuses(GuessResultModel guessResult)
    {
      Console.WriteLine(GuessOperations.GetPlusAndMinusString(guessResult));
    }

  }
}
