﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Message
{
    public int Id { get; set; }

    public string Text{ get; set; }

    public bool Read { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? AnonymousName { get; set; }

    public string SenderId { get; set; }
    public virtual User Sender { get; set; }

    public string ReceiverId { get; set; }
    public virtual User Receiver { get; set; }
}

