using Filminurk.Core.Domain;
using Filminurk.Core.Dto.OMDbDTOs;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using Filminurk.Models.OMDb;
using Microsoft.AspNetCore.Mvc;

namespace Filminurk.Controllers
{
        public class OMDbapiController : Controller
        {
            private readonly IOMDbServices _omdbServices;
        private readonly FilminurkTARpe24Context _context;
            public OMDbapiController
                (
                 IOMDbServices omdbServices,
                 FilminurkTARpe24Context context

                )
            {
                _omdbServices = omdbServices;
            _context = context;
            }
            [HttpGet]
            public IActionResult Index()
            {
                return View("Index");
            }
            [HttpPost]
            public async Task<IActionResult> Index(OmdbViewModel model)
            {
                if (string.IsNullOrEmpty(model.Title))
                {
                    ModelState.AddModelError("Title", "Sisesta filmi nimi");
                    return View(model);
                }

                OMDbApiResultDTO dto = new();
                { dto.Title = model.Title; }
                dto = await _omdbServices.OMDbApi(dto);

                model.Released = dto.Released;
                model.Director = dto.Director;
                model.Actors = dto.Actors;
                model.Plot = dto.Plot;
                model.imdbRating = dto.imdbRating;

            // Save to database
            var omdbToDatabase = new OMDbToDatabase
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Released = dto.Released,
                Director = dto.Director,
                Actors = dto.Actors,
                Plot = dto.Plot,
                imdbRating = dto.imdbRating,

            };

            _context.OMDbToDatabase.Add(omdbToDatabase);
            await _context.SaveChangesAsync();

            return View(model);
            }
        }
}
