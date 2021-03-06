﻿using System.Collections.Generic;
using System.Linq;
using AccountabilityLib;
using BengansBowlingHallDbLib.Interfaces;
using BengansBowlingHallDbLib.Data;
using MeasurementLib;

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

        public int CreateSerie(Party player, int score)
        {
            var serie = new Serie {Player = player, Score = score};
            _context.Series.Add(serie);
            _context.SaveChanges();
            return serie.Id;
        }

        public int CreateMatch(List<Round> rounds,Lane lane, Party winner = null)
        {
            var match = new Match { Rounds = rounds, Lane = lane};

            if(winner != null)
            {
                match.Winner = winner;
                match.WinnerId = winner.Id;
            }

            _context.Matches.Add(match);
            _context.SaveChanges();
            return match.Id;
        }

        public int CreateLane(int laneNumber)
        {
            var lane = new Lane {LaneNumber = laneNumber};
            _context.Lanes.Add(lane);
            _context.SaveChanges();
            return lane.Id;
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

        public List<Lane> GetAllLanes()
        {
            return _context.Lanes.ToList();
        }

        public Party GetParty(int id)
        {
            var party = _context.Parties.FirstOrDefault(x => x.Id == id);
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

        public Lane GetLane(int id)
        {
            return _context.Lanes.FirstOrDefault(x => x.Id == id);
        }
    }
}
