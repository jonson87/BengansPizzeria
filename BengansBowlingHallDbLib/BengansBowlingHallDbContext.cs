using System;
using System.Collections.Generic;
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
        public DbSet<Accountability> Accountabilities { get; set; }
        public DbSet<AccountabilityType> AccountabilityTypes { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Serie> Series { get; set; }

    }
}
