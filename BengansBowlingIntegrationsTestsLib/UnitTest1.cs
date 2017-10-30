using System;
using System.Collections.Generic;
using AccountabilityLib;
using BengansBowlingHallDbLib;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BengansBowlingIntegrationsTestsLib
{
    public class UnitTest1
    {
        private BengansBowlingHallDbContext _context;
        private BengansRepository repo;
        public UnitTest1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BengansBowlingHallDbContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BengansBowlingHallDb;Integrated Security=True;Connect Timeout=30;" +
            //                            "Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            _context = new BengansBowlingHallDbContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            repo = new BengansRepository(_context);
            repo.RegisterMember("Benny", "8705203984", "0708160404", "min@mail.com");
            repo.RegisterMember("Danny", "8705203234", "1293828311", "min@mail.com");
            repo.RegisterMember("Donny", "8123123984", "1239283901", "min@mail.com");
            repo.RegisterMember("Jonny", "8103921914", "1239121211", "min@mail.com");
            var period = new TimePeriod
            {
                Starttime = new DateTime(2017, 10, 23),
                Endtime = new DateTime(2017, 10, 24)
            };

            var match1 = repo.RegisterMatch(repo.Parties.Find(x => x.Name == "Benny"), repo.Parties.Find(x => x.Name == "Danny"));
            var match2 = repo.RegisterMatch(repo.Parties.Find(x => x.Name == "Benny"), repo.Parties.Find(x => x.Name == "Donny"));
            var match3 = repo.RegisterMatch(repo.Parties.Find(x => x.Name == "Benny"), repo.Parties.Find(x => x.Name == "Jonny"));
            var match4 = repo.RegisterMatch(repo.Parties.Find(x => x.Name == "Danny"), repo.Parties.Find(x => x.Name == "Donny"));
            var match5 = repo.RegisterMatch(repo.Parties.Find(x => x.Name == "Danny"), repo.Parties.Find(x => x.Name == "Jonny"));
            var match6 = repo.RegisterMatch(repo.Parties.Find(x => x.Name == "Donny"), repo.Parties.Find(x => x.Name == "Jonny"));
            var matchList = new List<Match>();
            matchList.Add(match1);
            matchList.Add(match2);
            matchList.Add(match3);
            matchList.Add(match4);
            matchList.Add(match5);
            matchList.Add(match6);
            var competition = repo.RegisterCompetition("BengansTävling", period, matchList);
        }

        [Fact]
        public void GenerateMembers()
        {
            var parties = _context.Parties.ToListAsync().Result;
            Assert.Equal(4, parties.Count);
        }

        [Fact]
        public void GetCompetitionInformation()
        {
            var comp = _context.Competitions.FirstOrDefaultAsync(x => x.Id == 1).Result;
            Assert.Equal("BengansTävling", comp.Name);
        }
    }
}
