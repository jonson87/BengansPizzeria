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
            sut.RegisterMember("87052060389", "Benny");
            sut.RegisterMember("87052234324", "Danny");
            sut.RegisterMember("87123523122", "Jonny");
            sut.RegisterMember("87052012312", "Donny");
            sut.RegisterMember("87063234112", "Fanny");
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
            //var matches = new List<Match>();
            //sut.RegisterSerie
            //var time = new TimePeriod {Endtime = new DateTime(2017, 11, 01), Starttime = new DateTime(2017, 12, 01)};
            //var comp = sut.RegisterCompetition("Bengans tävling",time, )
        }
    }
}
