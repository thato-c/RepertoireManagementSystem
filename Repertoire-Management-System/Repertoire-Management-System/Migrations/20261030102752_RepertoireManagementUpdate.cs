using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repertoire_Management_System.Migrations
{
    public partial class RepertoireManagementUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RehearsalSession",
                columns: table => new
                {
                    RehearsalSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RehearsalSession", x => x.RehearsalSessionId);
                });

            migrationBuilder.CreateTable(
                name: "RehearsalSessionTrial",
                columns: table => new
                {
                    RehearsalSessionTrialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RehearsalSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrialNumber = table.Column<int>(type: "int", nullable: false),
                    ReachedEnd = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RehearsalSessionTrial", x => x.RehearsalSessionTrialId);
                    table.ForeignKey(
                        name: "FK_RehearsalSessionTrial_RehearsalSession_RehearsalSessionTrialId",
                        column: x => x.RehearsalSessionTrialId,
                        principalTable: "RehearsalSession",
                        principalColumn: "RehearsalSessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RehearsalSessionTrial_Song_SongId",
                        column: x => x.SongId,
                        principalTable: "Song",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RehearsalSessionTrial_SongId",
                table: "RehearsalSessionTrial",
                column: "SongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RehearsalSessionTrial");

            migrationBuilder.DropTable(
                name: "RehearsalSession");
        }
    }
}
