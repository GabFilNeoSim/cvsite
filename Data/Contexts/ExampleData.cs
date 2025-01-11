using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Contexts;

public partial class AppDbContext : IdentityDbContext<User>
{
    private static void LoadExampleData(ModelBuilder modelBuilder)
    {
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
            AvatarUri = "a2138670-ffb4-466c-b40c-44dde76566ed.jpg",
            Description = "Senior Backend Developer with expertise in C#, Python, and DevOps.",
            Private = false,
            VisitCount = 11,
            UserName = user1Email,
            NormalizedUserName = user1Email.ToUpper(),
            Email = user1Email,
            NormalizedEmail = user1Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEG719JW0JH1H9VQgj8uzgJ4HLJ+/2qP7NjjLeDMIku1+rtQT16BvU3uracoab0E0Gg==", // 12345
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
            AvatarUri = "d10ae3ea-a55c-4d4a-8191-2f28ba82dc33.jpg",
            Description = "Senior Frontend Developer with a focus on JavaScript, React, and AI.",
            Private = false,
            VisitCount = 7,
            UserName = user2Email,
            NormalizedUserName = user2Email.ToUpper(),
            Email = user2Email,
            NormalizedEmail = user2Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEG719JW0JH1H9VQgj8uzgJ4HLJ+/2qP7NjjLeDMIku1+rtQT16BvU3uracoab0E0Gg==", // 12345
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
            AvatarUri = "f5069b20-908a-4207-bebf-d1dab2ebc8a2.jpg",
            Description = "Senior DevOps Engineer with experience in automation and cybersecurity.",
            Private = true,
            VisitCount = 3,
            UserName = user3Email,
            NormalizedUserName = user3Email.ToUpper(),
            Email = user3Email,
            NormalizedEmail = user3Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEG719JW0JH1H9VQgj8uzgJ4HLJ+/2qP7NjjLeDMIku1+rtQT16BvU3uracoab0E0Gg==", // 12345
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
            AvatarUri = "93bf8ebe-0f12-41bf-8fbe-c69a9a44b176.jpg",
            Description = "Lead Security Engineer with expertise in IT security and network design.",
            Private = false,
            VisitCount = 9,
            UserName = user4Email,
            NormalizedUserName = user4Email.ToUpper(),
            Email = user4Email,
            NormalizedEmail = user4Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEG719JW0JH1H9VQgj8uzgJ4HLJ+/2qP7NjjLeDMIku1+rtQT16BvU3uracoab0E0Gg==", // 12345
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
            AvatarUri = "58c185e2-0754-4499-8f24-c2463e7753e2.jpg",
            Description = "Senior Backend Developer with experience in Python and API development.",
            Private = false,
            VisitCount = 5,
            UserName = user5Email,
            NormalizedUserName = user5Email.ToUpper(),
            Email = user5Email,
            NormalizedEmail = user5Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEG719JW0JH1H9VQgj8uzgJ4HLJ+/2qP7NjjLeDMIku1+rtQT16BvU3uracoab0E0Gg==", // 12345
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
            AvatarUri = "8abcbe76-a51d-4f29-8baf-321e6de65fb3.jpg",
            Description = "Tech Lead with experience in Fullstack development and system design.",
            Private = false,
            VisitCount = 14,
            UserName = user6Email,
            NormalizedUserName = user6Email.ToUpper(),
            Email = user6Email,
            NormalizedEmail = user6Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEG719JW0JH1H9VQgj8uzgJ4HLJ+/2qP7NjjLeDMIku1+rtQT16BvU3uracoab0E0Gg==", // 12345
            SecurityStamp = "",
            ConcurrencyStamp = null,
            PhoneNumber = null,
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = false,
            AccessFailedCount = 0
        };

        // Insert users
        modelBuilder.Entity<User>().HasData(
            user1, user2, user3, user4, user5, user6
        );

        // Insert projects
        modelBuilder.Entity<Project>().HasData(
            new Project { Id = 1, Title = "Digital Transformation", Description = "A project to digitize company processes.", OwnerId = user1.Id, CreatedAt = new DateTime(2024, 12, 23) },
            new Project { Id = 2, Title = "E-commerce Platform Revamp", Description = "Redesigning the platform to improve user experience and increase sales.", OwnerId = user2.Id, CreatedAt = new DateTime(2024, 12, 21) },
            new Project { Id = 3, Title = "AI Chatbot Development", Description = "Developing an AI-based chatbot for customer support.", OwnerId = user3.Id, CreatedAt = new DateTime(2024, 12, 20) },
            new Project { Id = 4, Title = "Mobile App Redesign", Description = "Redesigning the mobile app interface for better accessibility and performance.", OwnerId = user4.Id, CreatedAt = new DateTime(2024, 12, 19) },
            new Project { Id = 5, Title = "Data Warehouse Migration", Description = "Migrating data from legacy systems to a new data warehouse for improved analytics.", OwnerId = user5.Id, CreatedAt = new DateTime(2024, 12, 18) },
            new Project { Id = 6, Title = "Cloud Infrastructure Optimization", Description = "Optimizing cloud infrastructure to reduce costs and improve efficiency.", OwnerId = user6.Id, CreatedAt = new DateTime(2024, 12, 17) },
            new Project { Id = 7, Title = "Sustainability Initiative", Description = "Implementing eco-friendly practices and reducing the company's carbon footprint.", OwnerId = user1.Id, CreatedAt = new DateTime(2024, 12, 16) },
            new Project { Id = 8, Title = "Cybersecurity Overhaul", Description = "Enhancing the company's cybersecurity measures to protect against growing threats.", OwnerId = user2.Id, CreatedAt = new DateTime(2024, 12, 15) },
            new Project { Id = 9, Title = "Employee Training Platform", Description = "Building a platform for employee skill development and training resources.", OwnerId = user3.Id, CreatedAt = new DateTime(2024, 12, 14) },
            new Project { Id = 10, Title = "Customer Relationship Management", Description = "Developing a CRM system to improve customer interaction and retention.", OwnerId = user4.Id, CreatedAt = new DateTime(2024, 12, 13) }
        );


        // Insert user and project relationships
        modelBuilder.Entity<UserProject>().HasData(
            new { UserId = user1.Id, ProjectId = 1 },
            new { UserId = user2.Id, ProjectId = 1 },
            new { UserId = user3.Id, ProjectId = 1 },
            new { UserId = user4.Id, ProjectId = 1 },
            new { UserId = user5.Id, ProjectId = 1 },
            new { UserId = user6.Id, ProjectId = 1 },

            new { UserId = user1.Id, ProjectId = 2 },
            new { UserId = user2.Id, ProjectId = 2 },
            new { UserId = user4.Id, ProjectId = 2 },

            new { UserId = user1.Id, ProjectId = 3 },
            new { UserId = user3.Id, ProjectId = 3 },
            new { UserId = user5.Id, ProjectId = 3 },

            new { UserId = user2.Id, ProjectId = 4 },
            new { UserId = user4.Id, ProjectId = 4 },
            new { UserId = user6.Id, ProjectId = 4 },

            new { UserId = user3.Id, ProjectId = 5 },
            new { UserId = user5.Id, ProjectId = 5 },

            new { UserId = user2.Id, ProjectId = 6 },
            new { UserId = user4.Id, ProjectId = 6 },
            new { UserId = user6.Id, ProjectId = 6 },

            new { UserId = user1.Id, ProjectId = 7 },
            new { UserId = user3.Id, ProjectId = 7 },
            new { UserId = user6.Id, ProjectId = 7 },

            new { UserId = user2.Id, ProjectId = 8 },
            new { UserId = user5.Id, ProjectId = 8 },

            new { UserId = user1.Id, ProjectId = 9 },
            new { UserId = user3.Id, ProjectId = 9 },
            new { UserId = user4.Id, ProjectId = 9 },

            new { UserId = user4.Id, ProjectId = 10 },
            new { UserId = user6.Id, ProjectId = 10 }
        );


        // Insert skills
        modelBuilder.Entity<Skill>().HasData(
            new Skill { Id = 1, Title = "C#" },
            new Skill { Id = 2, Title = "JavaScript" },
            new Skill { Id = 3, Title = "Python" },
            new Skill { Id = 4, Title = "SQL" },
            new Skill { Id = 5, Title = "DevOps" },
            new Skill { Id = 6, Title = "HTML/CSS" },
            new Skill { Id = 7, Title = "React" },
            new Skill { Id = 8, Title = "ASP.NET" },
            new Skill { Id = 9, Title = "Angular" },
            new Skill { Id = 10, Title = "Java" },
            new Skill { Id = 11, Title = "Cybersecurity" },
            new Skill { Id = 12, Title = "Node.js" },
            new Skill { Id = 13, Title = "TypeScript" },
            new Skill { Id = 14, Title = "Docker" },
            new Skill { Id = 15, Title = "Kubernetes" },
            new Skill { Id = 16, Title = "CSS" },
            new Skill { Id = 17, Title = "Ruby" },
            new Skill { Id = 18, Title = "Swift" },
            new Skill { Id = 19, Title = "Terraform" },
            new Skill { Id = 20, Title = "GraphQL" },
            new Skill { Id = 21, Title = "AWS" },
            new Skill { Id = 22, Title = "Azure" },
            new Skill { Id = 23, Title = "Git" },
            new Skill { Id = 24, Title = "Jenkins" }
        );


        // Insert user and skill relationships
        modelBuilder.Entity<UserSkill>().HasData(
            new { UserId = user1.Id, SkillId = 1 },
            new { UserId = user1.Id, SkillId = 2 },
            new { UserId = user1.Id, SkillId = 3 },
            new { UserId = user1.Id, SkillId = 4 },
            new { UserId = user1.Id, SkillId = 5 },
            new { UserId = user1.Id, SkillId = 6 },
            new { UserId = user1.Id, SkillId = 7 },
            new { UserId = user1.Id, SkillId = 8 },
            new { UserId = user1.Id, SkillId = 14 },
            new { UserId = user1.Id, SkillId = 15 },

            new { UserId = user2.Id, SkillId = 2 },
            new { UserId = user2.Id, SkillId = 4 },
            new { UserId = user2.Id, SkillId = 6 },
            new { UserId = user2.Id, SkillId = 7 },
            new { UserId = user2.Id, SkillId = 9 },
            new { UserId = user2.Id, SkillId = 12 },
            new { UserId = user2.Id, SkillId = 13 },

            new { UserId = user3.Id, SkillId = 1 },
            new { UserId = user3.Id, SkillId = 3 },
            new { UserId = user3.Id, SkillId = 4 },
            new { UserId = user3.Id, SkillId = 14 },
            new { UserId = user3.Id, SkillId = 11 },

            new { UserId = user4.Id, SkillId = 1 },
            new { UserId = user4.Id, SkillId = 4 },
            new { UserId = user4.Id, SkillId = 6 },
            new { UserId = user4.Id, SkillId = 7 },
            new { UserId = user4.Id, SkillId = 8 },
            new { UserId = user4.Id, SkillId = 9 },
            new { UserId = user4.Id, SkillId = 16 },

            new { UserId = user5.Id, SkillId = 3 },
            new { UserId = user5.Id, SkillId = 8 },
            new { UserId = user5.Id, SkillId = 14 },
            new { UserId = user5.Id, SkillId = 19 },

            new { UserId = user6.Id, SkillId = 2 },
            new { UserId = user6.Id, SkillId = 3 },
            new { UserId = user6.Id, SkillId = 4 },
            new { UserId = user6.Id, SkillId = 5 },
            new { UserId = user6.Id, SkillId = 6 },
            new { UserId = user6.Id, SkillId = 7 },
            new { UserId = user6.Id, SkillId = 12 },
            new { UserId = user6.Id, SkillId = 14 },
            new { UserId = user6.Id, SkillId = 15 },
            new { UserId = user6.Id, SkillId = 16 },
            new { UserId = user6.Id, SkillId = 19 },
            new { UserId = user6.Id, SkillId = 23 },
            new { UserId = user6.Id, SkillId = 24 }
        );

        // Insert qualification types
        modelBuilder.Entity<QualificationType>().HasData(
            new QualificationType { Id = 1, Name = "Education" },
            new QualificationType { Id = 2, Name = "Work" }
        );

        // Insert qualifications
        modelBuilder.Entity<Qualification>().HasData(
           new Qualification { Id = 1, Title = "High School Degree in the Economics Program", Description = "Focus on Business Economics", Location = "Jensen High School", StartDate = new DateOnly(2012, 9, 1), EndDate = new DateOnly(2015, 6, 30), UserId = user1.Id, TypeId = 1 },
           new Qualification { Id = 2, Title = "Bachelor's Degree in System Development", Description = "3-year Bachelor's degree in system development", Location = "Örebro University", StartDate = new DateOnly(2015, 9, 1), EndDate = new DateOnly(2019, 6, 30), UserId = user1.Id, TypeId = 1 },
           new Qualification { Id = 3, Title = "System Developer", Description = "Worked as a system developer with a focus on backend development.", Location = "TechCorp", StartDate = new DateOnly(2019, 7, 1), EndDate = new DateOnly(2022, 12, 31), UserId = user1.Id, TypeId = 2 },
           new Qualification { Id = 4, Title = "Senior Backend Developer", Description = "Led the development of server solutions and database structure.", Location = "CloudTech", StartDate = new DateOnly(2023, 1, 1), EndDate = null, UserId = user1.Id, TypeId = 2 },

           new Qualification { Id = 5, Title = "High School Degree in Natural Sciences", Description = "Focus on mathematics and natural sciences", Location = "London Academy", StartDate = new DateOnly(2013, 9, 1), EndDate = new DateOnly(2016, 6, 30), UserId = user2.Id, TypeId = 1 },
           new Qualification { Id = 6, Title = "Master's in Computer Science", Description = "2-year Master's program in Computer Science with a focus on AI", Location = "Harvard University", StartDate = new DateOnly(2017, 8, 1), EndDate = new DateOnly(2019, 6, 30), UserId = user2.Id, TypeId = 1 },
           new Qualification { Id = 7, Title = "Frontend Developer", Description = "Worked on developing user interfaces and interactivity.", Location = "Web Solutions", StartDate = new DateOnly(2019, 8, 1), EndDate = new DateOnly(2021, 5, 31), UserId = user2.Id, TypeId = 2 },
           new Qualification { Id = 8, Title = "Senior Frontend Developer", Description = "Led the frontend team in the development of dynamic web pages.", Location = "NextGen Web", StartDate = new DateOnly(2021, 6, 1), EndDate = null, UserId = user2.Id, TypeId = 2 },

           new Qualification { Id = 9, Title = "High School Degree in Engineering Program", Description = "Focus on IT and programming", Location = "Oxford High School", StartDate = new DateOnly(2013, 9, 1), EndDate = new DateOnly(2016, 6, 30), UserId = user3.Id, TypeId = 1 },
           new Qualification { Id = 10, Title = "Bachelor's Degree in Software Development", Description = "3-year Bachelor's degree in software development", Location = "University of California", StartDate = new DateOnly(2016, 9, 1), EndDate = new DateOnly(2019, 6, 30), UserId = user3.Id, TypeId = 1 },
           new Qualification { Id = 11, Title = "DevOps Engineer", Description = "Worked as a DevOps Engineer with a focus on automation and CI/CD pipelines.", Location = "CloudTech", StartDate = new DateOnly(2019, 7, 1), EndDate = new DateOnly(2022, 12, 31), UserId = user3.Id, TypeId = 2 },
           new Qualification { Id = 12, Title = "Senior DevOps Engineer", Description = "Led CI/CD projects and developed efficient build and deploy solutions.", Location = "NextGen Cloud", StartDate = new DateOnly(2023, 1, 1), EndDate = null, UserId = user3.Id, TypeId = 2 },

           new Qualification { Id = 13, Title = "High School Degree in Network Engineering Program", Description = "Focus on network technology and security", Location = "Swiss Technical Academy", StartDate = new DateOnly(2012, 9, 1), EndDate = new DateOnly(2015, 6, 30), UserId = user4.Id, TypeId = 1 },
           new Qualification { Id = 14, Title = "Master's in IT Security", Description = "Master's degree in IT security and network design", Location = "ETH Zurich", StartDate = new DateOnly(2016, 9, 1), EndDate = new DateOnly(2018, 6, 30), UserId = user4.Id, TypeId = 1 },
           new Qualification { Id = 15, Title = "IT Security Specialist", Description = "Worked as an IT security specialist with a focus on penetration testing and vulnerability assessments.", Location = "SecureTech", StartDate = new DateOnly(2018, 7, 1), EndDate = new DateOnly(2022, 5, 31), UserId = user4.Id, TypeId = 2 },
           new Qualification { Id = 16, Title = "Lead Security Engineer", Description = "Led security measures at the enterprise level, including vulnerability management and security audits.", Location = "CyberSafe", StartDate = new DateOnly(2022, 6, 1), EndDate = null, UserId = user4.Id, TypeId = 2 },

           new Qualification { Id = 17, Title = "High School Degree in IT and Network Program", Description = "Focus on IT and networking", Location = "University of Melbourne", StartDate = new DateOnly(2012, 9, 1), EndDate = new DateOnly(2015, 6, 30), UserId = user5.Id, TypeId = 1 },
           new Qualification { Id = 18, Title = "Bachelor's Degree in Computer Engineering", Description = "3-year Bachelor's degree in computer engineering", Location = "University of Sydney", StartDate = new DateOnly(2016, 9, 1), EndDate = new DateOnly(2019, 6, 30), UserId = user5.Id, TypeId = 1 },
           new Qualification { Id = 19, Title = "Backend Developer", Description = "Worked as a backend developer with a focus on database design and server management.", Location = "CodeFactory", StartDate = new DateOnly(2019, 7, 1), EndDate = new DateOnly(2021, 12, 31), UserId = user5.Id, TypeId = 2 },
           new Qualification { Id = 20, Title = "Senior Backend Developer", Description = "Worked as a senior backend developer and led the development of APIs.", Location = "DataTech", StartDate = new DateOnly(2022, 1, 1), EndDate = null, UserId = user5.Id, TypeId = 2 },

           new Qualification { Id = 21, Title = "High School Degree in Engineering Program", Description = "Focus on IT and programming", Location = "MIT High School", StartDate = new DateOnly(2012, 9, 1), EndDate = new DateOnly(2015, 6, 30), UserId = user6.Id, TypeId = 1 },
           new Qualification { Id = 22, Title = "Bachelor's Degree in IT and Programming", Description = "3-year Bachelor's degree in IT and programming", Location = "University of Amsterdam", StartDate = new DateOnly(2014, 9, 1), EndDate = new DateOnly(2017, 6, 30), UserId = user6.Id, TypeId = 1 },
           new Qualification { Id = 23, Title = "Master's in Software Engineering", Description = "2-year Master's program in software engineering with a focus on system design and architecture", Location = "University of Cambridge", StartDate = new DateOnly(2017, 8, 1), EndDate = new DateOnly(2019, 6, 30), UserId = user6.Id, TypeId = 1 },
           new Qualification { Id = 24, Title = "Fullstack Developer", Description = "Worked as a Fullstack Developer focusing on both frontend and backend", Location = "Tech Innovators", StartDate = new DateOnly(2019, 7, 1), EndDate = new DateOnly(2021, 12, 31), UserId = user6.Id, TypeId = 2 },
           new Qualification { Id = 25, Title = "Tech Lead", Description = "Led the development team for a major fintech system project.", Location = "Fintech Solutions", StartDate = new DateOnly(2022, 1, 1), EndDate = null, UserId = user6.Id, TypeId = 2 }
        );

        // Insert messages
        modelBuilder.Entity<Message>().HasData(
            // Användare 1 (user1) skickar meddelanden
            new Message { Id = 1, SenderId = user1.Id, ReceiverId = user2.Id, Text = "Hello Bob! How's everything?", Read = false, CreatedAt = new DateTime(2024, 12, 23) },
            new Message { Id = 2, SenderId = user1.Id, ReceiverId = user3.Id, Text = "Hey Alice, do you need help with the project?", Read = true, CreatedAt = new DateTime(2024, 12, 24) },
            new Message { Id = 3, SenderId = user1.Id, ReceiverId = user6.Id, Text = "Hi, do you have time to review the backend code?", Read = true, CreatedAt = new DateTime(2024, 12, 25) },

            // Användare 2 (user2) skickar meddelanden
            new Message { Id = 4, SenderId = user2.Id, ReceiverId = user1.Id, Text = "Hi Alice, I all is good with me. I'm trying to learn a new skill. What about you?", Read = true, CreatedAt = new DateTime(2024, 12, 23) },
            new Message { Id = 5, SenderId = user2.Id, ReceiverId = user3.Id, Text = "Alice, I need some help with the integration tests. Can you assist?", Read = false, CreatedAt = new DateTime(2024, 12, 24) },  // Läses senare av user3
            new Message { Id = 6, SenderId = user2.Id, ReceiverId = user6.Id, Text = "Can you help me with the frontend issue?", Read = true, CreatedAt = new DateTime(2024, 12, 26) },

            // Användare 3 (user3) skickar meddelanden
            new Message { Id = 7, SenderId = user3.Id, ReceiverId = user1.Id, Text = "Hi John, I reviewed your code. Looks great!", Read = false, CreatedAt = new DateTime(2024, 12, 23) },
            new Message { Id = 8, SenderId = user3.Id, ReceiverId = user2.Id, Text = "Sure, I can help you with the tests. When are you free?", Read = true, CreatedAt = new DateTime(2024, 12, 24) },
            new Message { Id = 9, SenderId = user3.Id, ReceiverId = user5.Id, Text = "I found a bug in the API. Can you check it?", Read = false, CreatedAt = new DateTime(2024, 12, 25) },

            // Användare 4 (user4) skickar meddelanden
            new Message { Id = 10, SenderId = user4.Id, ReceiverId = user6.Id, Text = "Can you help me with the firewall configuration?", Read = true, CreatedAt = new DateTime(2024, 12, 25) },
            new Message { Id = 11, SenderId = user4.Id, ReceiverId = user3.Id, Text = "I need your input on the security design. When are you free?", Read = true, CreatedAt = new DateTime(2024, 12, 26) },
            new Message { Id = 12, SenderId = user4.Id, ReceiverId = user5.Id, Text = "Let's discuss the new security policy. Are you available?", Read = false, CreatedAt = new DateTime(2024, 12, 28) },

            // Användare 5 (user5) skickar meddelanden
            new Message { Id = 13, SenderId = user5.Id, ReceiverId = user3.Id, Text = "Hi Alice, did you finish the testing?", Read = true, CreatedAt = new DateTime(2024, 12, 24) },
            new Message { Id = 14, SenderId = user5.Id, ReceiverId = user4.Id, Text = "Can we review the project specs? Need your feedback.", Read = true, CreatedAt = new DateTime(2024, 12, 27) },
            new Message { Id = 15, SenderId = user5.Id, ReceiverId = user6.Id, Text = "Let's sync up on the backend work tomorrow.", Read = false, CreatedAt = new DateTime(2024, 12, 23) },

            // Användare 6 (user6) skickar meddelanden
            new Message { Id = 16, SenderId = user6.Id, ReceiverId = user5.Id, Text = "Sure, I'll review the code this afternoon.", Read = true, CreatedAt = new DateTime(2024, 12, 24) },
            new Message { Id = 17, SenderId = user6.Id, ReceiverId = user2.Id, Text = "Hi Bob, let's plan the release for next week.", Read = false, CreatedAt = new DateTime(2024, 12, 26) },  // Inte läst av user2 än
            new Message { Id = 18, SenderId = user6.Id, ReceiverId = user4.Id, Text = "I have some questions about the latest security audit. Can we talk?", Read = true, CreatedAt = new DateTime(2024, 12, 27) },
            new Message { Id = 19, SenderId = user6.Id, ReceiverId = user1.Id, Text = "John, I saw your email. Let's discuss in the afternoon.", Read = false, CreatedAt = new DateTime(2024, 12, 28) }  // Inte läst av user1 än
        );
    }
}
