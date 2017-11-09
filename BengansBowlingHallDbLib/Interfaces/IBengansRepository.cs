using System.Collections.Generic;
using AccountabilityLib;
using MeasurementLib;

namespace BengansBowlingHallDbLib.Interfaces
{
    public interface IBengansRepository
    {
        int CreateMember(string legalId, string name);
        Party GetParty(int id);
        List<Party> GetAllParties();

        int CreateMatch(List<Round> rounds, Lane lane, Party winner = null);
        Match GetMatch(int id);
        List<Match> GetAllMatches();

        int CreateSerie(Party player, int score = 0);
        Serie GetSerie(int id);
        List<Serie> GetAllSeries();

        int CreateRound(Serie serieOne, Serie serieTwo);
        Round GetRound(int id);
        List<Round> GetAllRounds();

        int CreateCompetition(string name, TimePeriod period, List<Match> matches);
        Competition GetCompetition(int id);
        List<Competition> GetAllCompetitions();

        int CreateLane(int laneNumber);
        Lane GetLane(int id);
        List<Lane> GetAllLanes();
    }
}
