using System.ComponentModel.DataAnnotations;

namespace Web.Models.Message;

public class SendMessageViewModel
{
    [Required]
    [StringLength(255)]
    public string Text { get; set; }
    public string ChatUserId { get; set; }
}
