﻿using Microsoft.EntityFrameworkCore;
using AccountabilityLib;

namespace BengansBowlingHallDbLib.Data
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
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Lane> Lanes { get; set; }

    }
}
