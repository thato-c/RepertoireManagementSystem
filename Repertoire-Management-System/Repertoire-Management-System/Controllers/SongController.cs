using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repertoire_Management_System.Data;
using Repertoire_Management_System.Models;
using Repertoire_Management_System.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Repertoire_Management_System.Controllers
{
    public class SongController : Controller
    {
        private readonly RepertoireDBContext context;

        public SongController(RepertoireDBContext _context)
        {
            this.context = _context;
        }

        private List<SelectListItem> GetSongStateOptions()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "To Learn", Text = "To Learn" },
                new SelectListItem { Value = "Acquiring", Text = "Acquiring" },
                new SelectListItem { Value = "Rehearsal", Text = "Rehearsal" },

            };
        }

        [HttpGet]
        public IActionResult Index()
        {
            var songs = context.Songs.ToList();

            if (songs.Count == 0)
            {
                ViewBag.Message = "Songs not found.";
                return View();
            }
            else
            {
                var viewModel = new SongStateAssignmentViewModel
                {
                    // Populate the shared master list
                    SongStateOptions = GetSongStateOptions(),

                    // Map each entity explicitly to a row
                    SongStates = songs.Select(song => new SongStateViewModel
                    {
                        SongId = song.SongId,
                        Title = song.Title,
                        Artist = song.Artist,
                        SelectedState = song.State,
                    }).ToList()
                };

                return View(viewModel);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(SongViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Map the viewModel to the Model
                var song = new Models.Song
                {
                    Title = viewModel.Title,
                    Artist = viewModel.Artist,
                    State = "To Learn",
                };
                context.Songs.Add(song);
                context.SaveChanges();
                return RedirectToAction("Index", "Song");
            }
            return View(viewModel);
        }
    }
}
