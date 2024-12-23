using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Models;
using Microsoft.AspNetCore.Identity;

namespace Data.Contexts;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<UserProject> UserProjects { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<UserSkill> UserSkills { get; set; }
    public DbSet<QualificationType> QualificationTypes { get; set; }
    public DbSet<Qualification> Qualifications { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User-Project relationship (Many-to-Many)
        modelBuilder.Entity<UserProject>()
            .HasKey(up => new { up.UserId, up.ProjectId });

        modelBuilder.Entity<UserProject>()
            .HasOne(up => up.User)
            .WithMany(u => u.Projects)
            .HasForeignKey(up => up.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<UserProject>()
            .HasOne(up => up.Project)
            .WithMany(p => p.Users)
            .HasForeignKey(up => up.ProjectId)
            .OnDelete(DeleteBehavior.NoAction);

        // User-Skill relationship (Many-to-Many)
        modelBuilder.Entity<UserSkill>()
            .HasKey(us => new { us.UserId, us.SkillId }); // Composite Key

        modelBuilder.Entity<UserSkill>()
            .HasOne(us => us.User)
            .WithMany(u => u.Skills)
            .HasForeignKey(us => us.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<UserSkill>()
            .HasOne(us => us.Skill)
            .WithMany(s => s.Users)
            .HasForeignKey(us => us.SkillId)
            .OnDelete(DeleteBehavior.NoAction);

        // Qualification relationship
        modelBuilder.Entity<Qualification>()
            .HasOne(q => q.User)
            .WithMany(u => u.Qualifications)
            .HasForeignKey(q => q.UserId);

        modelBuilder.Entity<Qualification>()
            .HasOne(q => q.Type)
            .WithMany(qt => qt.Qualifications)
            .HasForeignKey(q => q.TypeId);

        // Message relationship
        modelBuilder.Entity<Message>()
            .HasOne(m => m.Sender)
            .WithMany(u => u.SentMessages)
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.Receiver)
            .WithMany(u => u.ReceivedMessages)
            .HasForeignKey(m => m.ReceiverId)
            .OnDelete(DeleteBehavior.NoAction);

        var user = new User
        {
            Id = "bb29d713-9414-43fa-9c8e-65fa6ee39243",
            FirstName = "Alice",
            LastName = "Smith",
            Address = "123 Main St",
            AvatarUri = "avatar1.png",
            Description = "desc1",
            Private = false,
            UserName = "alice.smith@example.com",
            NormalizedUserName = "ALICE.SMITH@EXAMPLE.COM",
            Email = "alice.smith@example.com",
            NormalizedEmail = "ALICE.SMITH@EXAMPLE.COM",
            EmailConfirmed = true,
            PasswordHash = "", // 123
            SecurityStamp = null,
            ConcurrencyStamp = null,
            PhoneNumber = null,
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = false,
            AccessFailedCount = 0
        };

        modelBuilder.Entity<User>().HasData(
            user
        );

        // Users
        //modelBuilder.Entity<User>().HasData(
        //    new User { Id = "a6e8482e-1d8a-4b7c-889b-bcd4ff3c9b1d", FirstName = "Bob", LastName = "Johnson", Address = "456 Oak Ave", Email = "bob@example.com", PasswordHash = "hash2", AvatarUri = "avatar2.png", Private = false },
        //    new User { Id = "c438f5e2-72fc-491d-9111-5e1229e77a73", FirstName = "Charlie", LastName = "Brown", Address = "789 Pine Blvd", Email = "charlie@example.com", PasswordHash = "hash3", AvatarUri = "avatar3.png", Private = true },
        //    new User { Id = "fe237f44-dff8-4d0d-99a6-8b56544d86e9", FirstName = "Diana", LastName = "White", Address = "321 Maple Ln", Email = "diana@example.com", PasswordHash = "hash4", AvatarUri = "avatar4.png", Private = false },
        //    new User { Id = "b254b7d9-00e4-4cd6-a1e4-8339f2d881c5", FirstName = "Eve", LastName = "Davis", Address = "654 Elm Dr", Email = "eve@example.com", PasswordHash = "hash5", AvatarUri = "avatar5.png", Private = true }
        //);

        //// Projects
        //modelBuilder.Entity<Project>().HasData(
        //    new Project { Id = 1, Title = "Project Alpha", Description = "A groundbreaking project.", Image = "image1.png", OwnerId = "d3f29f8c-5a1c-4b25-a05f-3e345d1e4b2e" },
        //    new Project { Id = 2, Title = "Project Beta", Description = "An innovative project.", Image = "image2.png", OwnerId = "a6e8482e-1d8a-4b7c-889b-bcd4ff3c9b1d" },
        //    new Project { Id = 3, Title = "Project Gamma", Description = "A creative project.", Image = "image3.png", OwnerId = "c438f5e2-72fc-491d-9111-5e1229e77a73" },
        //    new Project { Id = 4, Title = "Project Delta", Description = "A futuristic project.", Image = "image4.png", OwnerId = "fe237f44-dff8-4d0d-99a6-8b56544d86e9" },
        //    new Project { Id = 5, Title = "Project Epsilon", Description = "An advanced project.", Image = "image5.png", OwnerId = "b254b7d9-00e4-4cd6-a1e4-8339f2d881c5" }
        //);

        // Skills
        //modelBuilder.Entity<Skill>().HasData(
        //    new Skill { Id = 1, Title = "C#" },
        //    new Skill { Id = 2, Title = "JavaScript" },
        //    new Skill { Id = 3, Title = "Python" },
        //    new Skill { Id = 4, Title = "SQL" },
        //    new Skill { Id = 5, Title = "DevOps" }
        //);

        //// UserSkills
        //modelBuilder.Entity<UserSkill>().HasData(
        //    new UserSkill { UserId = "d3f29f8c-5a1c-4b25-a05f-3e345d1e4b2e", SkillId = 1 },
        //    new UserSkill { UserId = "a6e8482e-1d8a-4b7c-889b-bcd4ff3c9b1d", SkillId = 2 },
        //    new UserSkill { UserId = "c438f5e2-72fc-491d-9111-5e1229e77a73", SkillId = 3 },
        //    new UserSkill { UserId = "fe237f44-dff8-4d0d-99a6-8b56544d86e9", SkillId = 4 },
        //    new UserSkill { UserId = "b254b7d9-00e4-4cd6-a1e4-8339f2d881c5", SkillId = 5 }
        //);

        // QualificationTypes
        //modelBuilder.Entity<QualificationType>().HasData(
        //    new QualificationType { Id = 1, Name = "Bachelor's Degree" },
        //    new QualificationType { Id = 2, Name = "Master's Degree" },
        //    new QualificationType { Id = 3, Name = "Certification" },
        //    new QualificationType { Id = 4, Name = "Diploma" },
        //    new QualificationType { Id = 5, Name = "PhD" }
        //);

        //// Qualifications
        //modelBuilder.Entity<Qualification>().HasData(
        //    new Qualification { Id = 1, Title = "BSc Computer Science", Description = "4-year degree", StartDate = new DateOnly(2015, 9, 1), EndDate = new DateOnly(2019, 6, 30), UserId = "d3f29f8c-5a1c-4b25-a05f-3e345d1e4b2e", TypeId = 1 },
        //    new Qualification { Id = 2, Title = "MSc Software Engineering", Description = "2-year degree", StartDate = new DateOnly(2020, 9, 1), EndDate = new DateOnly(2022, 6, 30), UserId = "a6e8482e-1d8a-4b7c-889b-bcd4ff3c9b1d", TypeId = 2 },
        //    new Qualification { Id = 3, Title = "AWS Certification", Description = "Cloud computing certification", StartDate = new DateOnly(2021, 1, 1), EndDate = new DateOnly(2021, 12, 31), UserId = "c438f5e2-72fc-491d-9111-5e1229e77a73", TypeId = 3 },
        //    new Qualification { Id = 4, Title = "Diploma in Data Science", Description = "1-year program", StartDate = new DateOnly(2018, 9, 1), EndDate = new DateOnly(2019, 6, 30), UserId = "fe237f44-dff8-4d0d-99a6-8b56544d86e9", TypeId = 4 },
        //    new Qualification { Id = 5, Title = "PhD in Artificial Intelligence", Description = "Research-focused program", StartDate = new DateOnly(2016, 9, 1), EndDate = new DateOnly(2021, 6, 30), UserId = "b254b7d9-00e4-4cd6-a1e4-8339f2d881c5", TypeId = 5 }
        //);

        //// Messages
        //modelBuilder.Entity<Message>().HasData(
        //    new Message { Id = 1, SenderId = "d3f29f8c-5a1c-4b25-a05f-3e345d1e4b2e", ReceiverId = "a6e8482e-1d8a-4b7c-889b-bcd4ff3c9b1d", Text = "Hello Bob!", Read = false, CreatedAt = DateTime.UtcNow },
        //    new Message { Id = 2, SenderId = "a6e8482e-1d8a-4b7c-889b-bcd4ff3c9b1d", ReceiverId = "c438f5e2-72fc-491d-9111-5e1229e77a73", Text = "Hey Charlie!", Read = true, CreatedAt = DateTime.UtcNow },
        //    new Message { Id = 3, SenderId = "c438f5e2-72fc-491d-9111-5e1229e77a73", ReceiverId = "fe237f44-dff8-4d0d-99a6-8b56544d86e9", Text = "Hi Diana!", Read = false, CreatedAt = DateTime.UtcNow },
        //    new Message { Id = 4, SenderId = "fe237f44-dff8-4d0d-99a6-8b56544d86e9", ReceiverId = "b254b7d9-00e4-4cd6-a1e4-8339f2d881c5", Text = "Hello Eve!", Read = true, CreatedAt = DateTime.UtcNow },
        //    new Message { Id = 5, SenderId = "b254b7d9-00e4-4cd6-a1e4-8339f2d881c5", ReceiverId = "d3f29f8c-5a1c-4b25-a05f-3e345d1e4b2e", Text = "Hi Alice!", Read = false, CreatedAt = DateTime.UtcNow }
        //);
    }
}
