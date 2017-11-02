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
        public void PlayMatch(Match match)
        {
            //var rounds = new List<Round>(3);
            //int playerOneWonRounds = 0;

            //for (int i = Rounds.Count; i <= Rounds.Count + 3; i++)
            //{
            //    rounds.Add(new Round { Id = i });
            //}

            //Rounds.AddRange(rounds);

            //foreach (var round in rounds)
            //{
            //    var series = new List<Serie>(2);

            //    for (int i = Series.Count + 1; i <= Series.Count + 2; i++)
            //    {
            //        series.Add(new Serie { Id = i, Score = i + 100 });
            //    }

            //    round.SerieOne = series[0];
            //    round.SerieTwo = series[1];

            //    if (series[0].Score > series[1].Score)
            //    {
            //        playerOneWonRounds++;
            //    }

            //    Series.AddRange(series);
            //}

            //match.Rounds = rounds;

            //match.Winner = playerOneWonRounds > 1 ? match.PlayerOne : match.PlayerTwo;

            //return match;
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
    }
}
