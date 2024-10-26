using System;
using MAUITest.Business.Models;
using MAUITest.Data.Configurations;
using MAUITest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MAUITest.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<BankDetailsDataModel> BankDetails { get; set; }
        public DbSet<CardDetailsDataModel> CardDetails { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Configure SQLite database path
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, Constants.DbName);
            optionsBuilder.UseSqlite($"Filename={dbPath}");

            Console.WriteLine($"Filename={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine($"Begin: Execute AppDbContext OnModelCreating: {DateTime.Now}");

            base.OnModelCreating(modelBuilder);

            //configuration
            modelBuilder.ApplyConfiguration(new BankDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CardDetailConfiguration());

            Console.WriteLine($"End: Execute AppDbContext OnModelCreating: {DateTime.Now}");
        }
    }
}

