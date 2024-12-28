using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class snela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvatarUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Private = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualificationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Read = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnonymousName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Qualifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Qualifications_QualificationTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "QualificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkills", x => new { x.UserId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_UserSkills_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserProjects",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjects", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_UserProjects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "AvatarUri", "ConcurrencyStamp", "Description", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Private", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a1f2d713-1234-43fa-9c8e-65fa6ee39244", 0, "456 Elm St", "avatar2.png", null, "desc2", "bob.jones@example.com", true, "Bob", "Jones", false, null, "BOB.JONES@EXAMPLE.COM", "BOB.JONES@EXAMPLE.COM", "", null, false, false, "", false, "bob.jones@example.com" },
                    { "bb29d713-9414-43fa-9c8e-65fa6ee39243", 0, "123 Main St", "avatar1.png", null, "desc1", "alice.smith@example.com", true, "Alice", "Smith", false, null, "ALICE.SMITH@EXAMPLE.COM", "ALICE.SMITH@EXAMPLE.COM", "", null, false, false, "", false, "alice.smith@example.com" },
                    { "c1f3d713-5678-43fa-9c8e-65fa6ee39245", 0, "789 Oak St", "avatar3.png", null, "desc3", "carla.davis@example.com", true, "Carla", "Davis", false, null, "CARLA.DAVIS@EXAMPLE.COM", "CARLA.DAVIS@EXAMPLE.COM", "", null, false, false, "", false, "carla.davis@example.com" },
                    { "d1f4d713-9101-43fa-9c8e-65fa6ee39246", 0, "321 Pine St", "avatar4.png", null, "desc4", "david.lee@example.com", true, "David", "Lee", false, null, "DAVID.LEE@EXAMPLE.COM", "DAVID.LEE@EXAMPLE.COM", "", null, false, false, "", false, "david.lee@example.com" },
                    { "e1f5d713-1122-43fa-9c8e-65fa6ee39247", 0, "654 Birch St", "avatar5.png", null, "desc5", "emily.white@example.com", true, "Emily", "White", false, null, "EMILY.WHITE@EXAMPLE.COM", "EMILY.WHITE@EXAMPLE.COM", "", null, false, false, "", false, "emily.white@example.com" },
                    { "f1f6d713-3344-43fa-9c8e-65fa6ee39248", 0, "987 Cedar St", "avatar6.png", null, "desc6", "frank.hall@example.com", true, "Frank", "Hall", false, null, "FRANK.HALL@EXAMPLE.COM", "FRANK.HALL@EXAMPLE.COM", "", null, false, false, "", false, "frank.hall@example.com" }
                });

            migrationBuilder.InsertData(
                table: "QualificationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Education" },
                    { 2, "Work" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "JavaScript" },
                    { 3, "Python" },
                    { 4, "SQL" },
                    { 5, "DevOps" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AnonymousName", "CreatedAt", "Read", "ReceiverId", "SenderId", "Text" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "a1f2d713-1234-43fa-9c8e-65fa6ee39244", "bb29d713-9414-43fa-9c8e-65fa6ee39243", "Hello Bob!" },
                    { 2, null, new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "c1f3d713-5678-43fa-9c8e-65fa6ee39245", "a1f2d713-1234-43fa-9c8e-65fa6ee39244", "Hi Carla!" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Image", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, "A groundbreaking project.", "image1.png", "bb29d713-9414-43fa-9c8e-65fa6ee39243", "Project Alpha" },
                    { 2, "Another amazing project.", "image2.png", "a1f2d713-1234-43fa-9c8e-65fa6ee39244", "Project Beta" },
                    { 3, "Innovative and creative.", "image3.png", "c1f3d713-5678-43fa-9c8e-65fa6ee39245", "Project Gamma" }
                });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "Description", "EndDate", "Location", "StartDate", "Title", "TypeId", "UserId" },
                values: new object[,]
                {
                    { 1, "3 årig kandidatexamen inom systemuveckling", new DateOnly(2019, 6, 30), "Örebro Universitet", new DateOnly(2015, 9, 1), "Kandidat inom systemutveckling", 1, "bb29d713-9414-43fa-9c8e-65fa6ee39243" },
                    { 2, "2-year degree", new DateOnly(2022, 6, 30), "Seoul Food market", new DateOnly(2020, 9, 1), "MSc Software Engineering", 1, "bb29d713-9414-43fa-9c8e-65fa6ee39243" },
                    { 3, "Städare på donken.", new DateOnly(2021, 12, 31), "Mcdonalds", new DateOnly(2021, 1, 1), "Medarbetare", 2, "bb29d713-9414-43fa-9c8e-65fa6ee39243" },
                    { 4, "Intensive 12-week course on modern web development.", new DateOnly(2018, 5, 31), "Borlänge kommun", new DateOnly(2018, 3, 1), "Web Development Bootcamp", 1, "a1f2d713-1234-43fa-9c8e-65fa6ee39244" },
                    { 5, "Doctoral degree focusing on big data analysis and AI.", new DateOnly(2021, 6, 30), "Vretstorps värdshus", new DateOnly(2016, 9, 1), "PhD in Data Science", 1, "c1f3d713-5678-43fa-9c8e-65fa6ee39245" },
                    { 6, "Professional certification for project managers. Galeeeet stooooor.", new DateOnly(2020, 12, 31), "Harvard University", new DateOnly(2020, 1, 1), "Project Management Professional (PMP)", 2, "d1f4d713-9101-43fa-9c8e-65fa6ee39246" },
                    { 7, "1-year certification program focusing on cybersecurity fundamentals. Du får en tia om du visar kuken.", new DateOnly(2020, 6, 30), "Neos pappas jobb", new DateOnly(2019, 9, 1), "Certificate in Cybersecurity", 2, "e1f5d713-1122-43fa-9c8e-65fa6ee39247" },
                    { 8, "Undergraduate degree in IT with a focus on networking.", new DateOnly(2016, 6, 30), "Lunds Universitet", new DateOnly(2013, 9, 1), "BSc in Information Technology", 1, "bb29d713-9414-43fa-9c8e-65fa6ee39243" },
                    { 9, "Internship focusing on data cleaning, visualization, and analysis. Filip luktar kiss", new DateOnly(2022, 8, 31), "Google", new DateOnly(2022, 5, 1), "Data Analyst Internship", 2, "a1f2d713-1234-43fa-9c8e-65fa6ee39244" }
                });

            migrationBuilder.InsertData(
                table: "UserSkills",
                columns: new[] { "SkillId", "UserId" },
                values: new object[,]
                {
                    { 2, "a1f2d713-1234-43fa-9c8e-65fa6ee39244" },
                    { 1, "bb29d713-9414-43fa-9c8e-65fa6ee39243" },
                    { 3, "c1f3d713-5678-43fa-9c8e-65fa6ee39245" },
                    { 4, "d1f4d713-9101-43fa-9c8e-65fa6ee39246" },
                    { 5, "e1f5d713-1122-43fa-9c8e-65fa6ee39247" },
                    { 1, "f1f6d713-3344-43fa-9c8e-65fa6ee39248" }
                });

            migrationBuilder.InsertData(
                table: "UserProjects",
                columns: new[] { "ProjectId", "UserId" },
                values: new object[,]
                {
                    { 2, "a1f2d713-1234-43fa-9c8e-65fa6ee39244" },
                    { 1, "bb29d713-9414-43fa-9c8e-65fa6ee39243" },
                    { 2, "bb29d713-9414-43fa-9c8e-65fa6ee39243" },
                    { 1, "c1f3d713-5678-43fa-9c8e-65fa6ee39245" },
                    { 3, "c1f3d713-5678-43fa-9c8e-65fa6ee39245" },
                    { 2, "d1f4d713-9101-43fa-9c8e-65fa6ee39246" },
                    { 3, "d1f4d713-9101-43fa-9c8e-65fa6ee39246" },
                    { 1, "e1f5d713-1122-43fa-9c8e-65fa6ee39247" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_OwnerId",
                table: "Projects",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_TypeId",
                table: "Qualifications",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_UserId",
                table: "Qualifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_ProjectId",
                table: "UserProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_SkillId",
                table: "UserSkills",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "UserProjects");

            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "QualificationTypes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
