using System.Collections.Generic;
using AccountabilityLib;

namespace BengansBowlingHallDbLib.Interfaces
{
    public interface IBengansRepository
    {
        void CreateMember(string legalId, string name);
        void CreateMatch(Party player1, Party player2);
        Serie CreateSerie(int score);
        Round CreateRound(Serie serieOne, Serie serieTwo);
        void CreateCompetition(string name, TimePeriod period, List<Match> matches);
        List<Party> GetPlayers();
    }
}
