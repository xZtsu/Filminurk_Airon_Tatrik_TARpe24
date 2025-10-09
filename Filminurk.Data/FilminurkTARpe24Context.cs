using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Filminurk.Core.Domain;

namespace Filminurk.Data
{
    public class FilminurkTARpe24Context : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}
