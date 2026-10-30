using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repertoire_Management_System.Data;

namespace Repertoire_Management_System.Controllers
{
    public class AcquisitionController : Controller
    {
        private readonly RepertoireDBContext context;

        public AcquisitionController(RepertoireDBContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var songs = await context.Songs.AsNoTracking()
                .Where(song => song.State == "Acquisition")
                .ToListAsync();

            if (!songs.Any())
            {
                ViewBag.Message = "Songs not found";
                return View();
            }

            return View(songs);
        }
    }
}
