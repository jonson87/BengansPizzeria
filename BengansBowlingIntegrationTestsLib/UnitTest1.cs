using BengansBowlingHallDbLib;
using System;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BengansBowlingIntegrationTestsLib
{
    public class UnitTest1
    {
        private BengansBowlingHallDbContext _context;

        public UnitTest1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BengansBowlingHallDbContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BengansBowlingHallDb;Integrated Security=True;" +
            //                            "Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;" +
            //                            "MultiSubnetFailover=False");
            _context = new BengansBowlingHallDbContext(optionsBuilder.Options);

            var repo = new PartyRepository(_context);
            repo.RegisterMember("Benny", "8705203984", "0708160404", "min@mail.com");
            repo.RegisterMember("Danny", "8705203234", "1293828311", "min@mail.com");
            repo.RegisterMember("Donny", "8123123984", "1239283901", "min@mail.com");
            repo.RegisterMember("Jonny", "8103921914", "1239121211", "min@mail.com");

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }
        [Fact]
        public void Test1()
        {
            var count = _context.Parties.ToListAsync().Result;
            Assert.Equal(4,count.Count);
        }
    }
}
