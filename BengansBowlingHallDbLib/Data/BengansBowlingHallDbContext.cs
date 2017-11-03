using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AccountabilityLib;

namespace BengansBowlingHallDbLib.Data
{
    public class BengansBowlingHallDbContext : DbContext
    {
        public BengansBowlingHallDbContext(DbContextOptions<BengansBowlingHallDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Party> Parties { get; set; }
        public DbSet<Accountability> Accountabilities { get; set; }
        public DbSet<AccountabilityType> AccountabilityTypes { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Competition> Competitions { get; set; }


    }
}
