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
    public class IntegrationTest1
    {
        private BengansBowlingHallDbContext _context;
        private BengansSystem _sut;
        private SqlRepository repo;


        public IntegrationTest1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BengansBowlingHallDbContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BengansBowlingHallDb;Integrated Security=True;" +
            //                            "Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;" +
            //                            "MultiSubnetFailover=False");
            _context = new BengansBowlingHallDbContext(optionsBuilder.Options);
            repo = new SqlRepository(_context);
            _sut = new BengansSystem(repo);
            Seed();
        }

        public void Seed()
        {
            _sut.CreateMember("87052060389", "Benny");
            _sut.CreateMember("87052234324", "Lisa");
            _sut.CreateMember("87123523122", "Jonny");
            _sut.CreateMember("87052012312", "Donny");
            _sut.CreateMember("87063234112", "Fanny");
        }

        [Fact]
        public void TestAmountOfMembers()
        {
            var parties = _sut.GetAllParties();
            Assert.Equal(5, parties.Count);
        }

        [Fact]
        public void GetCompetitionInformation()
        {
            var createLane = _sut.CreateLane(1);
            var lane = _sut.GetLane(createLane);

            var serie1Id = _sut.CreateSerie(_sut.GetParty(1), 50);
            var serie2Id = _sut.CreateSerie(_sut.GetParty(2), 70);
            var serie1 = _sut.GetSerie(serie1Id);
            var serie2 = _sut.GetSerie(serie2Id);
            var round1Id = _sut.CreateRound(serie1, serie2);
            var round1 = _sut.GetRound(round1Id);

            var serie3Id = _sut.CreateSerie(_sut.GetParty(1), 50);
            var serie4Id = _sut.CreateSerie(_sut.GetParty(2), 110);
            var serie3 = _sut.GetSerie(serie3Id);
            var serie4 = _sut.GetSerie(serie4Id);
            var round2Id = _sut.CreateRound(serie3, serie4);
            var round2 = _sut.GetRound(round2Id);

            var serie5Id = _sut.CreateSerie(_sut.GetParty(1), 230);
            var serie6Id = _sut.CreateSerie(_sut.GetParty(2), 110);
            var serie5 = _sut.GetSerie(serie5Id);
            var serie6 = _sut.GetSerie(serie6Id);
            var round3Id = _sut.CreateRound(serie5, serie6);
            var round3 = _sut.GetRound(round3Id);

            var roundList = new List<Round>{round1, round2, round3 };
            var matchId = _sut.CreateMatch(roundList, lane);
            var match = _sut.GetMatch(matchId);
            var timeperiod = new TimePeriod
            {
                Starttime = new DateTime(2017, 11, 01),
                Endtime = new DateTime(2017, 11, 25)
            };
            var matchList = new List<Match>();
            matchList.Add(match);

            var compId = _sut.CreateCompetition("Bengans Tävling", timeperiod, matchList);
            var comp = _sut.GetCompetition(compId);
            var matchRounds = _sut.GetMatch(matchId);
            
            Assert.Equal("Bengans Tävling", comp.Name);
            Assert.Equal(3, matchRounds.Rounds.Count);
        }
    }
}
