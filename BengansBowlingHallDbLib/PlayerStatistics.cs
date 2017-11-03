using System;
using System.Collections.Generic;
using System.Text;
using AccountabilityLib;

namespace BengansBowlingHallDbLib
{
    public class PlayerStatistics
    {
        public Party Player { get; set; }
        public int MatchesWon { get; set; }
        public int Matchesplayed { get; set; }

        public decimal WinPercent => MatchesWon / Matchesplayed;
    }
}
