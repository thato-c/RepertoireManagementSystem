using System.ComponentModel.DataAnnotations;

namespace Repertoire_Management_System.Models
{
    public class RehearsalSession
    {
        public Guid RehearsalSessionId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public ICollection<RehearsalSessionTrial> Trials { get; set; } = new List<RehearsalSessionTrial>();
    }
}
