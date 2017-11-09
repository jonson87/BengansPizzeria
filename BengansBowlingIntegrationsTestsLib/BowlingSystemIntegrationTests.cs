using System;
using System.Collections.Generic;
using AccountabilityLib;
using BengansBowlingHallDbLib;
using BengansBowlingHallDbLib.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;
using MeasurementLib;

namespace BengansBowlingIntegrationsTestsLib
{
    public class BowlingSystemIntegrationTests
    {
        private BengansBowlingHallDbContext _context;
        private BengansSystem _system;
        private SqlRepository _repository;
        private List<Match> matchList = new List<Match>();
        private List<Round> roundList = new List<Round>();

        public BowlingSystemIntegrationTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BengansBowlingHallDbContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _context = new BengansBowlingHallDbContext(optionsBuilder.Options);
            _repository = new SqlRepository(_context);
            _system = new BengansSystem(_repository);
            Seed();
        }

        [Fact]
        public void CheckRepositoryForCreatedParties()
        {
            var parties = _system.GetAllParties();
            Assert.Equal(5, parties.Count);
        }

        [Fact]
        public void CheckCompetitionInformation()
        {
            //Create lane
            var laneId = _system.CreateLane(1);
            var lane = _system.GetLane(1);

            //Create match
            var matchId = _system.CreateMatch(roundList, lane);
            var match = _system.GetMatch(matchId);

            //Create time period
            var timeperiod = new TimePeriod
            {
                Starttime = new DateTime(2017, 11, 01),
                Endtime = new DateTime(2017, 11, 25)
            };

            matchList.Add(match);

            //Create Competition
            var competitionId = _system.CreateCompetition("Bästa Tävlingen", timeperiod, matchList);
            var competition = _system.GetCompetition(competitionId);
            var matchRounds = _system.GetMatch(matchId).Rounds;
            
            Assert.Equal("Bästa Tävlingen", competition.Name);
            Assert.Equal(3, matchRounds.Count);
            Assert.Equal(1, competition.Matches.Count);
        }

        public void Seed()
        {
            //Create players
            _system.CreateMember("89052060389", "Benny");
            _system.CreateMember("85052234324", "Max");
            _system.CreateMember("95123523122", "Jonny");
            _system.CreateMember("89052012312", "David");
            _system.CreateMember("79063234112", "Peter");

            //Create rounds with series
            var serie1Id = _system.CreateSerie(_system.GetParty(1), 50);
            var serie2Id = _system.CreateSerie(_system.GetParty(2), 70);
            var serie1 = _system.GetSerie(serie1Id);
            var serie2 = _system.GetSerie(serie2Id);
            var round1Id = _system.CreateRound(serie1, serie2);
            var round1 = _system.GetRound(round1Id);

            var serie3Id = _system.CreateSerie(_system.GetParty(1), 50);
            var serie4Id = _system.CreateSerie(_system.GetParty(2), 110);
            var serie3 = _system.GetSerie(serie3Id);
            var serie4 = _system.GetSerie(serie4Id);
            var round2Id = _system.CreateRound(serie3, serie4);
            var round2 = _system.GetRound(round2Id);

            var serie5Id = _system.CreateSerie(_system.GetParty(1), 230);
            var serie6Id = _system.CreateSerie(_system.GetParty(2), 110);
            var serie5 = _system.GetSerie(serie5Id);
            var serie6 = _system.GetSerie(serie6Id);
            var round3Id = _system.CreateRound(serie5, serie6);
            var round3 = _system.GetRound(round3Id);

            roundList.Add(round1);
            roundList.Add(round2);
            roundList.Add(round3);
        }
    }
}
