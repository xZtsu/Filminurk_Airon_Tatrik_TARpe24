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
            newListDto.IsPrivate= (bool)vm.IsPrivate;
            newListDto.ListCreatedAt = (DateTime)vm.ListCreatedAt;
            newListDto.ListBelongsToUser = Guid.NewGuid().ToString();
            newListDto.ListModifiedAt = DateTime.UtcNow;
            newListDto.ListDeletedAt = vm.ListDeletedAt;

            /*List<Guid> convertedIDs = new List<Guid>();
            if (newListDto.ListOfMovies != null)
            {
                convertedIDs = MovieToId(newListDto.ListOfMovies);
            }*/
            var listofmoviestoadd = new List<Movie>();
            foreach (var movieId in tempParse)
            {
                Movie thismovie = (Movie)_context.Movies.Where(tm => tm.ID == movieId).ToList().First();
                listofmoviestoadd.Add((Movie)thismovie);
            }
            newListDto.ListOfMovies = listofmoviestoadd;

            
            var newList = await _favouriteListsServices.Create(newListDto/*convertedIDs*/);
            if (newList == null) 
            {
                return BadRequest();
            }
            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> UserDetails(Guid id, Guid thisuderid)
        {
            if (id == null || thisuderid == null)
            {
                return BadRequest();
                //TODO: return corresponding errorviews. id not found for list,  and user login error for userid
            }
            var thisList = _context.FavouriteLists
                .Where(tl => tl.FavouriteListID == id && tl.ListBelongsToUser == thisuderid.ToString())
                .Select(
                stl => new FavouriteListUserDetailsViewModel
                {
                    FavouriteListID = stl.FavouriteListID,
                    ListBelongsToUser = stl.ListBelongsToUser,
                    isMovieOrActor = stl.isMovieOrActor,
                    ListName = stl.ListName,
                    ListDescription = stl.ListDescription,
                    IsPrivate = stl.IsPrivate,
                    ListOfMovies = stl.ListOfMovies,
                    IsReported = stl.IsReported,
                    Image = _context.FilesToDatabase
                    .Where(i => i.ListID == stl.FavouriteListID)
                    .Select(si => new FavouriteListIndexImageViewModel
                    {
                        ImageID = si.ImageID,
                        ListID = si.ListID,
                        ImageData = si.ImageData,
                        ImageTitle = si.ImageTitle,
                        Image = string.Format("data:image/gif;base64,{0}",Convert.ToBase64String(si.ImageData))
                    }).FirstOrDefault()
                    
                }).ToList();
            //add viewdata attribute here later, to discern between user and admin
            if (thisList == null)
            {
                return NotFound();
            }
            return View("Details", thisList);
        }

        private List<Guid> MovieToId(List<Movie> ListOfMovies)
        { 
            var result = new List<Guid>();
            foreach (var movie in ListOfMovies)
            {
                result.Add((Guid)movie.ID);
            }
            return result;
        }


    }
}

