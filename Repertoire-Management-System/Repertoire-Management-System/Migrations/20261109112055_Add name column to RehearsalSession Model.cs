using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repertoire_Management_System.Migrations
{
    public partial class AddnamecolumntoRehearsalSessionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RehearsalSession",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "RehearsalSession");
        }
    }
}
