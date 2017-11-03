using System.Collections.Generic;
using AccountabilityLib;

namespace BengansBowlingHallDbLib.Interfaces
{
    public interface IBengansRepository
    {
        void CreateMember(string legalId, string name);
        List<Party> GetAllParties();

        void CreateMatch(Party player1, Party player2);
        List<Match> GetAllMatches();

        Serie CreateSerie(int score, Party player);
        List<Serie> GetAllSeries();

        void CreateRound(Round round);
        List<Round> GetAllRounds();

        void CreateCompetition(string name, TimePeriod period, List<Match> matches);
        List<Competition> GetAllCompetitions();
    }
}
