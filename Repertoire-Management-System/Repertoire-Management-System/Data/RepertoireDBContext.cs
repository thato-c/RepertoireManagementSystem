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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Song>().ToTable("Song");
        }
    }
}
