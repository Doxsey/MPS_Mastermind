using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS_Mastermind.Models
{
  public class GameDataModel
  {
    public int[] SecretCode { get; set; }
    public int[] UserGuess { get; set; }
    public int NumberOfGuessesRemaining { get; set; }
  }
}
