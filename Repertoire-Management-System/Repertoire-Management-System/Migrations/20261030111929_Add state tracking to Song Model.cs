using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repertoire_Management_System.Migrations
{
    public partial class AddstatetrackingtoSongModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Song",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Song");
        }
    }
}
