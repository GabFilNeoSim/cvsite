using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class Message
{
    public int Id { get; set; }

    public string Text{ get; set; }

    public bool Read { get; set; }

    public DateTime CreatedAt { get; set; }

    public string AnonymousName { get; set; }

    public int SenderId { get; set; }
    
    public int ReceiverId { get; set; }

    [ForeignKey(nameof(SenderId))]
    public virtual User Sender { get; set; }

    [ForeignKey(nameof(ReceiverId))]
    public virtual User Receiver { get; set; }
}

