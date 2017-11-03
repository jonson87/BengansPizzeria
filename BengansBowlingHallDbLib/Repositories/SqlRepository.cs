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

        public int CreateMatch(List<Round> rounds)
        {
            var match = new Match { Rounds = rounds};
            _context.Matches.Add(match);
            _context.SaveChanges();
            return match.Id;
        }

        public List<Party> GetAllParties()
        {
            return _context.Parties.ToList();
        }

        public List<Match> GetAllMatches()
        {
            return _context.Matches.ToList();
        }

        public List<Serie> GetAllSeries()
        {
            return _context.Series.ToList();
        }

        public List<Round> GetAllRounds()
        {
            return _context.Rounds.ToList();
        }

        public List<Competition> GetAllCompetitions()
        {
            return _context.Competitions.ToList();
        }

        public Party GetParty(int id)
        {
            var party = _context.Parties.FirstOrDefault(x => x.PartyId == id);
            return party;
        }

        public Match GetMatch(int id)
        {
            var match = _context.Matches.FirstOrDefault(x => x.Id == id);
            return match;
        }

        public Serie GetSerie(int id)
        {
            var serie = _context.Series.FirstOrDefault(x => x.Id == id);
            return serie;
        }

        public Round GetRound(int id)
        {
            var round = _context.Rounds.FirstOrDefault(x => x.Id == id);
            return round;
        }

        public Competition GetCompetition(int id)
        {
            var comp = _context.Competitions.FirstOrDefault(x => x.Id == id);
            return comp;
        }

        public int CreateSerie(Party player, int score = 0)
        {
            throw new NotImplementedException();
        }
    }
}
