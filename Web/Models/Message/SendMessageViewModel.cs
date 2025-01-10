using System.ComponentModel.DataAnnotations;

namespace Web.Models.Message;

public class SendMessageViewModel
{
    [Required]
    [MaxLength(2000)]
    public string Text { get; set; }
    public string ChatUserId { get; set; }
}
