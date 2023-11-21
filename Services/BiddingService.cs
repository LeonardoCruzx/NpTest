using Microsoft.EntityFrameworkCore;
using NpTest.Data;
using NpTest.Models;
using NpTest.Services.Interfaces;

namespace NpTest.Services;

public class BiddingService : IBiddingService
{
    private readonly BiddingContext _context;

    public BiddingService(BiddingContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Bidding>> GetBiddingsAsync()
        => await _context.Biddings.ToListAsync();
}
