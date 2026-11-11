using System.ComponentModel.DataAnnotations;

namespace Repertoire_Management_System.Models
{
    public class RehearsalSession
    {
        public Guid RehearsalSessionId { get; set; }

        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public ICollection<RehearsalSessionSong> Songs { get; set; } = new List<RehearsalSessionSong>();
    }
}
