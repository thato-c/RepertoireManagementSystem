using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repertoire_Management_System.Migrations
{
    public partial class ChangethedatatypeforReachedEnd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReachedEnd",
                table: "RehearsalSessionTrial",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ReachedEnd",
                table: "RehearsalSessionTrial",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
