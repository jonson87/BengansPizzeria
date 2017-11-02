﻿using System;
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
            _context.Competitions.Add(competition);
            _context.SaveChanges();
        }

        public void CreateMatch(Match match)
        {
            _context.Matches.Add(match);
            _context.SaveChanges();
        }

        public void CreateMember(Party member)
        {
            _context.Parties.Add(member);
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