namespace Web.Models
{
    public class ProfileViewModel
    {
        public UserViewModel User { get; set; }

        public List<QualificationViewModel> Work {  get; set; }
        public int WorkCount => Work.Count;

        public List<QualificationViewModel> Education { get; set; }
        public int EducationCount => Education.Count;

        public List<SkillViewModel> Skill { get; set; }
    }
}
