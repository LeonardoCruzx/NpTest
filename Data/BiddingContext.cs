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

        ConfigureUser(modelBuilder);
        SeedUsers(modelBuilder);
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

    private void ConfigureUser(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().Property(u => u.UserName).IsRequired();
        modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
        modelBuilder.Entity<User>().Property(u => u.CreatedAt).IsRequired();
        modelBuilder.Entity<User>().Property(u => u.UpdatedAt).IsRequired();
    }

    private void SeedUsers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                UserName = "admin",
                Password = "admin",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        );
    }
}
