using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repertoire_Management_System.Data;
using Repertoire_Management_System.Models;

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
    }
}
