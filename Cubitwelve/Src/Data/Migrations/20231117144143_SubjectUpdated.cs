using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cubitwelve.Src.Data.Migrations
{
    /// <inheritdoc />
    public partial class SubjectUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Subjects");
        }
    }
}
