using BengansBowlingHallDbLib;
using System;
using AccountabilityLib;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BengansBowlingIntegrationTestsLib
{
    public class UnitTest1
    {
        private BengansRepository repo;

        public UnitTest1()
        {
            //var optionsBuilder = new DbContextOptionsBuilder<BengansBowlingHallDbContext>();
            //optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BengansBowlingHallDb;Integrated Security=True;" +
            //                            "Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;" +
            //                            "MultiSubnetFailover=False");
            //_context = new BengansBowlingHallDbContext(optionsBuilder.Options);

            repo = new BengansRepository();
            repo.RegisterMember(1,"Benny", "8705203984", "0708160404", "min@mail.com");
            repo.RegisterMember(2,"Danny", "8705203234", "1293828311", "min@mail.com");
            repo.RegisterMember(3,"Donny", "8123123984", "1239283901", "min@mail.com");
            repo.RegisterMember(4,"Jonny", "8103921914", "1239121211", "min@mail.com");
            
            //Random r = new Random();
            //repo.RegisterSerie(1,r.Next(100, 300));
            //repo.RegisterSerie(2,r.Next(100, 300));
            //repo.RegisterSerie(3,r.Next(100, 300));
            //repo.RegisterSerie(4,r.Next(100, 300));
            //repo.RegisterSerie(5,r.Next(100, 300));
            //repo.RegisterSerie(6,r.Next(100, 300));

            var period = new TimePeriod
            {
                Starttime = new DateTime(2017, 01, 01),
                Endtime = new DateTime(2017, 12, 31)
            };

            repo.RegisterCompetition(1, "Bengans pung", period);

            repo.RegisterMatch(1, repo.Parties.Find(x => x.Name == "Benny"), repo.Parties.Find(x => x.Name == "Danny"));
            repo.RegisterMatch(2, repo.Parties.Find(x => x.Name == "Benny"), repo.Parties.Find(x => x.Name == "Donny"));
            repo.RegisterMatch(3, repo.Parties.Find(x => x.Name == "Benny"), repo.Parties.Find(x => x.Name == "Jonny"));
            repo.RegisterMatch(4, repo.Parties.Find(x => x.Name == "Danny"), repo.Parties.Find(x => x.Name == "Donny"));
            repo.RegisterMatch(5, repo.Parties.Find(x => x.Name == "Danny"), repo.Parties.Find(x => x.Name == "Jonny"));
            repo.RegisterMatch(6, repo.Parties.Find(x => x.Name == "Donny"), repo.Parties.Find(x => x.Name == "Jonny"));

            //repo.RegisterRound()

            //repo.RegisterMatch("Match1", _context.Parties.FirstOrDefaultAsync(x => x.Name == "Benny").Result,
            //    _context.Parties.FirstOrDefaultAsync(x => x.Name == "Danny").Result,
            //    _context.Parties.FirstOrDefaultAsync(x => x.Name == "Benny").Result);
            //_context.Database.EnsureDeleted();
            //_context.Database.EnsureCreated();
        }
        [Fact]
        public void Test1()
        {
            var partyList = repo.Parties;
            Assert.Equal(4, partyList.Count);
        }

        [Fact]
        public void TestWinner()
        {
            var match = repo.PlayMatch(1);
            Assert.Equal(repo.Parties[1], match.Winner);
            //Assert.IsType(Party, match.Winner);
        }
    }
}
