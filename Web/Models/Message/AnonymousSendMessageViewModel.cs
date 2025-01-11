using System.ComponentModel.DataAnnotations;

namespace Web.Models.Message;

public class AnonymousSendMessageViewModel
{
    [Required]
    [StringLength(255)]
    public string Text { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    // Hidden
    public string ReceiverId { get; set; }
}
