using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTruckStore.Api.Migrations
{
    /// <inheritdoc />
    public partial class Repair1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaseSate",
                table: "Trucks",
                newName: "ReleaseDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Trucks",
                newName: "ReleaseSate");
        }
    }
}
