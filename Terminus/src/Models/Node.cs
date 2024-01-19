using System.ComponentModel.DataAnnotations;

namespace Terminus.Models;

/// <summary>
/// Terminus Node
/// </summary>
public class Node
{
    [Key] public int Id { get; set; }      // Node ID
    public byte[] HashSalt { get; set; }   // Challenge Hash Salt
    public string Name { get; set; }       // Hashed Node Name
    public DateTime LastSeen { get; set; } // Timestamp of Last Seen
}