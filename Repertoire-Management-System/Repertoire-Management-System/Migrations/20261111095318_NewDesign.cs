using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repertoire_Management_System.Migrations
{
    public partial class NewDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RehearsalSessionTrial_RehearsalSession_RehearsalSessionTrialId",
                table: "RehearsalSessionTrial");

            migrationBuilder.DropForeignKey(
                name: "FK_RehearsalSessionTrial_Song_SongId",
                table: "RehearsalSessionTrial");

            migrationBuilder.DropColumn(
                name: "RehearsalSessionId",
                table: "RehearsalSessionTrial");

            migrationBuilder.RenameColumn(
                name: "SongId",
                table: "RehearsalSessionTrial",
                newName: "RehearsalSessionSongId");

            migrationBuilder.RenameIndex(
                name: "IX_RehearsalSessionTrial_SongId",
                table: "RehearsalSessionTrial",
                newName: "IX_RehearsalSessionTrial_RehearsalSessionSongId");

            migrationBuilder.AddForeignKey(
                name: "FK_RehearsalSessionTrial_RehearsalSessionSong_RehearsalSessionSongId",
                table: "RehearsalSessionTrial",
                column: "RehearsalSessionSongId",
                principalTable: "RehearsalSessionSong",
                principalColumn: "RehearsalSessionSongId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RehearsalSessionTrial_RehearsalSessionSong_RehearsalSessionSongId",
                table: "RehearsalSessionTrial");

            migrationBuilder.RenameColumn(
                name: "RehearsalSessionSongId",
                table: "RehearsalSessionTrial",
                newName: "SongId");

            migrationBuilder.RenameIndex(
                name: "IX_RehearsalSessionTrial_RehearsalSessionSongId",
                table: "RehearsalSessionTrial",
                newName: "IX_RehearsalSessionTrial_SongId");

            migrationBuilder.AddColumn<Guid>(
                name: "RehearsalSessionId",
                table: "RehearsalSessionTrial",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_RehearsalSessionTrial_RehearsalSession_RehearsalSessionTrialId",
                table: "RehearsalSessionTrial",
                column: "RehearsalSessionTrialId",
                principalTable: "RehearsalSession",
                principalColumn: "RehearsalSessionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RehearsalSessionTrial_Song_SongId",
                table: "RehearsalSessionTrial",
                column: "SongId",
                principalTable: "Song",
                principalColumn: "SongId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
