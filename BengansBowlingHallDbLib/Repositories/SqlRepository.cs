using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountabilityLib;
using BengansBowlingHallDbLib.Interfaces;
using BengansBowlingHallDbLib.Data;

namespace BengansBowlingHallDbLib
{
    public class SqlRepository : IBengansRepository
    {
        private BengansBowlingHallDbContext _context;
        public SqlRepository(BengansBowlingHallDbContext context)
        {
            _context = context;
        }
        public int CreateCompetition(string name, TimePeriod period, List<Match> matches)
        {
            var competition = new Competition()
            {
                Name = name,
                Period = period,
                Matches = matches
            };
            _context.Competitions.Add(competition);
            _context.SaveChanges();
            return competition.Id;
        }

        public List<Party> GetPlayers()
        {
            return _context.Parties.ToList();
        }

        //public void CreateMatch(Party player1, Party player2)
        //{
        //    var match = new Match {PlayerOne = player1, PlayerTwo = player2};
        //    _context.Matches.Add(match);
        //    _context.SaveChanges();
        //}

        public int CreateMember(string legalId, string name)
        {
            var party = new Party { Name = name, LegalId = legalId };

            _context.Parties.Add(party);
            _context.SaveChanges();
            return party.Id;
        }

        public int CreateRound(Serie serieOne, Serie serieTwo)
        {
            var round = new Round {PlayerOneSerie = serieOne, PlayerTwoSerie = serieTwo};
            _context.Rounds.Add(round);
            _context.SaveChanges();
            return round.Id;
        }

        public int CreateSerie(int score, Party player)
        {
            var serie = new Serie {Player = player, Score = score};
            _context.Series.Add(serie);
            _context.SaveChanges();
            return serie.Id;
        }

        public int CreateMatch(Party player1, Party player2)
        {
            throw new NotImplementedException();
        }

        public List<Party> GetAllParties()
        {
            throw new NotImplementedException();
        }

        public List<Match> GetAllMatches()
        {
            throw new NotImplementedException();
        }

        public List<Serie> GetAllSeries()
        {
            throw new NotImplementedException();
        }

        public List<Round> GetAllRounds()
        {
            throw new NotImplementedException();
        }

        public List<Competition> GetAllCompetitions()
        {
            throw new NotImplementedException();
        }

        public Party GetParty(int id)
        {
            throw new NotImplementedException();
        }

        public Match GetMatch(int id)
        {
            throw new NotImplementedException();
        }

        public Serie GetSerie(int id)
        {
            throw new NotImplementedException();
        }

        public Round GetRound(int id)
        {
            throw new NotImplementedException();
        }

        public Competition GetCompetition(int id)
        {
            throw new NotImplementedException();
        }
    }
}
