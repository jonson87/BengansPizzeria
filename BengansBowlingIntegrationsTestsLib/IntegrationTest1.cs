using System;
using System.Collections.Generic;
using AccountabilityLib;
using BengansBowlingHallDbLib;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BengansBowlingIntegrationsTestsLib
{
    public class IntegrationTest1
    {
        private BengansBowlingHallDbContext _context;
        private BengansSystem repo;
        public IntegrationTest1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BengansBowlingHallDbContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BengansBowlingHallDb;Integrated Security=True;" +
            //                            "Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;" +
            //                            "MultiSubnetFailover=False");
            _context = new BengansBowlingHallDbContext(optionsBuilder.Options);

            var benny = new Party()
            {
                PartyId = 1,
                Name = "Benny",
                LegalId = "8705203984",
                Phone = "0708160404",
                Email = "min@mail.com"
            };

            var danny = new Party()
            {
                PartyId = 2,
                Name = "Danny",
                LegalId = "9105203234",
                Phone = "1293828311",
                Email = "min@mail.com"
            };

            var donny = new Party()
            {
                PartyId = 3,
                Name = "Donny",
                LegalId = "9505203234",
                Phone = "1239283901",
                Email = "min@mail.com"
            };

            var johny = new Party()
            {
                PartyId = 4,
                Name = "Jonny",
                LegalId = "7505203234",
                Phone = "1239121211",
                Email = "min@mail.com"
            };

            //repo = new BengansSystem(_context);
            //repo.RegisterMember(benny);
            //repo.RegisterMember(danny);
            //repo.RegisterMember(donny);
            //repo.RegisterMember(johny);

            var period = new TimePeriod
            {
                Id = 1,
                Starttime = new DateTime(2017, 10, 23),
                Endtime = new DateTime(2017, 10, 24)
            };

            var match1 = new Match()
            {
                Id = 1,
                PlayerOne = benny,
                PlayerOneId = 1,
                PlayerTwo = danny,
                PlayerTwoId = 2,
            };

            var match2 = new Match()
            {
                Id = 2,
                PlayerOne = benny,
                PlayerOneId = 1,
                PlayerTwo = danny,
                PlayerTwoId = 2,
            };

            var match3 = new Match()
            {
                Id = 3,
                PlayerOne = benny,
                PlayerOneId = 1,
                PlayerTwo = danny,
                PlayerTwoId = 2,
            };

            var match4 = new Match()
            {
                Id = 4,
                PlayerOne = benny,
                PlayerOneId = 1,
                PlayerTwo = danny,
                PlayerTwoId = 2,
            };

            var match5 = new Match()
            {
                Id = 5,
                PlayerOne = benny,
                PlayerOneId = 1,
                PlayerTwo = danny,
                PlayerTwoId = 2,
            };

            var match6 = new Match()
            {
                Id = 6,
                PlayerOne = benny,
                PlayerOneId = 1,
                PlayerTwo = danny,
                PlayerTwoId = 2,
            };

            //repo.RegisterMatch(match1);
            //repo.RegisterMatch(match2);
            //repo.RegisterMatch(match3);
            //repo.RegisterMatch(match4);
            //repo.RegisterMatch(match5);
            //repo.RegisterMatch(match6);

            var matchList = new List<Match>();
            matchList.Add(match1);
            matchList.Add(match2);
            matchList.Add(match3);
            matchList.Add(match4);
            matchList.Add(match5);
            matchList.Add(match6);

            var competition = new Competition()
            {
                Name = "BengansTävling",
                Period = period,
                Matches = matchList
            };

            //repo.RegisterCompetition(competition);
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
            //var co = comp.Matches;
            Assert.Equal("BengansTävling", comp.Name);
        }
    }
}
