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
        private BengansSystem sut;
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
            sut = new BengansSystem(repo);
            Seed();
        }

        public void Seed()
        {
            sut.CreateMember("87052060389", "Benny");
            sut.CreateMember("87052234324", "Danny");
            sut.CreateMember("87123523122", "Jonny");
            sut.CreateMember("87052012312", "Donny");
            sut.CreateMember("87063234112", "Fanny");
        }

        [Fact]
        public void GenerateMembers()
        {
            var parties = _context.Parties.ToListAsync().Result;
            Assert.Equal(5, parties.Count);
        }

        [Fact]
        public void GetCompetitionInformation()
        {
            var serie1Id = sut.CreateSerie(_context.Parties.FirstOrDefaultAsync(x => x.Name == "Benny").Result, 50);
            var serie2Id = sut.CreateSerie(_context.Parties.FirstOrDefaultAsync(x => x.Name == "Danny").Result, 70);
            var serie1 = sut.GetSerie(serie1Id);
            var serie2 = sut.GetSerie(serie2Id);
            var round1Id = sut.CreateRound(serie1, serie2);
            var round1 = sut.GetRound(round1Id);

            var serie3Id = sut.CreateSerie(_context.Parties.FirstOrDefaultAsync(x => x.Name == "Benny").Result, 50);
            var serie4Id = sut.CreateSerie(_context.Parties.FirstOrDefaultAsync(x => x.Name == "Danny").Result, 110);
            var serie3 = sut.GetSerie(serie3Id);
            var serie4 = sut.GetSerie(serie4Id);
            var round2Id = sut.CreateRound(serie3, serie4);
            var round2 = sut.GetRound(round2Id);

            var serie5Id = sut.CreateSerie(_context.Parties.FirstOrDefaultAsync(x => x.Name == "Benny").Result, 230);
            var serie6Id = sut.CreateSerie(_context.Parties.FirstOrDefaultAsync(x => x.Name == "Danny").Result, 110);
            var serie5 = sut.GetSerie(serie5Id);
            var serie6 = sut.GetSerie(serie6Id);
            var round3Id = sut.CreateRound(serie5, serie6);
            var round3 = sut.GetRound(round3Id);

            var roundList = new List<Round>{round1, round2, round3 };
            var matchId = sut.CreateMatch(roundList);
            var match = sut.GetMatch(matchId);
            var timeperiod = new TimePeriod
            {
                Starttime = new DateTime(2017, 11, 01),
                Endtime = new DateTime(2017, 11, 25)
            };
            var matchList = new List<Match>();
            matchList.Add(match);
            var compId = sut.CreateCompetition("Bengans Tävling", timeperiod, matchList);
            var comp = _context.Competitions.FirstOrDefaultAsync(x => x.Id == compId).Result;

            var matchRounds = _context.Matches.FirstOrDefaultAsync(x => x.Id == matchId).Result;
            
            Assert.Equal("Bengans Tävling", comp.Name);
            Assert.Equal(3, matchRounds.Rounds.Count);
        }
    }
}
