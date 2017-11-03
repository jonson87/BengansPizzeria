using System.Collections.Generic;
using AccountabilityLib;

namespace BengansBowlingHallDbLib.Interfaces
{
    public interface IBengansRepository
    {
        int CreateMember(string legalId, string name);
        Party GetParty(int id);
        List<Party> GetAllParties();

        int CreateMatch(Party player1, Party player2);
        Match GetMatch(int id);
        List<Match> GetAllMatches();

        int CreateSerie(int score, Party player);
        Serie GetSerie(int id);
        List<Serie> GetAllSeries();

        int CreateRound(Serie serieOne, Serie serieTwo);
        Round GetRound(int id);
        List<Round> GetAllRounds();

        int CreateCompetition(string name, TimePeriod period, List<Match> matches);
        Competition GetCompetition(int id);
        List<Competition> GetAllCompetitions();
    }
}
