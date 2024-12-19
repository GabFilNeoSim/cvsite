using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Data;

public partial class AppDbContext : DbContext
{
    protected void LoadExampleData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Title = "Skill 1" },
                new Skill { Id = 2, Title = "Skill 2" }
        );

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Firstname = "John",
                Lastname = "Doe",
                Address = "USA",
                AvatarUri = "",
                Private = false
            }
        );

        modelBuilder.Entity("SkillUser").HasData(new { SkillsId = 1, UsersId = 1 });
        modelBuilder.Entity("SkillUser").HasData(new { SkillsId = 2, UsersId = 1 });

        modelBuilder.Entity<QualificationType>().HasData(
            new QualificationType { Id = 1, Name = "Experience" },
            new QualificationType { Id = 2, Name = "Education" }
        );
    }
}
