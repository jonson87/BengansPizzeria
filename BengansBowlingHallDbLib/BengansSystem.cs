using System;
using System.Collections.Generic;
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
       
        public void RegisterRound(int id, Serie serieOne, Serie serieTwo)
        {
            _repository.CreateRound(serieOne, serieTwo);
        }

        public void RegisterSerie(Party player, int score = 0)
        {
            _repository.CreateSerie(score, player);
        }

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
