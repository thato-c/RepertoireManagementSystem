using Microsoft.EntityFrameworkCore;
using Repertoire_Management_System.Models;

namespace Repertoire_Management_System.Data
{
    public class RepertoireDBContext:DbContext
    {
        public RepertoireDBContext(DbContextOptions<RepertoireDBContext> options) : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<RehearsalSession> rehearsalSessions { get; set; }
        public DbSet<RehearsalSessionTrial> rehearsalSessionTrials { get; set; }
        public DbSet<RehearsalSessionSong> rehearsalSessionSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Song>().ToTable("Song");
            modelBuilder.Entity<RehearsalSession>().ToTable("RehearsalSession");
            modelBuilder.Entity<RehearsalSessionTrial>().ToTable("RehearsalSessionTrial");
            modelBuilder.Entity<RehearsalSessionSong>().ToTable("RehearsalSessionSong");

            // Configure the relationship between Song and RehearsalSessionTrial
            modelBuilder.Entity<Song>()
                .HasMany(song => song.Trials)
                .WithOne(rehearsalSessionTrial => rehearsalSessionTrial.Song)
                .HasForeignKey(rehearsalSessionTrial => rehearsalSessionTrial.SongId);

            // Configure the relationship between RehearsalSession and RehearsalSessionTrial
            modelBuilder.Entity<RehearsalSession>()
                .HasMany(rehearsalSession => rehearsalSession.Trials)
                .WithOne(rehearsalSessionTrial => rehearsalSessionTrial.RehearsalSession)
                .HasForeignKey(rehearsalSessionTrial => rehearsalSessionTrial.RehearsalSessionTrialId);

            // Configure the relationship between RehearsalSession and RehearsalSessionSong
            modelBuilder.Entity<RehearsalSession>()
                .HasMany(rehearsalSession => rehearsalSession.Songs)
                .WithOne(rehearsalSessionSongs => rehearsalSessionSongs.RehearsalSession)
                .HasForeignKey(rehearsalSessionSongs => rehearsalSessionSongs.RehearsalSessionId);

            //Configure the relationship between Song and RehearsalSessionSong
            modelBuilder.Entity<Song>()
                .HasMany(song => song.Sessions)
                .WithOne(rehearsalSessionSongs => rehearsalSessionSongs.Song)
                .HasForeignKey(rehearsalSessionSongs => rehearsalSessionSongs.SongId);
        }
    }
}
