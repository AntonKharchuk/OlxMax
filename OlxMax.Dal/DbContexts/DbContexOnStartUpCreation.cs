
using Microsoft.EntityFrameworkCore;

using OlxMax.Dal.Entities;

namespace OlxMax.Dal.DbContexts
{
    public class DbContexOnStartUpCreation : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Auction> Auctions { get; set; }


        public DbContexOnStartUpCreation(DbContextOptions<DbContexOnStartUpCreation> options)
      : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auction>()
                .HasMany(e => e.Bets)
                .WithOne(e => e.Auction)
                .HasForeignKey(e => e.AuctionId)
                .IsRequired(false);


            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "customer1", Password ="customer1", Balace=100 },
                new User { Id = 2, UserName = "customer2", Password ="customer2", Balace=200 },
                new User { Id = 3, UserName = "customer3", Password ="customer3", Balace=300 },
                new User { Id = 4, UserName = "customer4", Password ="customer4", Balace=400 },
                new User { Id = 5, UserName = "customer5", Password ="customer5", Balace=500 }
            );
            modelBuilder.Entity<Auction>().HasData(
                new Auction { Id = 1, Description = "auction1", MinEmount = 10},
                new Auction { Id = 2, Description = "auction2", MinEmount = 10},
                new Auction { Id = 3, Description = "auction3", MinEmount = 10},
                new Auction { Id = 4, Description = "auction4", MinEmount = 10},
                new Auction { Id = 5, Description = "auction5", MinEmount = 10}
            );

            modelBuilder.Entity<Bet>().HasData(
                new Bet { Id = 1, UserId = 1, AuctionId = 1, Emount = 20 },
                new Bet { Id = 2, UserId = 2, AuctionId = 1, Emount = 50 },
                new Bet { Id = 3, UserId = 3, AuctionId = 2, Emount = 60 },
                new Bet { Id = 4, UserId = 4, AuctionId = 3, Emount = 40 },
                new Bet { Id = 5, UserId = 5, AuctionId = 3, Emount = 60 },
                new Bet { Id = 6, UserId = 2, AuctionId = 4, Emount = 70 }
            );
        }

    }
}
