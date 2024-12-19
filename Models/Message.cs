using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Message
{
    public int Id { get; set; }

    public string Text{ get; set; }

    public bool Read { get; set; }

    public DateTime CreatedAt { get; set; }

    public string AnonymousName { get; set; }

    public string SenderId { get; set; }
    
    public string ReceiverId { get; set; }

    [ForeignKey(nameof(SenderId))]
    public virtual User Sender { get; set; }

    [ForeignKey(nameof(ReceiverId))]
    public virtual User Receiver { get; set; }
}

