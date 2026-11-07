using Microsoft.AspNetCore.Mvc.Rendering;

namespace Repertoire_Management_System.ViewModels
{
    public class SongClassViewModel
    {
        public Guid SongId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }

        // Captures the user's selection for the row
        public string SelectedClass { get; set; }
    }

    public class SongClassAssignmentViewModel
    {
        // List containing every row item in the table
        public List<SongClassViewModel> Songs { get; set; }

        // Shared List of options
        public List<SelectListItem> SongClassOptions { get; set; } = new();
    }
}
