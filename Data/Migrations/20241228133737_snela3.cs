using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class snela3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "TypeId",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "TypeId",
                value: 2);
        }
    }
}
