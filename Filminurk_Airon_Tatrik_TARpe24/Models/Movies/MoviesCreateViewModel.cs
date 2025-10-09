
namespace Filminurk_Airon_Tatrik_TARpe24.Models.Movies
{
    public class MoviesCreateViewModel
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly FirstPublished { get; set; }
        public string Director { get; set; }
        public List<string>? Actors { get; set; }
        public decimal? CurrentRating { get; set; }
        //public List<UserComment>? Reviews { get; set; }

        /* 3 õpilase valikul andmetüüpi*/

        public DateOnly? LastAiring { get; set; }
        public int? AirTimes { get; set; }
        public string? BigBooms { get; set; }

        public DateTime? EntryCreatedAt { get; set; }
        public DateTime? EntryModifiedAt { get; set; }
    }
}
