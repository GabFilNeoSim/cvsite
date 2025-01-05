using System.ComponentModel.DataAnnotations;

namespace Web.Models.Message;

public class AnonymousSendMessageViewModel
{
    [Required]
    public string Text { get; set; }

    [Required]
    public string Name { get; set; }

    // Hidden
    public string ReceiverId { get; set; }
}
