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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Song>().ToTable("Song");
            modelBuilder.Entity<RehearsalSession>().ToTable("RehearsalSession");
            modelBuilder.Entity<RehearsalSessionTrial>().ToTable("RehearsalSessionTrial");

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
        }
    }
}
