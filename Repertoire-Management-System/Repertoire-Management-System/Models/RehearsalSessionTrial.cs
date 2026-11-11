namespace Repertoire_Management_System.Models
{
    public class RehearsalSessionTrial
    {
        public Guid RehearsalSessionTrialId {  get; set; }

        public Guid? RehearsalSessionSongId { get; set; }

        public int TrialNumber { get; set; }

        public string ReachedEnd { get; set; }

        public RehearsalSessionSong RehearsalSessionSong { get; set; }
    }
}
