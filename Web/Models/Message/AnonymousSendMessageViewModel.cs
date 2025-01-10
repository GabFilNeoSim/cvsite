using System.ComponentModel.DataAnnotations;

namespace Web.Models.Message;

public class AnonymousSendMessageViewModel
{
    [Required]
    [StringLength(2000)]
    public string Text { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    // Hidden
    public string ReceiverId { get; set; }
}
