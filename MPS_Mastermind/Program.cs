using MPS_Mastermind.Operations;
using System;

namespace MPS_Mastermind
{
  class Program
  {
    private static int guessCount;
    private static int[] secretCode;

    static void Main(string[] args)
    {
      initialize();
      var userGuess = UserInputOperations.GetUserGuess();

      Console.WriteLine("end");
    }

    private static void initialize()
    {
      secretCode = SecretCodeOperations.CreateSecretCode();
      guessCount = 0;
    }

  }
}
