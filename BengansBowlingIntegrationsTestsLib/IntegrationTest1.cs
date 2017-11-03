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
            var serie1 = repo.GetSerie(serie1Id);
            var serie2 = repo.GetSerie(serie2Id);
            var round1Id = sut.CreateRound(serie1, serie2);
            var round1 = repo.GetRound(round1Id);
            var roundList = new List<Round>();
            roundList.Add(round1);
            var matchId = sut.CreateMatch(roundList);
            var match = repo.GetMatch(matchId);
            var timeperiod = new TimePeriod
            {
                Starttime = new DateTime(2017, 11, 01),
                Endtime = new DateTime(2017, 11, 25)
            };
            var matchList = new List<Match>();
            matchList.Add(match);
            var compId = sut.CreateCompetition("Bengans Tävling", timeperiod, matchList);
            var comp = _context.Competitions.FirstOrDefaultAsync(x => x.Id == compId).Result;
            Assert.Equal("Bengans Tävling", comp.Name);
        }
    }
}
