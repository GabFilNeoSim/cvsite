using System.ComponentModel.DataAnnotations;

namespace Web.Models.Message;

public class AnonymousSendMessageViewModel
{
    [Required]
    [MaxLength(2000)]
    public string Text { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    // Hidden
    public string ReceiverId { get; set; }
}
