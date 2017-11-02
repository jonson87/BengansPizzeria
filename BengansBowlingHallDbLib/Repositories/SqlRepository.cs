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
        public void CreateCompetition(Competition competition)
        {
            throw new NotImplementedException();
        }

        public void CreateMatch(Match match)
        {
            throw new NotImplementedException();
        }

        public void CreateMember(Party member)
        {
            throw new NotImplementedException();
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
