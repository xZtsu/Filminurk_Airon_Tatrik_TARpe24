using Filminurk.Core.Domain;
using Filminurk.Models.Movies;
using System.ComponentModel.DataAnnotations;

namespace Filminurk.Models.FavouriteLists
{
    public class FavuriteListIndexViewModel
    {
        
        public Guid FavouriteListID { get; set; }
        public string ListBelongsToUser { get; set; }
        public bool isMovieOrActor { get; set; }
        public string ListName { get; set; }
        public string? ListDescription { get; set; }
        public bool? IsPrivate { get; set; }
        //public List<Movie>? ListOfMovies { get; set; }
        //public List<Actor>? ListOfMovies { get; set; }
        public DateTime ListCreatedAt { get; set; }
        public DateTime? ListModifiedAt { get; set; }
        public DateTime? ListDeletedAt { get; set; }
        public bool? IsReported { get; set; } = false;
        public List<FavuriteListIndexViewModel> Image {  get; set; } = new List<FavuriteListIndexViewModel>();
    }
}
