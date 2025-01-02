namespace Web.Models
{
    public class EditQualificationViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string? Description { get; set; }

        public string Location { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public int TypeId { get; set; }
    }
}
