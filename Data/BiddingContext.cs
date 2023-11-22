using Microsoft.EntityFrameworkCore;
using NpTest.Models;

namespace NpTest.Data;

public class BiddingContext : DbContext
{
    public BiddingContext(DbContextOptions<BiddingContext> options) : base(options)
    {
    }

    public DbSet<Bidding> Biddings { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureBidding(modelBuilder);
        SeedBiddings(modelBuilder);


    }

    private void ConfigureBidding(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bidding>().ToTable("Bidding");
        modelBuilder.Entity<Bidding>().HasKey(b => b.Id);
        modelBuilder.Entity<Bidding>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Bidding>().Property(b => b.Number).IsRequired();
        modelBuilder.Entity<Bidding>().Property(b => b.Description).IsRequired(false);
        modelBuilder.Entity<Bidding>().Property(b => b.OpenDate).IsRequired();
        modelBuilder.Entity<Bidding>().Property(b => b.Status).IsRequired();

    }

    private void SeedBiddings(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bidding>().HasData(
            new Bidding
            {
                Id = 1,
                Number = 1,
                Description = "First bidding",
                OpenDate = DateTime.Now,
                Status = BiddingStatus.Open
            },
            new Bidding
            {
                Id = 2,
                Number = 2,
                Description = "Second bidding",
                OpenDate = DateTime.Now,
                Status = BiddingStatus.Open
            },
            new Bidding
            {
                Id = 3,
                Number = 3,
                Description = "Third bidding",
                OpenDate = DateTime.Now,
                Status = BiddingStatus.Open
            }
        );
    }
}
