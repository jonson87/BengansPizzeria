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

        void CreateSerie(Serie serie);
        List<Serie> GetAllSeries();

        void CreateRound(Round round);
        List<Round> GetAllRounds();

        Serie CreateSerie(int score);
        Round CreateRound(Serie serieOne, Serie serieTwo);
        void CreateCompetition(string name, TimePeriod period, List<Match> matches);
        List<Competition> GetAllCompetitions();
    }
}
