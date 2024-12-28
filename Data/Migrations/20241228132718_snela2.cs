using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class snela2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "Örebro Universitet");

            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: "Seoul Food market");

            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Location", "Title" },
                values: new object[] { "Mcdonalds", "Medarbetare" });

            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "Location",
                value: "Borlänge kommun");

            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 5,
                column: "Location",
                value: "Vretstorps värdshus");

            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 6,
                column: "Location",
                value: "Harvard University");

            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 7,
                column: "Location",
                value: "Neos pappas jobb");

            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 8,
                column: "Location",
                value: "Lunds Universitet");

            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 9,
                column: "Location",
                value: "Google");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Qualifications");

            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "McDonalds medarbetare");
        }
    }
}
