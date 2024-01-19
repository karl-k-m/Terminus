using System.ComponentModel.DataAnnotations;

namespace Terminus.Models;

/// <summary>
/// OTP Encrypted Message
/// </summary>
public class Message
{
    [Key] public int Id { get; set; }          // Message ID
    public byte[] Content { get; set; }        // OTP Encrypted Message Content
    public int Sender { get; set; }            // Sender Node ID
    public DateTime Timestamp { get; set; }    // Timestamp of Message
    public long StartIndex { get; set; }       // Start Index of OTP Key
    public long EndIndex { get; set; }         // End Index of OTP Key
}