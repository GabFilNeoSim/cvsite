using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

// Data fields that allow controlled access for getting and setting values
public class Message
{
    public int Id { get; set; }

    public string Text{ get; set; }

    public bool Read { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string? AnonymousName { get; set; }

    public string? SenderId { get; set; }
    public virtual User? Sender { get; set; }

    public string ReceiverId { get; set; }
    public virtual User Receiver { get; set; }
}

