using Filminurk.Core.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Core.Dto
{
    public class MoviesDTO
    {
        public Guid? ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? FirstPublished { get; set; }
        public string? Director { get; set; }
        public List<string>? Actors { get; set; }
        public double? CurrentRating { get; set; }
        //public List<UserComment>? Reviews { get; set; }

        public List<IFormFile>? Files { get; set; }
        public IEnumerable<FileToApiDTO>? FileToApiDTOs { get; set; } = new List<FileToApiDTO>();

        /* 3 õpilase valitud andmetüüpi */
        public string? LastAiring { get; set; }
        public int? AirTimes { get; set; }
        public string? BigBooms { get; set; }

        /* andmebaasi jaoks vajalikud */
        public DateTime? EntryCreatedAt { get; set; }
        public DateTime? EntryModifiedAt { get; set; }
    }
}