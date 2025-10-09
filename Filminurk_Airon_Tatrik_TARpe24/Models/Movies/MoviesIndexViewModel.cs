namespace Filminurk_Airon_Tatrik_TARpe24.Models.Movies
{
    public class MoviesIndexViewModel
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public DateOnly FirstPublished { get; set; }
        public decimal? CurrentRating { get; set; }
        //public List<UserComment>? Reviews { get; set; }

        /* 3 õpilase valikul andmetüüpi*/

        public DateOnly? LastAiring { get; set; }
        public int? AirTimes { get; set; }
    }
}
