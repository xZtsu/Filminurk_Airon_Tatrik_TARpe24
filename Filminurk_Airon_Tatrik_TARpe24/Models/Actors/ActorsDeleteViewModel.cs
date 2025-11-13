using Filminurk.Core.Domain;
using Filminurk.Core.Dto;

namespace Filminurk.Models.Actors
{
    public class ActorsDeleteViewModel
    {
        public Guid? ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NickName { get; set; }
        public List<string>? MoviesActedFor { get; set; }
        public string? PortraitID { get; set; }
        public List<IFormFile>? Files { get; set; }

        public List<ImageViewModel> Images { get; set; } = new List<ImageViewModel>();

        /* Kolm minu */
        public double? ActorRating { get; set; }
        public HomeCountry? HomeCountry { get; set; }
        public string? FavouriteHobby { get; set; }

        public DateTime? EntryCreatedAt { get; set; }
        public DateTime? EntryModifiedAt { get; set; }



    }
}
