using AccountabilityLib;

namespace BengansBowlingHallDbLib
{
    public class Serie
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int RoundId { get; set; }
        public int Score { get; set; }

        public Party Player { get; set; }
        public Round Round { get; set; }
    }
}