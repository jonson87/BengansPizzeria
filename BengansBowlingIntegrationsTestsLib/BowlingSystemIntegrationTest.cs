using System;
using System.Collections.Generic;
using AccountabilityLib;
using BengansBowlingHallDbLib;
using BengansBowlingHallDbLib.Data;
using BengansBowlingHallDbLib.Interfaces;
using Microsoft.EntityFrameworkCore;
using Xunit;
using BengansBowlingHallDbLib.Repositories;

namespace BengansBowlingIntegrationsTestsLib
{
    public class BowlingSystemIntegrationTest
    {
        private BengansBowlingHallDbContext _context;
        private BengansSystem _system;
        private SqlRepository _repository;

        public BowlingSystemIntegrationTest()
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

            //Create lane
            var laneId = _system.CreateLane(1);
            var lane = _system.GetLane(1);

            var roundList = new List<Round>{round1, round2, round3 };
            var matchId = _system.CreateMatch(roundList, lane);
            var match = _system.GetMatch(matchId);
            var timeperiod = new TimePeriod
            {
                Starttime = new DateTime(2017, 11, 01),
                Endtime = new DateTime(2017, 11, 25)
            };
            var matchList = new List<Match>();
            matchList.Add(match);

            var competitionId = _system.CreateCompetition("Bästa Tävlingen", timeperiod, matchList);
            var competition = _system.GetCompetition(competitionId);
            var matchRounds = _system.GetMatch(matchId);
            
            Assert.Equal("Bästa Tävlingen", competition.Name);
            Assert.Equal(3, matchRounds.Rounds.Count);
            Assert.Equal(1, competition.Matches.Count);
        }

        public void Seed()
        {
            _system.CreateMember("89052060389", "Benny");
            _system.CreateMember("85052234324", "Max");
            _system.CreateMember("95123523122", "Jonny");
            _system.CreateMember("89052012312", "David");
            _system.CreateMember("79063234112", "Peter");
        }
    }
}
