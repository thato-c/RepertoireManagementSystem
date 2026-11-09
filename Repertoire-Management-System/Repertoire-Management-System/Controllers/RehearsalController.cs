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

        public List<SelectListItem> GetSongClassOptions()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value = "Development", Text = "Development"},
                new SelectListItem{Value = "Refinement", Text = "Refinement"},
                new SelectListItem{Value = "Availability Set", Text = "Availability Set"},
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

        [HttpPost]
        public async Task<IActionResult> RecordSession(RehearsalSessionViewModel model) 
        {
            var session = new RehearsalSession
            {
                Date = DateTime.Now,
            };
            context.rehearsalSessions.Add(session);
            await context.SaveChangesAsync();

            Guid sessionId = session.RehearsalSessionId;

            var trials = new List<RehearsalSessionTrial>();

            var results = new[]
            {
                model.FirstTrial,
                model.SecondTrial,
                model.ThirdTrial,
                model.FourthTrial,
                model.FifthTrial,
                model.SixthTrial
            };

            for (int i = 0; i < results.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(results[i]))
                {
                    trials.Add(new RehearsalSessionTrial
                    {
                        SongId = model.SongId,
                        RehearsalSessionId = sessionId,
                        TrialNumber = i + 1,
                        ReachedEnd = results[i]
                    });
                }
            }

            context.rehearsalSessionTrials.AddRange(trials);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Classifier()
        {
            var songs = await context.Songs.AsNoTracking()
                                           .Where(song => song.State == "Rehearsal")
                                           .ToListAsync();

            if (!songs.Any())
            {
                ViewBag.Message = "Songs not found";
                return View();
            }

            var viewModel = new SongClassAssignmentViewModel
            {
                // Populate the shaared master list
                SongClassOptions = GetSongClassOptions(),

                // Map each entity explicitly to a row
                Songs = songs.Select(song => new SongClassViewModel
                {
                    SongId = song.SongId,
                    Title = song.Title,
                    Artist = song.Artist,
                    SelectedClass = song.Class,
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSession()
        {
            var songs = await context.Songs.AsNoTracking()
                                           .Where(song => song.State == "Rehearsal")
                                           .ToListAsync();

            if (!songs.Any())
            {
                ViewBag.Message = "Songs not found";
                return View();
            }

            var viewModel = new CreateSessionViewModel
            {
                // Map each entity explicitly to a row
                SessionSongs = songs.Select(song => new SessionViewModel
                {
                    SongId = song.SongId,
                    Title = song.Title,
                    Artist = song.Artist,
                    IsSelected = false,
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreateSession(CreateSessionViewModel viewModel)
        {
            var session = new RehearsalSession
            {
                Name = viewModel.SessionName,
                Date = DateTime.Now,
            };

            var selectedSongs = viewModel.SessionSongs.Where(song => song.IsSelected).ToList();

            foreach (var song in selectedSongs)
            {
                session.Songs.Add(new RehearsalSessionSong
                {
                    SongId = song.SongId,
                });
                
            }
            context.rehearsalSessions.Add(session);
            await context.SaveChangesAsync();         

            return RedirectToAction("GetSessions");
        }

        [HttpGet]
        public async Task<IActionResult> GetSessions()
        {
            var rehearsalSessions = await context.rehearsalSessions.AsNoTracking().ToListAsync();

            if (!rehearsalSessions.Any())
            {
                ViewBag.Message = "Sessions not found";
                return View();
            }

            return View(rehearsalSessions);
        }

        [HttpGet]
        public async Task<IActionResult> GetSessionById(Guid? SessionId)
        {
            if (SessionId == null)
            {
                return NotFound();
            }

            var sessionSongs = await context.rehearsalSessionSongs.AsNoTracking()
                .Where(sessionSong => sessionSong.RehearsalSessionId == SessionId)
                .Include(sessionSong => sessionSong.Song)
                .ToListAsync();

            if (!sessionSongs.Any())
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
                    RehearsalSessionSongs = sessionSongs.Select(sessionSong => new RehearsalSessionViewModel
                    {
                        SongId = sessionSong.SongId,
                        Title = sessionSong.Song.Title,
                        Artist = sessionSong.Song.Artist,
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
