using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;
using BankingApp.Entities;
using System.Threading.Tasks;
using System;
using BankingApp.Core.Entities;
using BankingApp.Core.Entities.Loan;

namespace BankingApp.Repository.Context
{
    public class BankingAppDbContext : DbContext
    {


        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

  




        public BankingAppDbContext(DbContextOptions<BankingAppDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;


        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    //modelBuilder.ApplyConfiguration(new UserLocalConfiguration());

        //    //modelBuilder.ApplyConfiguration(new UserSeed());
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // false olarak ayarlayarak Lazy Loading'i kapatın

            options.UseNpgsql(connectionString: "User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=BankingAppDb;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User - Account : One to Many
            modelBuilder.Entity<User>()
                .HasMany(d => d.Accounts)
                .WithOne()
                .HasForeignKey(e => e.UserId);

            // Yeni ilişki ekleniyor: Account - User
            //modelBuilder.Entity<Account>()
            //    .HasOne(a => a.User)
            //    .WithMany(u => u.Accounts)
            //    .HasForeignKey(a => a.UserId);

        }


    }
}
