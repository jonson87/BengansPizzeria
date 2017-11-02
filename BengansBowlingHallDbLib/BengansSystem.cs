using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountabilityLib;

namespace BengansBowlingHallDbLib
{
    public class BengansSystem
    {
        //TODO Byt ut kontruktörparametrarna så att den tar in repositories för varje enhet. T.ex. PartiesRepository och MatchesRepository
        //TODO Fixa samtliga metoder nedan.

        public BengansSystem()
        {

        }

        public void RegisterMember(Party member)
        {
            //Parties.Add(party);
        }

        public void RegisterMatch(Match match)
        {
            //Matches.Add(match);
        }

        public void RegisterSerie(int id, int score)
        {
            //var serie = new Serie {Score = score};
            //Series.Add(serie);
            //_context.SaveChanges();
        }

        public void RegisterRound(int id,Serie serieOne, Serie serieTwo)
        {
            //var round = new Round {SerieOne = serieOne, SerieTwo = serieTwo};
            //Rounds.Add(round);
            //_context.SaveChanges();
        }

        public void RegisterCompetition(Competition competition)
        {
            //_context.Competitions.Add(competition);
            //_context.SaveChanges();
        }

        public void PlayMatch(int matchId)
        {
            //var match = Matches.Single(x => x.Id == matchId);
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
            //        series.Add(new Serie { Id = i, Score = i+100 });
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
    }
}
