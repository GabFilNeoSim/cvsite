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


        string user1Email = "alice.smith@example.com";
        string user2Email = "bob.jones@example.com";
        string user3Email = "carla.davis@example.com";
        string user4Email = "david.lee@example.com";
        string user5Email = "emily.white@example.com";
        string user6Email = "frank.hall@example.com";

        var user1 = new User
        {
            Id = "bb29d713-9414-43fa-9c8e-65fa6ee39243",
            FirstName = "Alice",
            LastName = "Smith",
            Address = "123 Main St",
            AvatarUri = "avatar1.png",
            Description = "desc1",
            Private = false,
            UserName = user1Email,
            NormalizedUserName = user1Email.ToUpper(),
            Email = user1Email,
            NormalizedEmail = user1Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "",
            SecurityStamp = "",
            ConcurrencyStamp = null,
            PhoneNumber = null,
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = false,
            AccessFailedCount = 0
        };
        var user2 = new User
        {
            Id = "a1f2d713-1234-43fa-9c8e-65fa6ee39244",
            FirstName = "Bob",
            LastName = "Jones",
            Address = "456 Elm St",
            AvatarUri = "avatar2.png",
            Description = "desc2",
            Private = false,
            UserName = user2Email,
            NormalizedUserName = user2Email.ToUpper(),
            Email = user2Email,
            NormalizedEmail = user2Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "",
            SecurityStamp = "",
            ConcurrencyStamp = null,
            PhoneNumber = null,
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = false,
            AccessFailedCount = 0
        };
        var user3 = new User
        {
            Id = "c1f3d713-5678-43fa-9c8e-65fa6ee39245",
            FirstName = "Carla",
            LastName = "Davis",
            Address = "789 Oak St",
            AvatarUri = "avatar3.png",
            Description = "desc3",
            Private = false,
            UserName = user3Email,
            NormalizedUserName = user3Email.ToUpper(),
            Email = user3Email,
            NormalizedEmail = user3Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "",
            SecurityStamp = "",
            ConcurrencyStamp = null,
            PhoneNumber = null,
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = false,
            AccessFailedCount = 0
        };
        var user4 = new User
        {
            Id = "d1f4d713-9101-43fa-9c8e-65fa6ee39246",
            FirstName = "David",
            LastName = "Lee",
            Address = "321 Pine St",
            AvatarUri = "avatar4.png",
            Description = "desc4",
            Private = false,
            UserName = user4Email,
            NormalizedUserName = user4Email.ToUpper(),
            Email = user4Email,
            NormalizedEmail = user4Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "",
            SecurityStamp = "",
            ConcurrencyStamp = null,
            PhoneNumber = null,
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = false,
            AccessFailedCount = 0
        };
        var user5 = new User
        {
            Id = "e1f5d713-1122-43fa-9c8e-65fa6ee39247",
            FirstName = "Emily",
            LastName = "White",
            Address = "654 Birch St",
            AvatarUri = "avatar5.png",
            Description = "desc5",
            Private = false,
            UserName = user5Email,
            NormalizedUserName = user5Email.ToUpper(),
            Email = user5Email,
            NormalizedEmail = user5Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "",
            SecurityStamp = "",
            ConcurrencyStamp = null,
            PhoneNumber = null,
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = false,
            AccessFailedCount = 0
        };
        var user6 = new User
        {
            Id = "f1f6d713-3344-43fa-9c8e-65fa6ee39248",
            FirstName = "Frank",
            LastName = "Hall",
            Address = "987 Cedar St",
            AvatarUri = "avatar6.png",
            Description = "desc6",
            Private = false,
            UserName = user6Email,
            NormalizedUserName = user6Email.ToUpper(),
            Email = user6Email,
            NormalizedEmail = user6Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "",
            SecurityStamp = "",
            ConcurrencyStamp = null,
            PhoneNumber = null,
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = false,
            AccessFailedCount = 0
        };

        modelBuilder.Entity<User>().HasData(
            user1, user2, user3, user4, user5, user6
        );

        modelBuilder.Entity<Project>().HasData(
            new Project { Id = 1, Title = "Project Alpha", Description = "A groundbreaking project.", Image = "image1.png", OwnerId = user1.Id },
            new Project { Id = 2, Title = "Project Beta", Description = "Another amazing project.", Image = "image2.png", OwnerId = user2.Id },
            new Project { Id = 3, Title = "Project Gamma", Description = "Innovative and creative.", Image = "image3.png", OwnerId = user3.Id }
        );

        modelBuilder.Entity<UserProject>().HasData(
            new { UserId = user1.Id, ProjectId = 1 },
            new { UserId = user2.Id, ProjectId = 2 },
            new { UserId = user3.Id, ProjectId = 3 },
            new { UserId = user5.Id, ProjectId = 1 },
            new { UserId = user1.Id, ProjectId = 2 },
            new { UserId = user4.Id, ProjectId = 3 },
            new { UserId = user3.Id, ProjectId = 1 },
            new { UserId = user4.Id, ProjectId = 2 }
        );

        modelBuilder.Entity<Skill>().HasData(
            new Skill { Id = 1, Title = "C#" },
            new Skill { Id = 2, Title = "JavaScript" },
            new Skill { Id = 3, Title = "Python" },
            new Skill { Id = 4, Title = "SQL" },
            new Skill { Id = 5, Title = "DevOps" }
        );

        modelBuilder.Entity<UserSkill>().HasData(
            new UserSkill { UserId = user1.Id, SkillId = 1 },
            new UserSkill { UserId = user2.Id, SkillId = 2 },
            new UserSkill { UserId = user3.Id, SkillId = 3 },
            new UserSkill { UserId = user4.Id, SkillId = 4 },
            new UserSkill { UserId = user5.Id, SkillId = 5 },
            new UserSkill { UserId = user6.Id, SkillId = 1 }
        );

        modelBuilder.Entity<QualificationType>().HasData(
            new QualificationType { Id = 1, Name = "Education" },
            new QualificationType { Id = 2, Name = "Work" }
        );

        modelBuilder.Entity<Qualification>().HasData(
            new Qualification { Id = 1, Title = "Kandidat inom systemutveckling", Description = "3 årig kandidatexamen inom systemuveckling", Location = "Örebro Universitet", StartDate = new DateOnly(2015, 9, 1), EndDate = new DateOnly(2019, 6, 30), UserId = user1.Id, TypeId = 1 },
            new Qualification { Id = 2, Title = "MSc Software Engineering", Description = "2-year degree", StartDate = new DateOnly(2020, 9, 1), Location = "Seoul Food market", EndDate = new DateOnly(2022, 6, 30), UserId = user1.Id, TypeId = 1 },
            new Qualification { Id = 3, Title = "Medarbetare", Description = "Städare på donken.", StartDate = new DateOnly(2021, 1, 1), Location = "Mcdonalds", EndDate = new DateOnly(2021, 12, 31), UserId = user1.Id, TypeId = 2 },
            new Qualification { Id = 4, Title = "Web Development Bootcamp", Description = "Intensive 12-week course on modern web development.", Location = "Borlänge kommun", StartDate = new DateOnly(2018, 3, 1), EndDate = new DateOnly(2018, 5, 31), UserId = user2.Id, TypeId = 1 },
            new Qualification { Id = 5, Title = "PhD in Data Science", Description = "Doctoral degree focusing on big data analysis and AI.", Location = "Vretstorps värdshus", StartDate = new DateOnly(2016, 9, 1), EndDate = new DateOnly(2021, 6, 30), UserId = user3.Id, TypeId = 1 },
            new Qualification { Id = 6, Title = "Project Management Professional (PMP)", Description = "Professional certification for project managers. Galeeeet stooooor.", Location = "Harvard University", StartDate = new DateOnly(2020, 1, 1), EndDate = new DateOnly(2020, 12, 31), UserId = user4.Id, TypeId = 2 },
            new Qualification { Id = 7, Title = "Certificate in Cybersecurity", Description = "1-year certification program focusing on cybersecurity fundamentals. Du får en tia om du visar kuken.", Location = "Neos pappas jobb", StartDate = new DateOnly(2019, 9, 1), EndDate = new DateOnly(2020, 6, 30), UserId = user5.Id, TypeId = 2 },
            new Qualification { Id = 8, Title = "BSc in Information Technology", Description = "Undergraduate degree in IT with a focus on networking.", Location = "Lunds Universitet", StartDate = new DateOnly(2013, 9, 1), EndDate = new DateOnly(2016, 6, 30), UserId = user1.Id, TypeId = 1 },
            new Qualification { Id = 9, Title = "Data Analyst Internship", Description = "Internship focusing on data cleaning, visualization, and analysis. Filip luktar kiss", Location = "Google", StartDate = new DateOnly(2022, 5, 1), EndDate = new DateOnly(2022, 8, 31), UserId = user2.Id, TypeId = 2 }
        );

        modelBuilder.Entity<Message>().HasData(
            new Message { Id = 1, SenderId = user1.Id, ReceiverId = user2.Id, Text = "Hello Bob!", Read = false, CreatedAt = new DateTime(2024, 12, 23) },
            new Message { Id = 2, SenderId = user2.Id, ReceiverId = user3.Id, Text = "Hi Carla!", Read = false, CreatedAt = new DateTime(2024, 12, 24) }
        );
    }
}
