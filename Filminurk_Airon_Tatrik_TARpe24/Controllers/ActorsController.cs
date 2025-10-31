using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using Filminurk.Models.Actors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filminurk.Controllers
{
    public class ActorsController : Controller
    {
        private readonly FilminurkTARpe24Context _context;
        private readonly IActorServices _actorServices;
        private readonly IFilesServices _filesServices; //piltide lisamiseks vajalik fileservices injection

        public ActorsController
           (
               FilminurkTARpe24Context context,
               IActorServices _actorServices,
               IFilesServices filesServices //piltide lisamiseks vajalik fileservices injection
           )
        {
            _context = context;
            _actorServices = _actorServices;
            _filesServices = filesServices; //piltide lisamiseks vajalik fileservices injection
        }
        public IActionResult Index()
        {
            var result = _context.Actors.Select(x => new ActorsIndexViewModel
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                NickName = x.NickName,
                ActorRating = x.ActorRating,
                HomeCountry = x.HomeCountry,
            });
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ActorsCreateUpdateViewModel result = new();
            return View("CreateUpdate", result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ActorsCreateUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = new ActorsDTO()
                {
                    ID = vm.ID,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    NickName = vm.NickName,
                    MoviesActedFor = vm.MoviesActedFor,
                    PortraitID = vm.PortraitID,
                    ActorRating = vm.ActorRating,
                    
                    HomeCountry = vm.HomeCountry,
                    FavouriteHobby = vm.FavouriteHobby,
                    EntryCreatedAt = vm.EntryCreatedAt,
                    EntryModifiedAt = vm.EntryModifiedAt,
                    Files = vm.Files,
                    FileToApiDTOs = vm.Images
                    .Select(x => new FileToApiDTO
                    {
                        ImageID = x.ImageID,
                        FilePath = x.FilePath,
                        ActorID = x.ActorID,
                        IsPoster = x.IsPoster,
                    }).ToArray()
                };
                var result = await _actorServices.Create(dto);
                if (result == null)
                {
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));

        }
    }
}
