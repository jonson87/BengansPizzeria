﻿using BengansBowlingHallDbLib.Interfaces;
using System;
using System.Collections.Generic;
using AccountabilityLib;
using System.Linq;

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

        //Competition management
        public int CreateCompetition(string name, TimePeriod period, List<Match> matches)
        {
            var competition = new Competition()
            {
                Id = Competitions.Count + 1,
                Name = name,
                Period = period,
                Matches = matches
            };

            Competitions.Add(competition);
            return competition.Id;
        }

        public List<Competition> GetAllCompetitions()
        {
            return Competitions;
        }

        public Competition GetCompetition(int id)
        {
            return Competitions.Single(x => x.Id == id);
        }

        //Match management
        public int CreateMatch(List<Round> rounds)
        {
            var match = new Match()
            {
                Id = Matches.Count + 1,
                Rounds = rounds
            };

            Matches.Add(match);
            return match.Id;
        }

        public List<Match> GetAllMatches()
        {
            return Matches;
        }

        public Match GetMatch(int id)
        {
            return Matches.Single(x => x.Id == id);
        }

        //Party management
        public int CreateMember(string legalId, string name)
        {
            var party = new Party
            {
                Id = Parties.Count + 1,
                Name = name,
                LegalId = legalId
            };

            Parties.Add(party);
            return party.Id;
        }

        public List<Party> GetAllParties()
        {
            return Parties;
        }

        public Party GetParty(int id)
        {
            return Parties.Single(x => x.Id == id);
        }

        //Round management
        public int CreateRound(Serie serieOne, Serie serieTwo)
        {

            var round = new Round()
            {
                Id = Rounds.Count + 1,
                PlayerOneSerieId = serieOne.Id,
                PlayerTwoSerieId = serieTwo.Id,
                PlayerOneSerie = serieOne,
                PlayerTwoSerie = serieTwo
            };

            Rounds.Add(round);
            return round.Id;
        }

        public List<Round> GetAllRounds()
        {
            return Rounds;
        }

        public Round GetRound(int id)
        {
            return Rounds.Single(x => x.Id == id);
        }

        //Serie management
        public int CreateSerie(Party player, int score = 0)
        {
            var serie = new Serie()
            {
                Id = Series.Count + 1,
                PlayerId = player.Id,
                Player = player,
                Score = score
            };

            Series.Add(serie);
            return serie.Id;
        }       

        public List<Serie> GetAllSeries()
        {
            return Series;
        }       

        public Serie GetSerie(int id)
        {
            return Series.Single(x => x.Id == id);
        }
    }
}
