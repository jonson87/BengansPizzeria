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

        public int CreateCompetition(string name, TimePeriod period, List<Match> matches)
        {
            var competition = new Competition()
            {
                Name = name,
                Period = period,
                Matches = matches
            };
            Competitions.Add(competition);
            return competition.Id;
        }

        //public void CreateMatch(Party player1, Party player2)
        //{
        //    var match = new Match { PlayerOne = player1, PlayerTwo = player2 };
        //    Matches.Add(match);
        //}

        public int CreateMember(string legalId, string name)
        {
            var party = new Party {Name = name, LegalId = legalId};
            Parties.Add(party);
            return party.PartyId;
        }

        public int CreateRound(Serie serieOne, Serie serieTwo)
        {
            throw new NotImplementedException();
        }

        public int CreateSerie(int score)
        {
            throw new NotImplementedException();
        }

        public List<Party> GetPlayers()
        {
            return Parties;
        }

        public int CreateMatch(List<Round> rounds)
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

        public int CreateSerie(int score, Party player)
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
