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
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }
        [Fact]
        public void Test1()
        {
            var repo = new PartyRepository(_context);
            repo.RegisterMember("Benny", "8705203984", "0708160404", "min@mail.com");
            repo.RegisterMember("Danny", "8705203984", "0708160404", "min@mail.com");
            var count = _context.Parties.ToListAsync().Result;
            Assert.Equal(2,count.Count);

        }
    }
}
