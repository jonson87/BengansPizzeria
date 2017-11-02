﻿using System;
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
            _repository.CreateMember(member);
        }

        public void RegisterMatch(Party player1, Party player2)
        {
            var match = new Match()
            {
                PlayerOne = player1,
                PlayerTwo = player2
            };
            _repository.CreateMatch(match);
        }     

        public void RegisterCompetition(string name, TimePeriod period, List<Match> matches)
        {
            var competition = new Competition()
            {
                Name = name,
                Period = period,
                Matches = matches
            };

            _repository.CreateCompetition(competition);
        }

        //Should use the lists/dbsets in _repository
        public Match PlayMatch(Match match)
        {
            List<Round> rounds = new List<Round>();
            int playerOneWonRounds = 0;

            if (match.Rounds != null && match.Rounds.Count != 0)
            {
                rounds = match.Rounds;
            }

            else
            {
                for (int i = 1; i <= 3; i++)
                {
                    var round = GetRound();
                    round.SerieOne = new Serie { Score = GetSerieScore() };
                    round.SerieTwo = new Serie { Score = GetSerieScore() };

                    rounds.Add(round);
                    if (round.SerieOne.Score > round.SerieTwo.Score)
                        playerOneWonRounds++;
                }
            }

            foreach (var round in rounds)
            {
                if (round.SerieOne.Score > round.SerieTwo.Score)
                    playerOneWonRounds++;
            }

            if (playerOneWonRounds > 1)
                match.Winner = match.PlayerOne;
            else
                match.Winner = match.PlayerTwo;

            return match;
        }

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

        public Round GetRound()
        {
            return new Round();
        }

        public int GetSerieScore()
        {
            Random random = new Random();
            var score = random.Next(50, 300);
            return score;
        }
    }
}