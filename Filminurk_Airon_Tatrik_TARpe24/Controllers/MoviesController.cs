using Filminurk.Data;
using Filminurk_Airon_Tatrik_TARpe24.Models.Movies;
using Microsoft.AspNetCore.Mvc;

namespace Filminurk_Airon_Tatrik_TARpe24.Controllers
{
    public class MoviesController : Controller
    {
        private readonly FilminurkTARpe24Context _context;
            public MoviesController (FilminurkTARpe24Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Movies.Select(x => new MoviesIndexViewModel
            {
                ID = x.ID,
                Title = x.Title,
                FirstPublished = x.FirstPublished,
                CurrentRating = x.CurrentRating,
                LastAiring = x.LastAiring,
                AirTimes = x.AirTimes,
            });
            return View();
        }
    }
}
