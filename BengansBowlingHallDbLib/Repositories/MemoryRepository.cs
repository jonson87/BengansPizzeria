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

        public MemoryRepository()
        {
            Parties = new List<Party>();
            Matches = new List<Match>();
            Rounds = new List<Round>();
            Series = new List<Serie>();
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
