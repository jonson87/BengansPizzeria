using AccountabilityLib;

namespace BengansBowlingHallDbLib
{
    public class Serie
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int Score { get; set; }

        public Party Player { get; set; }
    }
}