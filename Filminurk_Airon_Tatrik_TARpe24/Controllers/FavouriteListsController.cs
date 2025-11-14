using Filminurk.Data;
using Filminurk.Models.FavouriteLists;
using Microsoft.AspNetCore.Mvc;
using Filminurk.Core.Domain;

namespace Filminurk.Controllers
{
    public class FavouriteListsController : Controller
    {
        private readonly FilminurkTARpe24Context _context;
        //FLservice add later
        //fileservice add later

        public FavouriteListsController(FilminurkTARpe24Context context )
        {
            _context = context  ;      
        }
        public IActionResult Index()
        {
              var resultingLists = _context.FavouriteLists
                .OrderByDescending(y => y.ListCreatedAt) //sorteeri nimekiri langevas järjekorras kuupäeva-kellaaja järgi
                .Select(x => new FavuriteListIndexViewModel()
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
    }
}

