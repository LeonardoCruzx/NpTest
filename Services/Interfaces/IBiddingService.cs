using NpTest.Models;

namespace NpTest.Services.Interfaces;

public interface IBiddingService
{
    Task<IEnumerable<Bidding>> GetBiddingsAsync();
}
