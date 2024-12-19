using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Contexts;

public partial class AppDbContext : IdentityDbContext<User>
{
    protected void LoadExampleData(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Skill>().HasData(
        //        new Skill { Id = 1, Title = "Skill 1" },
        //        new Skill { Id = 2, Title = "Skill 2" }
        //);

        //modelBuilder.Entity<User>().HasData(
        //    new User
        //    {
        //        FirstName = "John",
        //        LastName = "Doe",
        //        Address = "USA",
        //        AvatarUri = "",
        //        Private = false
        //    }
        //);

        //modelBuilder.Entity("SkillUser").HasData(new { SkillsId = 1, UsersId = "8a04de53-2385-4a7c-8e96-72696e636926" });
        //modelBuilder.Entity("SkillUser").HasData(new { SkillsId = 2, UsersId = "5b3db78c-0f16-4d20-b8fc-7918face29a9" });

        //modelBuilder.Entity<QualificationType>().HasData(
        //    new QualificationType { Id = 1, Name = "Experience" },
        //    new QualificationType { Id = 2, Name = "Education" }
        //);
    }
}
