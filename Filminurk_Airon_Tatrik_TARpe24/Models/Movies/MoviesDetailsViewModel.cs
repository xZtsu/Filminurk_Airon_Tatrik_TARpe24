using Filminurk.Core.Domain;

namespace Filminurk.Models.Movies
{
    public class MoviesDetailsViewModel
    {
        public Guid? ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? FirstPublished { get; set; }
        public string? Director { get; set; }
        public List<string>? Actors { get; set; }
        public double? CurrentRating { get; set; }
        //public List<UserComment>? Reviews { get; set; }

        /* 3 õpilase valitud andmetüüpi */
        public DateOnly? LastAiring { get; set; }
        public int? AirTimes { get; set; }
        public string? BigBooms { get; set; }

        /* andmebaasi jaoks vajalikud */
        public DateTime? EntryCreatedAt { get; set; }
        public DateTime? EntryModifiedAt { get; set; }
    }
}