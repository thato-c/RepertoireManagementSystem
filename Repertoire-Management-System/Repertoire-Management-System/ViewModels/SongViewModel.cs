using System.ComponentModel.DataAnnotations;

namespace Repertoire_Management_System.ViewModels
{
    public class SongViewModel
    {
        [Required(ErrorMessage = "The Title is required.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Artist is required.")]
        public string Artist { get; set; } = string.Empty;
    }
}
