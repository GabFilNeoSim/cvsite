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
            Description = "Senior Backend Developer med expertis inom C#, Python och DevOps.",
            Private = false,
            UserName = user1Email,
            NormalizedUserName = user1Email.ToUpper(),
            Email = user1Email,
            NormalizedEmail = user1Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEG719JW0JH1H9VQgj8uzgJ4HLJ+/2qP7NjjLeDMIku1+rtQT16BvU3uracoab0E0Gg==",
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
            Description = "Senior Frontend Developer med fokus på JavaScript, React och AI.",
            Private = false,
            UserName = user2Email,
            NormalizedUserName = user2Email.ToUpper(),
            Email = user2Email,
            NormalizedEmail = user2Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEG719JW0JH1H9VQgj8uzgJ4HLJ+/2qP7NjjLeDMIku1+rtQT16BvU3uracoab0E0Gg==",
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
            Description = "Senior DevOps Engineer med erfarenhet av automation och Cybersecurity.",
            Private = true,
            UserName = user3Email,
            NormalizedUserName = user3Email.ToUpper(),
            Email = user3Email,
            NormalizedEmail = user3Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEG719JW0JH1H9VQgj8uzgJ4HLJ+/2qP7NjjLeDMIku1+rtQT16BvU3uracoab0E0Gg==",
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
            Description = "Lead Security Engineer med expertis inom IT-säkerhet och nätverksdesign.",
            Private = false,
            UserName = user4Email,
            NormalizedUserName = user4Email.ToUpper(),
            Email = user4Email,
            NormalizedEmail = user4Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEG719JW0JH1H9VQgj8uzgJ4HLJ+/2qP7NjjLeDMIku1+rtQT16BvU3uracoab0E0Gg==",
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
            Description = "Senior Backend Developer med erfarenhet av Python och API-utveckling.",
            Private = false,
            UserName = user5Email,
            NormalizedUserName = user5Email.ToUpper(),
            Email = user5Email,
            NormalizedEmail = user5Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEG719JW0JH1H9VQgj8uzgJ4HLJ+/2qP7NjjLeDMIku1+rtQT16BvU3uracoab0E0Gg==",
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
            Description = "Tech Lead med erfarenhet av Fullstack-utveckling och systemdesign.",
            Private = false,
            UserName = user6Email,
            NormalizedUserName = user6Email.ToUpper(),
            Email = user6Email,
            NormalizedEmail = user6Email.ToUpper(),
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEG719JW0JH1H9VQgj8uzgJ4HLJ+/2qP7NjjLeDMIku1+rtQT16BvU3uracoab0E0Gg==",
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
            new { UserId = user1.Id, SkillId = 1 }, // C#
            new { UserId = user1.Id, SkillId = 2 }, // JavaScript
            new { UserId = user1.Id, SkillId = 3 }, // Python
            new { UserId = user1.Id, SkillId = 4 }, // SQL
            new { UserId = user1.Id, SkillId = 5 }, // DevOps
            new { UserId = user1.Id, SkillId = 6 }, // HTML/CSS
            new { UserId = user1.Id, SkillId = 7 }, // React
            new { UserId = user1.Id, SkillId = 8 }, // ASP.NET
            new { UserId = user1.Id, SkillId = 14 }, // Docker
            new { UserId = user1.Id, SkillId = 15 }, // Kubernetes

            new { UserId = user2.Id, SkillId = 2 }, // JavaScript
            new { UserId = user2.Id, SkillId = 4 }, // SQL
            new { UserId = user2.Id, SkillId = 6 }, // HTML/CSS
            new { UserId = user2.Id, SkillId = 7 }, // React
            new { UserId = user2.Id, SkillId = 9 }, // Angular
            new { UserId = user2.Id, SkillId = 12 }, // Node.js
            new { UserId = user2.Id, SkillId = 13 }, // TypeScript

            new { UserId = user3.Id, SkillId = 1 }, // C#
            new { UserId = user3.Id, SkillId = 3 }, // Python
            new { UserId = user3.Id, SkillId = 4 }, // SQL
            new { UserId = user3.Id, SkillId = 14 }, // Docker
            new { UserId = user3.Id, SkillId = 11 }, // Cybersecurity

            new { UserId = user4.Id, SkillId = 1 }, // C#
            new { UserId = user4.Id, SkillId = 4 }, // SQL
            new { UserId = user4.Id, SkillId = 6 }, // HTML/CSS
            new { UserId = user4.Id, SkillId = 7 }, // React
            new { UserId = user4.Id, SkillId = 8 }, // ASP.NET
            new { UserId = user4.Id, SkillId = 9 }, // Angular
            new { UserId = user4.Id, SkillId = 16 }, // CSS

            new { UserId = user5.Id, SkillId = 3 }, // Python
            new { UserId = user5.Id, SkillId = 8 }, // ASP.NET
            new { UserId = user5.Id, SkillId = 14 }, // Docker
            new { UserId = user5.Id, SkillId = 19 }, // Terraform

            new { UserId = user6.Id, SkillId = 2 }, // JavaScript
            new { UserId = user6.Id, SkillId = 3 }, // Python
            new { UserId = user6.Id, SkillId = 4 }, // SQL
            new { UserId = user6.Id, SkillId = 5 }, // DevOps
            new { UserId = user6.Id, SkillId = 6 }, // HTML/CSS
            new { UserId = user6.Id, SkillId = 7 }, // React
            new { UserId = user6.Id, SkillId = 12 }, // Node.js
            new { UserId = user6.Id, SkillId = 14 }, // Docker
            new { UserId = user6.Id, SkillId = 15 }, // Kubernetes
            new { UserId = user6.Id, SkillId = 16 }, // CSS
            new { UserId = user6.Id, SkillId = 19 }, // Terraform
            new { UserId = user6.Id, SkillId = 23 }, // Git
            new { UserId = user6.Id, SkillId = 24 }  // Jenkins
        );


        // Insert qualification types
        modelBuilder.Entity<QualificationType>().HasData(
            new QualificationType { Id = 1, Name = "Education" },
            new QualificationType { Id = 2, Name = "Work" }
        );

        // Insert qualifications
        modelBuilder.Entity<Qualification>().HasData(
            new Qualification { Id = 1, Title = "Gymnasieutbildning i Ekonomiprogrammet", Description = "Inriktning mot företagsekonomi", Location = "Örebro Gymnasium", StartDate = new DateOnly(2012, 9, 1), EndDate = new DateOnly(2015, 6, 30), UserId = user1.Id, TypeId = 1 },
            new Qualification { Id = 2, Title = "Kandidat inom systemutveckling", Description = "3 årig kandidatexamen inom systemutveckling", Location = "Örebro Universitet", StartDate = new DateOnly(2015, 9, 1), EndDate = new DateOnly(2019, 6, 30), UserId = user1.Id, TypeId = 1 },
            new Qualification { Id = 3, Title = "Systemutvecklare", Description = "Arbetade som systemutvecklare med fokus på backend-utveckling.", Location = "TechCorp", StartDate = new DateOnly(2019, 7, 1), EndDate = new DateOnly(2022, 12, 31), UserId = user1.Id, TypeId = 2 },
            new Qualification { Id = 4, Title = "Senior Backend Developer", Description = "Ledde utvecklingen av serverlösningar och databasstruktur.", Location = "CloudTech", StartDate = new DateOnly(2023, 1, 1), EndDate = null, UserId = user1.Id, TypeId = 2 },

            new Qualification { Id = 5, Title = "Gymnasieutbildning i Naturvetenskap", Description = "Inriktning på matematik och naturvetenskap", Location = "Stockholms Gymnasium", StartDate = new DateOnly(2013, 9, 1), EndDate = new DateOnly(2016, 6, 30), UserId = user2.Id, TypeId = 1 },
            new Qualification { Id = 6, Title = "Master inom datavetenskap", Description = "2 års masterprogram inom datavetenskap med fokus på AI", Location = "Stockholms Universitet", StartDate = new DateOnly(2017, 8, 1), EndDate = new DateOnly(2019, 6, 30), UserId = user2.Id, TypeId = 1 },
            new Qualification { Id = 7, Title = "Frontend Developer", Description = "Arbetade med att utveckla användargränssnitt och interaktivitet.", Location = "Web Solutions", StartDate = new DateOnly(2019, 8, 1), EndDate = new DateOnly(2021, 5, 31), UserId = user2.Id, TypeId = 2 },
            new Qualification { Id = 8, Title = "Senior Frontend Developer", Description = "Ledde frontendteamet i utvecklingen av dynamiska webbsidor.", Location = "NextGen Web", StartDate = new DateOnly(2021, 6, 1), EndDate = null, UserId = user2.Id, TypeId = 2 },

            new Qualification { Id = 9, Title = "Gymnasieutbildning i Teknikprogrammet", Description = "Inriktning på IT och programmering", Location = "Uppsala Gymnasium", StartDate = new DateOnly(2013, 9, 1), EndDate = new DateOnly(2016, 6, 30), UserId = user3.Id, TypeId = 1 },
            new Qualification { Id = 10, Title = "Kandidat inom mjukvaruutveckling", Description = "3 års kandidatexamen inom mjukvaruutveckling", Location = "Uppsala Universitet", StartDate = new DateOnly(2016, 9, 1), EndDate = new DateOnly(2019, 6, 30), UserId = user3.Id, TypeId = 1 },
            new Qualification { Id = 11, Title = "DevOps Engineer", Description = "Arbetade som DevOps Engineer med fokus på automation och CI/CD pipelines.", Location = "CloudTech", StartDate = new DateOnly(2019, 7, 1), EndDate = new DateOnly(2022, 12, 31), UserId = user3.Id, TypeId = 2 },
            new Qualification { Id = 12, Title = "Senior DevOps Engineer", Description = "Ledde CI/CD-projekt och utvecklade effektiva bygg- och deploylösningar.", Location = "NextGen Cloud", StartDate = new DateOnly(2023, 1, 1), EndDate = null, UserId = user3.Id, TypeId = 2 },

            new Qualification { Id = 13, Title = "Gymnasieutbildning i Data- och IT-programmet", Description = "Inriktning på nätverksteknik och säkerhet", Location = "Chalmers Gymnasium", StartDate = new DateOnly(2012, 9, 1), EndDate = new DateOnly(2015, 6, 30), UserId = user4.Id, TypeId = 1 },
            new Qualification { Id = 14, Title = "Master inom IT-säkerhet", Description = "Masterexamen inom IT-säkerhet och nätverksdesign", Location = "Chalmers Tekniska Högskola", StartDate = new DateOnly(2016, 9, 1), EndDate = new DateOnly(2018, 6, 30), UserId = user4.Id, TypeId = 1 },
            new Qualification { Id = 15, Title = "IT-säkerhetsspecialist", Description = "Arbetade som IT-säkerhetsspecialist med fokus på penetrationstester och sårbarhetsbedömning.", Location = "SecureTech", StartDate = new DateOnly(2018, 7, 1), EndDate = new DateOnly(2022, 5, 31), UserId = user4.Id, TypeId = 2 },
            new Qualification { Id = 16, Title = "Lead Security Engineer", Description = "Ledde säkerhetsåtgärder på företagsnivå, inklusive sårbarhetshantering och säkerhetsrevisioner.", Location = "CyberSafe", StartDate = new DateOnly(2022, 6, 1), EndDate = null, UserId = user4.Id, TypeId = 2 },

            new Qualification { Id = 17, Title = "Gymnasieutbildning i IT och nätverksprogmmet", Description = "Inriktning på IT och nätverk", Location = "Lunds Gymnasium", StartDate = new DateOnly(2012, 9, 1), EndDate = new DateOnly(2015, 6, 30), UserId = user5.Id, TypeId = 1 },
            new Qualification { Id = 18, Title = "Kandidat inom dataingenjör", Description = "3 års kandidatexamen inom dataingenjör", Location = "Lunds Universitet", StartDate = new DateOnly(2016, 9, 1), EndDate = new DateOnly(2019, 6, 30), UserId = user5.Id, TypeId = 1 },
            new Qualification { Id = 19, Title = "Backend Developer", Description = "Arbetade som backendutvecklare med fokus på databasdesign och serverhantering.", Location = "CodeFactory", StartDate = new DateOnly(2019, 7, 1), EndDate = new DateOnly(2021, 12, 31), UserId = user5.Id, TypeId = 2 },
            new Qualification { Id = 20, Title = "Senior Backend Developer", Description = "Arbetade som senior backendutvecklare och ledde utvecklingen av API:er.", Location = "DataTech", StartDate = new DateOnly(2022, 1, 1), EndDate = null, UserId = user5.Id, TypeId = 2 },

            new Qualification { Id = 21, Title = "Gymnasieutbildning i Teknikprogrammet", Description = "Inriktning på IT och programmering", Location = "KTH Gymnasium", StartDate = new DateOnly(2012, 9, 1), EndDate = new DateOnly(2015, 6, 30), UserId = user6.Id, TypeId = 1 },
            new Qualification { Id = 22, Title = "Kandidat inom IT och programmering", Description = "3 års kandidatexamen inom IT och programmering", Location = "Göteborgs Universitet", StartDate = new DateOnly(2014, 9, 1), EndDate = new DateOnly(2017, 6, 30), UserId = user6.Id, TypeId = 1 },
            new Qualification { Id = 23, Title = "Master inom programvaruteknik", Description = "2 års masterprogram inom programvaruteknik med fokus på systemdesign och arkitektur", Location = "KTH", StartDate = new DateOnly(2017, 8, 1), EndDate = new DateOnly(2019, 6, 30), UserId = user6.Id, TypeId = 1 },
            new Qualification { Id = 24, Title = "Fullstack Developer", Description = "Arbetade som Fullstack Developer med fokus på både frontend och backend", Location = "Tech Innovators", StartDate = new DateOnly(2019, 7, 1), EndDate = new DateOnly(2021, 12, 31), UserId = user6.Id, TypeId = 2 },
            new Qualification { Id = 25, Title = "Tech Lead", Description = "Ledde utvecklingsteamet för ett större systemprojekt inom fintech.", Location = "Fintech Solutions", StartDate = new DateOnly(2022, 1, 1), EndDate = null, UserId = user6.Id, TypeId = 2 }
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
