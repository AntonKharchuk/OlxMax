
using Microsoft.EntityFrameworkCore;

using OlxMax.Dal.Entities;

using System;
using System.Reflection.Metadata;

namespace OlxMax.Dal.DbContexts
{
    public class DefaultAppDbContext : DbContext
    {

        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Auction> Auctions { get; set; }

        public DefaultAppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auction>()
                .HasMany(e => e.Bets)
                .WithOne(e => e.Auction)
                .HasForeignKey(e => e.AuctionId)
                .IsRequired(true);
        }

    }
}
