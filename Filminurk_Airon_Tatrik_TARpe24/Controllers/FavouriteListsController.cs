using Filminurk.Data;
using Filminurk.Models.FavouriteLists;
using Microsoft.AspNetCore.Mvc;
using Filminurk.Core.Domain;
using System.Threading.Tasks;
using Filminurk.Models.Movies;
using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.ApplicationServices.Services;


namespace Filminurk.Controllers
{
    public class FavouriteListsController : Controller
    {
        private readonly FilminurkTARpe24Context _context;
        private readonly IFavouriteListsServices _favouriteListsServices;
        //fileservice add later

        public FavouriteListsController(FilminurkTARpe24Context context,
            IFavouriteListsServices favouriteListsServices)
        {
            _context = context  ;
            _favouriteListsServices = favouriteListsServices;
        }
        public IActionResult Index()
        {
              var resultingLists = _context.FavouriteLists
                .OrderByDescending(y => y.ListCreatedAt) //sorteeri nimekiri langevas järjekorras kuupäeva-kellaaja järgi
                .Select(x => new FavouriteListIndexViewModel()
                {
                    FavouriteListID = x.FavouriteListID,
                    ListBelongsToUser = x.ListBelongsToUser,
                    isMovieOrActor = x.isMovieOrActor,
                    ListName = x.ListName,
                    ListDescription = x.ListDescription,
                    ListCreatedAt = x.ListCreatedAt,
                    Image = (List<FavouriteListIndexImageViewModel>)_context.FilesToDatabase
                    .Where(ml => ml.ListID == x.FavouriteListID)
                    .Select(li => new FavouriteListIndexImageViewModel
                    {
                        ListID = li.ListID,
                        ImageID = li.ImageID,
                        ImageData = li.ImageData,
                        ImageTitle = li.ImageTitle,
                        Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(li.ImageData)),
                    })
                });
            return View(resultingLists);
        }
        /* create get, create post*/
        [HttpGet]
        public async Task<IActionResult> Create(FavouriteListUserCreateViewModel model)
        {
            //todo: identify the user type. reutnr different views for admin and registered user
            var movies = _context.Movies
                .OrderBy(m => m.Title)
                .Select(mo => new MoviesIndexViewModel
                {
                    ID = mo.ID,
                    Title = mo.Title,
                    FirstPublished = mo.FirstPublished,
                   AirTimes = mo.AirTimes,
                })
                .ToList();

            ViewData["allmovies"] = movies;
            ViewData["userHasSelected"] = new List<string>();
            //this for normal user
            FavouriteListUserCreateViewModel vm = new();
            return View("UserCreate", vm);

        }
        [HttpPost]
        public async Task<IActionResult> UserCreate(FavouriteListUserCreateViewModel vm, List<string> userHasSelected, List<MoviesIndexViewModel> movies)
        {
            List<Guid> tempParse = new();
            foreach (var stringID in userHasSelected)
            {
                tempParse.Add(Guid.Parse(stringID));
            }
            var newListDto = new FavouriteListDTO() { };
            newListDto.ListName = vm.ListName;
            newListDto.ListDescription= vm.ListDescription;
            newListDto.isMovieOrActor = vm.isMovieOrActor;
            newListDto.IsPrivate= vm.IsPrivate;
            newListDto.ListCreatedAt = (DateTime)vm.ListCreatedAt;
            newListDto.ListBelongsToUser = "00000000-0000-0000-0000-000000000001";
            newListDto.ListModifiedAt = DateTime.UtcNow;
            newListDto.ListDeletedAt = vm.ListDeletedAt;

            List<Guid> convertedIDs = new List<Guid>();
            if (newListDto.ListOfMovies != null)
            {
                convertedIDs = MovieToId(newListDto.ListOfMovies);
            }
            var NewList = await _favouriteListsServices.Create(newListDto, convertedIDs);
            if (NewList != null) 
            {
                return BadRequest();
            }
            return RedirectToAction("Index", vm);
        }

        private List<Guid> MovieToId(List<Movie> ListOfMovies)
        { 
            var result = new List<Guid>();
            foreach (var movie in ListOfMovies)
            {
                result.Add(movie.ID);
            }
            return result;
        }


    }
}

