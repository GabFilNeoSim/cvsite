using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Message> Messages { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Qualification> Qualifications { get; set; }

        public DbSet<QualificationType> QualificationTypes { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Owner)
                .WithMany()
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Projects)
                .WithMany(p => p.Users)
                .UsingEntity(j => j.ToTable("UserProjects")); 

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany()
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);

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

            modelBuilder.Entity("SkillUser").HasData(new {SkillsId = 1, UsersId = 1});
            modelBuilder.Entity("SkillUser").HasData(new { SkillsId = 2, UsersId = 1 });

            modelBuilder.Entity<QualificationType>().HasData(
                new QualificationType { Id = 1, Name = "Experience" },
                new QualificationType { Id = 2, Name = "Education" }
            );
        }
    }
}
