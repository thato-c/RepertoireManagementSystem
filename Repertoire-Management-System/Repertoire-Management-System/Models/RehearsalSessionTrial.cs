namespace Repertoire_Management_System.Models
{
    public class RehearsalSessionTrial
    {
        public Guid RehearsalSessionTrialId {  get; set; }

        public Guid RehearsalSessionId { get; set; }

        public Guid SongId { get; set; }

        public int TrialNumber { get; set; }

        public bool ReachedEnd { get; set; }

        public RehearsalSession RehearsalSession { get; set; } = new RehearsalSession();

        public Song Song { get; set; } = new Song();
    }
}
