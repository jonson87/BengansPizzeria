using BengansBowlingHallDbLib.Interfaces;
using System;
using System.Collections.Generic;
using AccountabilityLib;

namespace BengansBowlingHallDbLib.Repositories
{
    public sealed class MemoryRepository : IBengansRepository
    {
        private static MemoryRepository instance = null;
        private static readonly object padlock = new object();

        public List<Party> Parties;
        public List<Match> Matches;
        public List<Round> Rounds;
        public List<Serie> Series;
        public List<Competition> Competitions { get; set; }

        public MemoryRepository()
        {
            Parties = new List<Party>();
            Matches = new List<Match>();
            Rounds = new List<Round>();
            Series = new List<Serie>();
            Competitions = new List<Competition>();
        }

        public static MemoryRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new MemoryRepository();
                        }
                    }
                }
                return instance;
            }
        }

        public void CreateCompetition(string name, TimePeriod period, List<Match> matches)
        {
            var competition = new Competition()
            {
                Name = name,
                Period = period,
                Matches = matches
            };
            Competitions.Add(competition);
        }

        //public void CreateMatch(Party player1, Party player2)
        //{
        //    var match = new Match { PlayerOne = player1, PlayerTwo = player2 };
        //    Matches.Add(match);
        //}

        public void CreateMember(string legalId, string name)
        {
            var party = new Party {Name = name, LegalId = legalId};
            Parties.Add(party);
        }

        public void CreateRound(Round round)
        {
        }

        public void CreateSerie(Serie serie)
        {
            throw new NotImplementedException();
        }

        public List<Party> GetPlayers()
        {
            return Parties;
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
