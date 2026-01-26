using Filminurk.Core.Dto.OMDbDTOs;
using Filminurk.Core.ServiceInterface;
using Filminurk.Models.OMDb;
using Microsoft.AspNetCore.Mvc;

namespace Filminurk.Controllers
{
        public class OMDbapiController : Controller
        {
            private readonly IOMDbServices _omdbServices;
            public OMDbapiController
                (
                 IOMDbServices omdbServices
                )
            {
                _omdbServices = omdbServices;
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

                return View(model);
            }
        }
}
