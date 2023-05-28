using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS_Mastermind.Models
{
  public class GuessResultModel
  {
    public bool WinningGuessFlag { get; set; }
    public bool LosingGuessFlag { get; set; }
    public int NumberOfPluses { get; set; }
    public int NumberOfMinuses { get; set; }
    public int[] PositionMatchMask { get; set; }


    public GuessResultModel()
    {
      WinningGuessFlag = false;
      LosingGuessFlag = false;
      NumberOfPluses = 0;
      NumberOfMinuses = 0;
      PositionMatchMask = new int[] { 0, 0, 0, 0 };
    }

  }
}
