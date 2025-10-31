using Filminurk.Core.Domain;


namespace Filminurk.Models.Actors
{
    public class ActorsIndexViewModel
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        //public List<UserComment>? Reviews { get; set; }

        /* 2 õpilase valikul andmetüüpi*/

        public double? ActorRating { get; set; }
        public HomeCountry? HomeCountry { get; set; }

    }
}
