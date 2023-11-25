using System.ComponentModel.DataAnnotations;

namespace NpTest.Models;

public class Bidding
{
    public int Id { get; set; }
    [Required]
    public int Number { get; set; }
    [Required]
    public string? Description { get; set; }
    public DateTime OpenDate { get; set; }
    [Required]
    public BiddingStatus Status { get; set; }
}

public enum BiddingStatus
{
    Open,
    InProgress,
    Closed
}
