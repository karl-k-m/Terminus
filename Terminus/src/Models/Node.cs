using System.ComponentModel.DataAnnotations;

namespace Terminus.Models;

/// <summary>
/// Terminus Node
/// </summary>
public class Node
{
    [Key] public int Id { get; set; }      // Node ID
    public string HashSalt { get; set; }   // Challenge Hash Salt
    public DateTime LastSeen { get; set; } // Timestamp of Last Seen
}