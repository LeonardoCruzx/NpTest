using System.ComponentModel.DataAnnotations;

namespace NpTest.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
