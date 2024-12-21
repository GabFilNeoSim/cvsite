using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Contexts;

public partial class AppDbContext : IdentityDbContext<User>
{
    protected void LoadExampleData(ModelBuilder modelBuilder)
    {
        var userGuids = new[]
        {
            Guid.NewGuid().ToString(), // Alice
            Guid.NewGuid().ToString(), // Bob
            Guid.NewGuid().ToString(), // Charlie
            Guid.NewGuid().ToString(), // Diana
            Guid.NewGuid().ToString()  // Eve
        };

        modelBuilder.Entity<User>().HasData(
            new User { Id = "1", FirstName = "Alice", LastName = "Anderson", Address = "123 Maple St", Email = "alice@example.com", UserName = "alice@example.com", NormalizedUserName = "ALICE@EXAMPLE.COM", Private = false },
            new User { Id = "2", FirstName = "Bob", LastName = "Brown", Address = "456 Oak Ave", Email = "bob@example.com", UserName = "bob@example.com", NormalizedUserName = "BOB@EXAMPLE.COM", Private = true },
            new User { Id = "3", FirstName = "Charlie", LastName = "Clark", Address = "789 Pine Rd", Email = "charlie@example.com", UserName = "charlie@example.com", NormalizedUserName = "CHARLIE@EXAMPLE.COM", Private = false },
            new User { Id = "4", FirstName = "Diana", LastName = "Davis", Address = "321 Cedar St", Email = "diana@example.com", UserName = "diana@example.com", NormalizedUserName = "DIANA@EXAMPLE.COM", Private = true },
            new User { Id = "5", FirstName = "Eve", LastName = "Evans", Address = "654 Birch Ln", Email = "eve@example.com", UserName = "eve@example.com", NormalizedUserName = "EVE@EXAMPLE.COM", Private = false }
        );

        modelBuilder.Entity<Project>().HasData(
            new Project { Id = 1, Title = "AI Research", Description = "Exploring applications of AI in healthcare.", Image = "ai_research.jpg", OwnerId = "1" },
            new Project { Id = 2, Title = "Open Source Library", Description = "A library to simplify database access.", Image = "opensource.jpg", OwnerId = "2" },
            new Project { Id = 3, Title = "Game Development", Description = "Developing an indie game.", Image = "indie_game.jpg", OwnerId = "3" },
            new Project { Id = 4, Title = "E-commerce Platform", Description = "Building an online marketplace.", Image = "ecommerce.jpg", OwnerId = "4" },
            new Project { Id = 5, Title = "Data Visualization Tool", Description = "Creating tools for visualizing large datasets.", Image = "dataviz.jpg", OwnerId = "5" }
        );

        modelBuilder.Entity<Skill>().HasData(
            new Skill { Id = 1, Title = "C#" },
            new Skill { Id = 2, Title = "Python" },
            new Skill { Id = 3, Title = "JavaScript" },
            new Skill { Id = 4, Title = "SQL" },
            new Skill { Id = 5, Title = "Machine Learning" }
        );

        modelBuilder.Entity<QualificationType>().HasData(
            new QualificationType { Id = 1, Name = "Education" },
            new QualificationType { Id = 2, Name = "Certification" },
            new QualificationType { Id = 3, Name = "Workshop" },
            new QualificationType { Id = 4, Name = "Training" }
        );

        modelBuilder.Entity<Qualification>().HasData(
            new Qualification { Id = 1, Title = "Bachelor's Degree", Description = "Bachelor's in Computer Science.", StartDate = new DateOnly(2015, 9, 1), EndDate = new DateOnly(2019, 6, 30), TypeId = 1, UserId = "1" },
            new Qualification { Id = 2, Title = "AWS Certified Developer", Description = "Amazon Web Services Developer Certification.", StartDate = new DateOnly(2021, 3, 15), TypeId = 2, UserId = "2" },
            new Qualification { Id = 3, Title = "JavaScript Workshop", Description = "Advanced JavaScript training.", StartDate = new DateOnly(2020, 5, 10), EndDate = new DateOnly(2020, 5, 15), TypeId = 3, UserId = "3" }
        );

        modelBuilder.Entity<Message>().HasData(
            new Message { Id = 1, Text = "Hi Bob, can you share the report?", Read = false, CreatedAt = DateTime.UtcNow.AddDays(-2), SenderId = "1", ReceiverId = "2", AnonymousName = "Anonymous" },
            new Message { Id = 2, Text = "Sure, I'll send it over shortly.", Read = true, CreatedAt = DateTime.UtcNow.AddDays(-1), SenderId = "2", ReceiverId = "1", AnonymousName = "Anonymous" },
            new Message { Id = 3, Text = "Hey Alice, can we collaborate on the AI project?", Read = false, CreatedAt = DateTime.UtcNow, SenderId = "3", ReceiverId = "1", AnonymousName = "Anonymous" }
        );

        modelBuilder.Entity("SkillUser").HasData(
            new { SkillsId = 1, UsersId = userGuids[0] },
            new { SkillsId = 2, UsersId = userGuids[1] },
            new { SkillsId = 3, UsersId = userGuids[2] },
            new { SkillsId = 4, UsersId = userGuids[3] },
            new { SkillsId = 5, UsersId = userGuids[4] }
        );

        modelBuilder.Entity("UserProjects").HasData(
                new { ProjectsId = 1, UsersId = userGuids[0] },
                new { ProjectsId = 2, UsersId = userGuids[1] },
                new { ProjectsId = 3, UsersId = userGuids[2] },
                new { ProjectsId = 4, UsersId = userGuids[3] },
                new { ProjectsId = 5, UsersId = userGuids[4] }
        );
}
}
