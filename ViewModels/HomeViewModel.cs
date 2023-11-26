using NpTest.Models;

namespace NpTest.ViewModels;

public class HomeViewModel
{
    public IEnumerable<Bidding> Biddings { get; set; } = new List<Bidding>();
    public string OrderBy { get; set; } = string.Empty;
    public string OrderByType { get; set; } = string.Empty;
    public string FilterBy { get; set; } = string.Empty;
    public string FilterByValue { get; set; } = string.Empty;
}
