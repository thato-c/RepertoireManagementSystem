using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repertoire_Management_System.Migrations
{
    public partial class CreateamodeltotrackRehearsalSessionSongsSongslinkedtoasession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RehearsalSessionSong",
                columns: table => new
                {
                    RehearsalSessionSongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RehearsalSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RehearsalSessionSong", x => x.RehearsalSessionSongId);
                    table.ForeignKey(
                        name: "FK_RehearsalSessionSong_RehearsalSession_RehearsalSessionId",
                        column: x => x.RehearsalSessionId,
                        principalTable: "RehearsalSession",
                        principalColumn: "RehearsalSessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RehearsalSessionSong_Song_SongId",
                        column: x => x.SongId,
                        principalTable: "Song",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RehearsalSessionSong_RehearsalSessionId",
                table: "RehearsalSessionSong",
                column: "RehearsalSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_RehearsalSessionSong_SongId",
                table: "RehearsalSessionSong",
                column: "SongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RehearsalSessionSong");
        }
    }
}
