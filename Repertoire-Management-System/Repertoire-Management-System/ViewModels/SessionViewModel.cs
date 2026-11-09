namespace Repertoire_Management_System.ViewModels
{
    public class SessionViewModel
    {
        public Guid SongId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Class { get; set; }
        
        // Captures the user's result for the row
        public bool IsSelected { get; set; }
    }

    public class CreateSessionViewModel
    {
        // Captures the session name
        public string SessionName { get; set; } = string.Empty;

        // List containing every row item in the table
        public List<SessionViewModel> SessionSongs { get; set; } = new();
    }
}
