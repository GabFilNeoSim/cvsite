﻿// <auto-generated />
using System;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241228123618_snela1")]
    partial class snela1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnonymousName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Read")
                        .HasColumnType("bit");

                    b.Property<string>("ReceiverId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Read = false,
                            ReceiverId = "a1f2d713-1234-43fa-9c8e-65fa6ee39244",
                            SenderId = "bb29d713-9414-43fa-9c8e-65fa6ee39243",
                            Text = "Hello Bob!"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Read = false,
                            ReceiverId = "c1f3d713-5678-43fa-9c8e-65fa6ee39245",
                            SenderId = "a1f2d713-1234-43fa-9c8e-65fa6ee39244",
                            Text = "Hi Carla!"
                        });
                });

            modelBuilder.Entity("Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A groundbreaking project.",
                            Image = "image1.png",
                            OwnerId = "bb29d713-9414-43fa-9c8e-65fa6ee39243",
                            Title = "Project Alpha"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Another amazing project.",
                            Image = "image2.png",
                            OwnerId = "a1f2d713-1234-43fa-9c8e-65fa6ee39244",
                            Title = "Project Beta"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Innovative and creative.",
                            Image = "image3.png",
                            OwnerId = "c1f3d713-5678-43fa-9c8e-65fa6ee39245",
                            Title = "Project Gamma"
                        });
                });

            modelBuilder.Entity("Models.Qualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Qualifications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "3 årig kandidatexamen inom systemuveckling",
                            EndDate = new DateOnly(2019, 6, 30),
                            StartDate = new DateOnly(2015, 9, 1),
                            Title = "Kandidat inom systemutveckling",
                            TypeId = 1,
                            UserId = "bb29d713-9414-43fa-9c8e-65fa6ee39243"
                        },
                        new
                        {
                            Id = 2,
                            Description = "2-year degree",
                            EndDate = new DateOnly(2022, 6, 30),
                            StartDate = new DateOnly(2020, 9, 1),
                            Title = "MSc Software Engineering",
                            TypeId = 1,
                            UserId = "bb29d713-9414-43fa-9c8e-65fa6ee39243"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Städare på donken.",
                            EndDate = new DateOnly(2021, 12, 31),
                            StartDate = new DateOnly(2021, 1, 1),
                            Title = "McDonalds medarbetare",
                            TypeId = 2,
                            UserId = "bb29d713-9414-43fa-9c8e-65fa6ee39243"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Intensive 12-week course on modern web development.",
                            EndDate = new DateOnly(2018, 5, 31),
                            StartDate = new DateOnly(2018, 3, 1),
                            Title = "Web Development Bootcamp",
                            TypeId = 2,
                            UserId = "a1f2d713-1234-43fa-9c8e-65fa6ee39244"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Doctoral degree focusing on big data analysis and AI.",
                            EndDate = new DateOnly(2021, 6, 30),
                            StartDate = new DateOnly(2016, 9, 1),
                            Title = "PhD in Data Science",
                            TypeId = 1,
                            UserId = "c1f3d713-5678-43fa-9c8e-65fa6ee39245"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Professional certification for project managers. Galeeeet stooooor.",
                            EndDate = new DateOnly(2020, 12, 31),
                            StartDate = new DateOnly(2020, 1, 1),
                            Title = "Project Management Professional (PMP)",
                            TypeId = 2,
                            UserId = "d1f4d713-9101-43fa-9c8e-65fa6ee39246"
                        },
                        new
                        {
                            Id = 7,
                            Description = "1-year certification program focusing on cybersecurity fundamentals. Du får en tia om du visar kuken.",
                            EndDate = new DateOnly(2020, 6, 30),
                            StartDate = new DateOnly(2019, 9, 1),
                            Title = "Certificate in Cybersecurity",
                            TypeId = 2,
                            UserId = "e1f5d713-1122-43fa-9c8e-65fa6ee39247"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Undergraduate degree in IT with a focus on networking.",
                            EndDate = new DateOnly(2016, 6, 30),
                            StartDate = new DateOnly(2013, 9, 1),
                            Title = "BSc in Information Technology",
                            TypeId = 1,
                            UserId = "bb29d713-9414-43fa-9c8e-65fa6ee39243"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Internship focusing on data cleaning, visualization, and analysis. Filip luktar kiss",
                            EndDate = new DateOnly(2022, 8, 31),
                            StartDate = new DateOnly(2022, 5, 1),
                            Title = "Data Analyst Internship",
                            TypeId = 2,
                            UserId = "a1f2d713-1234-43fa-9c8e-65fa6ee39244"
                        });
                });

            modelBuilder.Entity("Models.QualificationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QualificationTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Education"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Work"
                        });
                });

            modelBuilder.Entity("Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "C#"
                        },
                        new
                        {
                            Id = 2,
                            Title = "JavaScript"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Python"
                        },
                        new
                        {
                            Id = 4,
                            Title = "SQL"
                        },
                        new
                        {
                            Id = 5,
                            Title = "DevOps"
                        });
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvatarUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("Private")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "bb29d713-9414-43fa-9c8e-65fa6ee39243",
                            AccessFailedCount = 0,
                            Address = "123 Main St",
                            AvatarUri = "avatar1.png",
                            Description = "desc1",
                            Email = "alice.smith@example.com",
                            EmailConfirmed = true,
                            FirstName = "Alice",
                            LastName = "Smith",
                            LockoutEnabled = false,
                            NormalizedEmail = "ALICE.SMITH@EXAMPLE.COM",
                            NormalizedUserName = "ALICE.SMITH@EXAMPLE.COM",
                            PasswordHash = "",
                            PhoneNumberConfirmed = false,
                            Private = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "alice.smith@example.com"
                        },
                        new
                        {
                            Id = "a1f2d713-1234-43fa-9c8e-65fa6ee39244",
                            AccessFailedCount = 0,
                            Address = "456 Elm St",
                            AvatarUri = "avatar2.png",
                            Description = "desc2",
                            Email = "bob.jones@example.com",
                            EmailConfirmed = true,
                            FirstName = "Bob",
                            LastName = "Jones",
                            LockoutEnabled = false,
                            NormalizedEmail = "BOB.JONES@EXAMPLE.COM",
                            NormalizedUserName = "BOB.JONES@EXAMPLE.COM",
                            PasswordHash = "",
                            PhoneNumberConfirmed = false,
                            Private = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "bob.jones@example.com"
                        },
                        new
                        {
                            Id = "c1f3d713-5678-43fa-9c8e-65fa6ee39245",
                            AccessFailedCount = 0,
                            Address = "789 Oak St",
                            AvatarUri = "avatar3.png",
                            Description = "desc3",
                            Email = "carla.davis@example.com",
                            EmailConfirmed = true,
                            FirstName = "Carla",
                            LastName = "Davis",
                            LockoutEnabled = false,
                            NormalizedEmail = "CARLA.DAVIS@EXAMPLE.COM",
                            NormalizedUserName = "CARLA.DAVIS@EXAMPLE.COM",
                            PasswordHash = "",
                            PhoneNumberConfirmed = false,
                            Private = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "carla.davis@example.com"
                        },
                        new
                        {
                            Id = "d1f4d713-9101-43fa-9c8e-65fa6ee39246",
                            AccessFailedCount = 0,
                            Address = "321 Pine St",
                            AvatarUri = "avatar4.png",
                            Description = "desc4",
                            Email = "david.lee@example.com",
                            EmailConfirmed = true,
                            FirstName = "David",
                            LastName = "Lee",
                            LockoutEnabled = false,
                            NormalizedEmail = "DAVID.LEE@EXAMPLE.COM",
                            NormalizedUserName = "DAVID.LEE@EXAMPLE.COM",
                            PasswordHash = "",
                            PhoneNumberConfirmed = false,
                            Private = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "david.lee@example.com"
                        },
                        new
                        {
                            Id = "e1f5d713-1122-43fa-9c8e-65fa6ee39247",
                            AccessFailedCount = 0,
                            Address = "654 Birch St",
                            AvatarUri = "avatar5.png",
                            Description = "desc5",
                            Email = "emily.white@example.com",
                            EmailConfirmed = true,
                            FirstName = "Emily",
                            LastName = "White",
                            LockoutEnabled = false,
                            NormalizedEmail = "EMILY.WHITE@EXAMPLE.COM",
                            NormalizedUserName = "EMILY.WHITE@EXAMPLE.COM",
                            PasswordHash = "",
                            PhoneNumberConfirmed = false,
                            Private = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "emily.white@example.com"
                        },
                        new
                        {
                            Id = "f1f6d713-3344-43fa-9c8e-65fa6ee39248",
                            AccessFailedCount = 0,
                            Address = "987 Cedar St",
                            AvatarUri = "avatar6.png",
                            Description = "desc6",
                            Email = "frank.hall@example.com",
                            EmailConfirmed = true,
                            FirstName = "Frank",
                            LastName = "Hall",
                            LockoutEnabled = false,
                            NormalizedEmail = "FRANK.HALL@EXAMPLE.COM",
                            NormalizedUserName = "FRANK.HALL@EXAMPLE.COM",
                            PasswordHash = "",
                            PhoneNumberConfirmed = false,
                            Private = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "frank.hall@example.com"
                        });
                });

            modelBuilder.Entity("Models.UserProject", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("UserProjects");

                    b.HasData(
                        new
                        {
                            UserId = "bb29d713-9414-43fa-9c8e-65fa6ee39243",
                            ProjectId = 1
                        },
                        new
                        {
                            UserId = "a1f2d713-1234-43fa-9c8e-65fa6ee39244",
                            ProjectId = 2
                        },
                        new
                        {
                            UserId = "c1f3d713-5678-43fa-9c8e-65fa6ee39245",
                            ProjectId = 3
                        },
                        new
                        {
                            UserId = "e1f5d713-1122-43fa-9c8e-65fa6ee39247",
                            ProjectId = 1
                        },
                        new
                        {
                            UserId = "bb29d713-9414-43fa-9c8e-65fa6ee39243",
                            ProjectId = 2
                        },
                        new
                        {
                            UserId = "d1f4d713-9101-43fa-9c8e-65fa6ee39246",
                            ProjectId = 3
                        },
                        new
                        {
                            UserId = "c1f3d713-5678-43fa-9c8e-65fa6ee39245",
                            ProjectId = 1
                        },
                        new
                        {
                            UserId = "d1f4d713-9101-43fa-9c8e-65fa6ee39246",
                            ProjectId = 2
                        });
                });

            modelBuilder.Entity("Models.UserSkill", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("UserSkills");

                    b.HasData(
                        new
                        {
                            UserId = "bb29d713-9414-43fa-9c8e-65fa6ee39243",
                            SkillId = 1
                        },
                        new
                        {
                            UserId = "a1f2d713-1234-43fa-9c8e-65fa6ee39244",
                            SkillId = 2
                        },
                        new
                        {
                            UserId = "c1f3d713-5678-43fa-9c8e-65fa6ee39245",
                            SkillId = 3
                        },
                        new
                        {
                            UserId = "d1f4d713-9101-43fa-9c8e-65fa6ee39246",
                            SkillId = 4
                        },
                        new
                        {
                            UserId = "e1f5d713-1122-43fa-9c8e-65fa6ee39247",
                            SkillId = 5
                        },
                        new
                        {
                            UserId = "f1f6d713-3344-43fa-9c8e-65fa6ee39248",
                            SkillId = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Message", b =>
                {
                    b.HasOne("Models.User", "Receiver")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Models.User", "Sender")
                        .WithMany("SentMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Models.Project", b =>
                {
                    b.HasOne("Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Models.Qualification", b =>
                {
                    b.HasOne("Models.QualificationType", "Type")
                        .WithMany("Qualifications")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.User", "User")
                        .WithMany("Qualifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.UserProject", b =>
                {
                    b.HasOne("Models.Project", "Project")
                        .WithMany("Users")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Models.User", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.UserSkill", b =>
                {
                    b.HasOne("Models.Skill", "Skill")
                        .WithMany("Users")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Models.User", "User")
                        .WithMany("Skills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Project", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Models.QualificationType", b =>
                {
                    b.Navigation("Qualifications");
                });

            modelBuilder.Entity("Models.Skill", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Qualifications");

                    b.Navigation("ReceivedMessages");

                    b.Navigation("SentMessages");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
