using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repertoire_Management_System.Data;
using Repertoire_Management_System.Models;
using Repertoire_Management_System.ViewModels;

namespace Repertoire_Management_System.Controllers
{
    public class SongController : Controller
    {
        private readonly RepertoireDBContext context;

        public SongController(RepertoireDBContext _context)
        {
            this.context = _context;
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

            return View(songs);
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
                };
                context.Songs.Add(song);
                context.SaveChanges();
                return RedirectToAction("Index", "Song");
            }
            return View(viewModel);
        }
    }
}
