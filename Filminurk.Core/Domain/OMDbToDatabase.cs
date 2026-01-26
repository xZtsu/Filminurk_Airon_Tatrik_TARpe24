using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Core.Domain
{
    public class OMDbToDatabase
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Released { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string imdbRating { get; set; }
    }
}
