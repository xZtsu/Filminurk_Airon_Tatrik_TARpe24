﻿using Filminurk.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Data
{
    public class FilminurkTARpe24Context : DbContext
    {
        public FilminurkTARpe24Context(DbContextOptions<FilminurkTARpe24Context> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<FileToApi> FilesToApi { get; set; }
    }
}