using Microsoft.EntityFrameworkCore;

namespace NpTest.Data;

public class BiddingContext : DbContext
{
    public BiddingContext(DbContextOptions<BiddingContext> options) : base(options)
    {
    }
}
