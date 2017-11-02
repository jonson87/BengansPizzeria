using System;
using System.Collections.Generic;
using System.Text;
using AccountabilityLib;
using BengansBowlingHallDbLib.Interfaces;

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

        public void CreateMatch(Party player1, Party player2)
        {
            var match = new Match {PlayerOne = player1, PlayerTwo = player2};
            _context.Matches.Add(match);
            _context.SaveChanges();
        }

        public void CreateMember(string legalId, string name)
        {
            var party = new Party { Name = name, LegalId = legalId };

            _context.Parties.Add(party);
            _context.SaveChanges();
        }

        public void CreateRound(Round round)
        {
            throw new NotImplementedException();
        }

        public void CreateSerie(Serie serie)
        {
            throw new NotImplementedException();
        }
    }
}
