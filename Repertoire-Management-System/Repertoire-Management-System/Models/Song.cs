namespace Repertoire_Management_System.Models
{
    public class Song
    {
        public Guid SongId { get; set; }

        public string Title {  get; set; } = string.Empty;

        public string Artist { get; set; } = string.Empty;
    }
}
