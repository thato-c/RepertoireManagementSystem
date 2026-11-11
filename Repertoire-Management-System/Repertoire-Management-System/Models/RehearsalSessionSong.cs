namespace Repertoire_Management_System.Models
{
    public class RehearsalSessionSong
    {
        public Guid RehearsalSessionSongId { get; set; }

        public Guid RehearsalSessionId { get; set; }

        public Guid SongId { get; set; }

        public RehearsalSession RehearsalSession { get; set; }

        public Song Song { get; set; }
    }
}
