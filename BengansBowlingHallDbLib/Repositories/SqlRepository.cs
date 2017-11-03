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
        public void CreateCompetition(string name, TimePeriod period, List<Match> matches)
        {
            var competition = new Competition()
            {
                Name = name,
                Period = period,
                Matches = matches
            };
            _context.Competitions.Add(competition);
            _context.SaveChanges();
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

        public void CreateMember(string legalId, string name)
        {
            var party = new Party { Name = name, LegalId = legalId };

            _context.Parties.Add(party);
            _context.SaveChanges();
        }

        public Round CreateRound(Serie serieOne, Serie serieTwo)
        {
            throw new NotImplementedException();
        }

        public Serie CreateSerie(int score)
        {
            throw new NotImplementedException();

        }

        public void CreateMatch(Party player1, Party player2)
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
    }
}
