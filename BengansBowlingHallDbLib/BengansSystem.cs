using System.Collections.Generic;
using AccountabilityLib;
using BengansBowlingHallDbLib.Interfaces;

namespace BengansBowlingHallDbLib
{
    public class BengansSystem
    {
        private IBengansRepository _repository; 

        public BengansSystem(IBengansRepository repository)
        {
            _repository = repository;
        }

        //Party management
        public int CreateMember(string legalId, string name)
        {
            return _repository.CreateMember(legalId, name);
        }

        public List<Party> GetAllParties()
        {
            return _repository.GetAllParties();
        }

        public Party GetParty(int id)
        {
            return _repository.GetParty(id);
        }

        //Match management
        public int CreateMatch(Party player1, Party player2)
        {
           return _repository.CreateMatch(player1, player2);
        }

        public List<Match> GetAllMatches()
        {
            return _repository.GetAllMatches();
        }

        public Match GetMatch(int id)
        {
            return _repository.GetMatch(id);
        }

        //Competition management
        public int CreateCompetition(string name, TimePeriod period, List<Match> matches)
        {
            return _repository.CreateCompetition(name, period, matches);
        }

        public List<Competition> GetAllCompetitions()
        {
            return _repository.GetAllCompetitions();
        }

        public Competition GetCompetition(int id)
        {
            return _repository.GetCompetition(id);
        }

        //Round management
        public int CreateRound(Serie serieOne, Serie serieTwo)
        {
            return _repository.CreateRound(serieOne, serieTwo);
        }

        public List<Round> GetAllRounds()
        {
            return _repository.GetAllRounds();
        }

        public Round GetRound(int id)
        {
            return _repository.GetRound(id);
        }

        //Serie management
        public int CreateSerie(Party player, int score = 0)
        {
            return _repository.CreateSerie(score, player);
        }

        public List<Serie> GetAllSeries()
        {
            return _repository.GetAllSeries();
        }

        public Serie GetSerie(int id)
        {
            return _repository.GetSerie(id);
        }

        //Get winner
        public Party GetMatchWinner(Match match)
        {
            int playerOneWonRounds = 0;

            foreach (var round in match.Rounds)
            {
                if (round.PlayerOneSerie.Score > round.PlayerTwoSerie.Score)
                    playerOneWonRounds++;
            }

            if (playerOneWonRounds > 1)
            {
                return match.Rounds[0].PlayerOneSerie.Player;
            }

            return match.Rounds[0].PlayerTwoSerie.Player;
        }
    }
}
