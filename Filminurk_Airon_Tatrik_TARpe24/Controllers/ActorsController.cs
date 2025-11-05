using Filminurk.ApplicationServices.Services;
using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using Filminurk.Models.Actors;
using Filminurk.Models.Movies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filminurk.Controllers
{
    public class ActorsController : Controller
    {
        private readonly FilminurkTARpe24Context _context;
        private readonly IActorsServices _actorsServices;
        private readonly IFilesServices _filesServices; //piltide lisamiseks vajalik fileservices injection

        public ActorsController
           (
               FilminurkTARpe24Context context,
               IActorsServices actorsServices,
               IFilesServices filesServices //piltide lisamiseks vajalik fileservices injection
           )
        {
            _context = context;
            _actorsServices = actorsServices;
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
                        MovieID = x.MovieID,
                        IsPoster = x.IsPoster,
                    }).ToArray()
                };
                var result = await _actorsServices.Create(dto);
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
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var actors = await _actorsServices.DetailsAsync(id);

            if (actors == null)
            {
                return NotFound();
            }
            Models.Actors.ImageViewModel[] images = await FileFromDatabase(id);

            var vm = new ActorsDetailsViewModel();

            vm.ID = actors.ID;
            vm.FirstName = actors.FirstName;
            vm.LastName = actors.LastName;
            vm.NickName = actors.NickName;
            vm.MoviesActedFor = actors.MoviesActedFor;
            vm.PortraitID = actors.PortraitID;
            

            vm.ActorRating = actors.ActorRating;
            vm.HomeCountry = actors.HomeCountry;
            vm.FavouriteHobby = actors.FavouriteHobby;
            vm.EntryCreatedAt = actors.EntryCreatedAt;
            vm.EntryModifiedAt = actors.EntryModifiedAt;


            vm.Images.AddRange(images);

            return View(vm);
        }
        private async Task<Models.Actors.ImageViewModel[]> FileFromDatabase(Guid id)
        {
            return await _context.FilesToApi
                .Where(x => x.ActorID == id)
                .Select(y => new Models.Actors.ImageViewModel
                {
                    ImageID = y.ImageID,
                    ActorID = y.ActorID,
                    IsPoster = y.IsPoster,
                    FilePath = y.ExistingFilePath
                }).ToArrayAsync();
        }
    }
}
