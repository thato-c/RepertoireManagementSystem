using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Repertoire_Management_System.ViewModels
{
    public class SongStateViewModel
    {
        public Guid SongId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        
        // Captures the user's selection for the row
        public string SelectedState { get; set; }
    }

    public class SongStateAssignmentViewModel
    {
        // List containing every row item in the table
        public List<SongStateViewModel> Songs { get; set; } = new();

        // Shared List of options
        public List<SelectListItem> SongStateOptions { get; set; } = new();
    }
}
