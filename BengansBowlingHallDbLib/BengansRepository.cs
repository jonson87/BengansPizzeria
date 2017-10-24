using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountabilityInterfacesLib;
using AccountabilityLib;

namespace BengansBowlingHallDbLib
{
    public class BengansRepository: IBengansRepository
    {
        //private BengansBowlingHallDbContext _context;
        public List<Party> Parties;
        public List<Match> Matches;
        public List<Round> Rounds;
        public List<Serie> Series;

        public BengansRepository()
        {
            Parties = new List<Party>();
            Matches = new List<Match>();
            Rounds = new List<Round>();
            Series = new List<Serie>();
        }

        public Party RegisterMember(int id,string name, string legalId, string phone, string email)
        {
            var party = new Party { Name = name, LegalId = legalId, Email = email, Phone = phone };
            Parties.Add(party);
            //_context.SaveChanges();

            return party;
        }

        public Match RegisterMatch(int id, Party playerOne, Party playerTwo)
        {
            var match = new Match {Id = id, PlayerOne = playerOne, PlayerTwo = playerTwo};
            Matches.Add(match);
            //_context.SaveChanges();

            return match;
        }

        public Serie RegisterSerie(int id, int score)
        {
            var serie = new Serie {Score = score};
            Series.Add(serie);
            //_context.SaveChanges();

            return serie;
        }

        public Round RegisterRound(int id,Serie serieOne, Serie serieTwo)
        {
            var round = new Round {SerieOne = serieOne, SerieTwo = serieTwo};
            Rounds.Add(round);
            //_context.SaveChanges();

            return round;
        }

        public Competition RegisterCompetition(int id, string name, TimePeriod period)
        {
            var competition = new Competition {Id = id, Name = name, Period = period};
            return null;
        }

        public Match PlayMatch(int matchId)
        {
            var match = Matches.Single(x => x.Id == matchId);
            var rounds = new List<Round>(3);
            int playerOneWonRounds = 0;

            for (int i = Rounds.Count; i <= Rounds.Count + 3; i++)
            {
                rounds.Add(new Round { Id = i });
            }

            Rounds.AddRange(rounds);            

            Random r = new Random();

            foreach (var round in rounds)
            {
                var series = new List<Serie>(2);

                for (int i = Series.Count + 1; i <= Series.Count + 2; i++)
                {
                    //series.Add(new Serie { Id = i, Score = r.Next(80, 300) });
                    series.Add(new Serie { Id = i, Score = i+100 });
                }

                round.SerieOne = series[0];
                round.SerieTwo = series[1];

                if (series[0].Score > series[1].Score)
                {
                    playerOneWonRounds++;
                }

                Series.AddRange(series);
            }

            match.Rounds = rounds;

            match.Winner = playerOneWonRounds > 1 ? match.PlayerOne : match.PlayerTwo;

            return match;
        }

    }
}
