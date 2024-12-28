namespace Web.Models
{
    public class QualificationViewModel
    {
        public string Title { get; set; }

        public string? Description { get; set; }

        public string Location { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; } 
    }
}