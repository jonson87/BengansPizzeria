using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountabilityLib;
using BengansBowlingHallDbLib.Interfaces;

namespace BengansBowlingHallDbLib
{
    public class BengansSystem
    {
        //TODO Byt ut kontruktörparametrarna så att den tar in repositories för varje enhet. T.ex. PartiesRepository och MatchesRepository
        //TODO Fixa samtliga metoder nedan.

        private IBengansRepository _repository; 

        public BengansSystem(IBengansRepository repository)
        {
            _repository = repository;
        }

        public void RegisterMember(string legalId, string name)
        {
            var member = new Party()
            {
                Name = name,
                LegalId = legalId
            };
            _repository.CreateMember(legalId, name);
        }

        public void RegisterMatch(Party player1, Party player2)
        {
           _repository.CreateMatch(player1, player2);
        }     

        public void RegisterCompetition(string name, TimePeriod period, List<Match> matches)
        {
            

            _repository.CreateCompetition(name, period, matches);
        }

        //Should use the lists/dbsets in _repository
        //public Match PlayMatch(Match match)
        //{
        //    List<Round> rounds = new List<Round>();

        //    if (match.Rounds != null && match.Rounds.Count != 0)
        //    {
        //        rounds = match.Rounds;

        //        match.Rounds = new List<Round>();
        //    }

        //    else
        //    {
        //        for (int i = 1; i <= 3; i++)
        //        {
        //            var round = new Round();
        //            round.SerieOne = new Serie { Score = GetSerieScore() };
        //            round.SerieTwo = new Serie { Score = GetSerieScore() };

        //            rounds.Add(round);
        //        }
        //    }

        //    match.Winner = GetMatchWinner(match);

        //    return match;
        //}

        public void RegisterRound(int id, Serie serieOne, Serie serieTwo)
        {
            //var round = new Round {SerieOne = serieOne, SerieTwo = serieTwo};
            //Rounds.Add(round);
            //_context.SaveChanges();
        }

        public void RegisterSerie(int id, int score)
        {
            //var serie = new Serie {Score = score};
            //Series.Add(serie);
            //_context.SaveChanges();
        }

        public Party GetMatchWinner(Match match)
        {
            int playerOneWonRounds = 0;
            foreach (var round in match.Rounds)
            {
                if (round.SerieOne.Score > round.SerieTwo.Score)
                    playerOneWonRounds++;
            }

            if (playerOneWonRounds > 1)
            {
                return match.PlayerOne;
            }

            return match.PlayerTwo;
        }

        public int GetSerieScore()
        {
            Random random = new Random();
            var score = random.Next(50, 300);
            return score;
        }
    }
}
