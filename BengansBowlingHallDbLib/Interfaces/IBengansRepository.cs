using AccountabilityLib;

namespace BengansBowlingHallDbLib.Interfaces
{
    public interface IBengansRepository
    {
        void CreateMember(string legalId, string name);
        void CreateMatch(Match match);
        void CreateSerie(Serie serie);
        void CreateRound(Round round);
        void CreateCompetition(Competition competition);
    }
}
