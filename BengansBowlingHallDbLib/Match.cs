using System.Collections.Generic;
using AccountabilityLib;

namespace BengansBowlingHallDbLib
{
    public class Match
    {
        public int Id { get; set; }
        public int WinnerId { get; set; }
        public int CompetitionId { get; set; }
        public int LaneId { get; set; }

        public Lane Lane { get; set; }
        public Party Winner { get; set; }
        public List<Round> Rounds { get; set; }
        public Competition Competition { get; set; }
    }
}
