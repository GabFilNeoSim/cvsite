using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class esnela2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 6, "HTML/CSS" },
                    { 7, "React" },
                    { 8, "ASP.NET Core" },
                    { 9, "Angular" },
                    { 10, "Cloud Computing" },
                    { 11, "Cybersecurity" },
                    { 12, "Data Analysis" },
                    { 13, "Machine Learning" },
                    { 14, "Docker" },
                    { 15, "Kubernetes" }
                });

            migrationBuilder.InsertData(
                table: "UserSkills",
                columns: new[] { "SkillId", "UserId" },
                values: new object[,]
                {
                    { 3, "a1f2d713-1234-43fa-9c8e-65fa6ee39244" },
                    { 2, "bb29d713-9414-43fa-9c8e-65fa6ee39243" },
                    { 4, "c1f3d713-5678-43fa-9c8e-65fa6ee39245" },
                    { 5, "d1f4d713-9101-43fa-9c8e-65fa6ee39246" },
                    { 8, "a1f2d713-1234-43fa-9c8e-65fa6ee39244" },
                    { 9, "a1f2d713-1234-43fa-9c8e-65fa6ee39244" },
                    { 6, "bb29d713-9414-43fa-9c8e-65fa6ee39243" },
                    { 7, "bb29d713-9414-43fa-9c8e-65fa6ee39243" },
                    { 10, "c1f3d713-5678-43fa-9c8e-65fa6ee39245" },
                    { 11, "c1f3d713-5678-43fa-9c8e-65fa6ee39245" },
                    { 12, "d1f4d713-9101-43fa-9c8e-65fa6ee39246" },
                    { 13, "d1f4d713-9101-43fa-9c8e-65fa6ee39246" },
                    { 14, "e1f5d713-1122-43fa-9c8e-65fa6ee39247" },
                    { 15, "e1f5d713-1122-43fa-9c8e-65fa6ee39247" },
                    { 7, "f1f6d713-3344-43fa-9c8e-65fa6ee39248" },
                    { 8, "f1f6d713-3344-43fa-9c8e-65fa6ee39248" },
                    { 14, "f1f6d713-3344-43fa-9c8e-65fa6ee39248" },
                    { 15, "f1f6d713-3344-43fa-9c8e-65fa6ee39248" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 3, "a1f2d713-1234-43fa-9c8e-65fa6ee39244" });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 8, "a1f2d713-1234-43fa-9c8e-65fa6ee39244" });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 9, "a1f2d713-1234-43fa-9c8e-65fa6ee39244" });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 2, "bb29d713-9414-43fa-9c8e-65fa6ee39243" });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 6, "bb29d713-9414-43fa-9c8e-65fa6ee39243" });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 7, "bb29d713-9414-43fa-9c8e-65fa6ee39243" });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 4, "c1f3d713-5678-43fa-9c8e-65fa6ee39245" });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 10, "c1f3d713-5678-43fa-9c8e-65fa6ee39245" });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 11, "c1f3d713-5678-43fa-9c8e-65fa6ee39245" });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 5, "d1f4d713-9101-43fa-9c8e-65fa6ee39246" });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 12, "d1f4d713-9101-43fa-9c8e-65fa6ee39246" });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 13, "d1f4d713-9101-43fa-9c8e-65fa6ee39246" });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 14, "e1f5d713-1122-43fa-9c8e-65fa6ee39247" });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 15, "e1f5d713-1122-43fa-9c8e-65fa6ee39247" });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 7, "f1f6d713-3344-43fa-9c8e-65fa6ee39248" });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 8, "f1f6d713-3344-43fa-9c8e-65fa6ee39248" });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 14, "f1f6d713-3344-43fa-9c8e-65fa6ee39248" });

            migrationBuilder.DeleteData(
                table: "UserSkills",
                keyColumns: new[] { "SkillId", "UserId" },
                keyValues: new object[] { 15, "f1f6d713-3344-43fa-9c8e-65fa6ee39248" });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
