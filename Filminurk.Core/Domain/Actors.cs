using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Core.Domain
{
    public class Actors
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public List<string>? MoviesActedFor { get; set; }
        public string? PortraitID { get; set; }

        /* Kolm minu mõeldud asju */
        public double? ActorRating { get; set; }
        public HomeCountry? HomeCountry { get; set; }
        public string? FavouriteHobby { get; set; }

        public DateTime? EntryCreatedAt { get; set; }
        public DateTime? EntryModifiedAt { get; set; }

    }
}
