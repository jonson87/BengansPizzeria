using System;
using Microsoft.EntityFrameworkCore;
using AccountabilityLib;

namespace BengansBowlingHallDbLib
{
    public class BengansBowlingHallDbContext : DbContext
    {
        public BengansBowlingHallDbContext(DbContextOptions<BengansBowlingHallDbContext> options) : base(options)
        {
        }

        public DbSet<Party> Parties { get; set; }
    }
}
