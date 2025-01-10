using System.ComponentModel.DataAnnotations;

namespace Models;

public class Message
{
    public int Id { get; set; }

    [Required]
    [MaxLength(2000)]
    public string Text{ get; set; }

    [Required]
    public bool Read { get; set; } = false;

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [MaxLength(100)]
    public string? AnonymousName { get; set; }

    public string? SenderId { get; set; }
    public virtual User? Sender { get; set; }

    public string ReceiverId { get; set; }
    public virtual User Receiver { get; set; }
}

