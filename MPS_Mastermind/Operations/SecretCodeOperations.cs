using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS_Mastermind.Operations
{
  public static class SecretCodeOperations
  {
    /// <summary>
    /// Generates a new random secret code.
    /// </summary>
    /// <returns></returns>
    public static int[] CreateSecretCode()
    {
      var rand = new Random();
      var secretCode = new int[4];

      for (int i = 0; i < 4; i++)
      {
        secretCode[i] = rand.Next(2, 6);
      }

      return secretCode;
    }

  }
}
