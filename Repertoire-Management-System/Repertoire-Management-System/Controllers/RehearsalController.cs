using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repertoire_Management_System.Data;
using Repertoire_Management_System.Models;
using Repertoire_Management_System.ViewModels;

namespace Repertoire_Management_System.Controllers
{
    public class RehearsalController : Controller
    {
        private readonly RepertoireDBContext context;

        public RehearsalController(RepertoireDBContext _context)
        {
            this.context = _context;
        }

        private List<SelectListItem> GetTrialOptions()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value = "NA", Text = "NA"},
                new SelectListItem{Value = "Yes", Text = "Yes"},
                new SelectListItem{Value = "No", Text = "No"},
            };
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var songs = await context.Songs.AsNoTracking()
                .Where(song => song.State == "Rehearsal")
                .ToListAsync();

            if (!songs.Any())
            {
                ViewBag.Message = "Songs not found";
                return View();
            }
            else
            {
                var viewModel = new RehearsalSessionTrialViewModel
                {
                    // Populate the shared master List
                    TrialOptions = GetTrialOptions(),

                    // Map each entity explicitly to a row
                    RehearsalSessionSongs = songs.Select(song => new RehearsalSessionViewModel
                    {
                        SongId = song.SongId,
                        Title = song.Title,
                        Artist = song.Artist,
                        FirstTrial = "",
                        SecondTrial = "",
                        ThirdTrial = "",
                        FourthTrial = "",
                        FifthTrial = "",
                        SixthTrial = "",
                    }).ToList()
                };

                return View(viewModel);
            }
            
        }
    }
}
