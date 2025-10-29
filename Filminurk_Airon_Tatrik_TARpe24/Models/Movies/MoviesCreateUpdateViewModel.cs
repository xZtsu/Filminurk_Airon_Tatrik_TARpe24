
using Filminurk.Core.Domain;
using Filminurk.Models.Movies;
using System.ComponentModel.DataAnnotations;


namespace Filminurk.Models.Movies
{
    public class MoviesCreateUpdateViewModel
    {
        
        public Guid? ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly FirstPublished { get; set; }
        public string Director { get; set; }
        public List<string>? Actors { get; set; }
        public double? CurrentRating { get; set; }
        //public List<UserComment>? Reviews { get; set; }

        /* Kassasolevate piltide andmeomadused */
        public List<IFormFile> Files { get; set; }
        public List<ImageViewModel> Images { get; set; } = new List<ImageViewModel>();

        /* 3 õpilase valikul andmetüüpi*/

        public DateOnly? LastAiring { get; set; }
        public int? AirTimes { get; set; }
        public string? BigBooms { get; set; }

        public DateTime? EntryCreatedAt { get; set; }
        public DateTime? EntryModifiedAt { get; set; }
    }
}
