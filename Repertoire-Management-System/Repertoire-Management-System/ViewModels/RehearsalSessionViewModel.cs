using Microsoft.AspNetCore.Mvc.Rendering;

namespace Repertoire_Management_System.ViewModels
{
    public class RehearsalSessionViewModel
    {
        public Guid SongId { get; set; }
        public string Title { get; set; }
        public string Artist {  get; set; }

        // Captures the trials selection
        public string FirstTrial { get; set; }
        public string SecondTrial { get; set; }
        public string ThirdTrial { get; set; }
        public string FourthTrial { get; set; }
        public string FifthTrial { get; set; }
        public string SixthTrial { get; set; }
    }

    public class RehearsalSessionTrialViewModel
    {
        // List containing every row in the table
        public List<RehearsalSessionViewModel> RehearsalSession { get; set; } = new();

        // Shared List of options
        public List<SelectListItem> TrialOptions { get; set; } = new();
    }
}
