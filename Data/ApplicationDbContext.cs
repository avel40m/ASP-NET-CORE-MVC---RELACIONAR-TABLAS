using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using presonasimagen.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<presonasimagen.Models.EstudiosModel> EstudiosModel { get; set; }

        public DbSet<presonasimagen.Models.LocalidadModel> LocalidadModel { get; set; }

        public DbSet<presonasimagen.Models.TitulosModel> TitulosModel { get; set; }

        public DbSet<presonasimagen.Models.AlumnosModel> AlumnosModel { get; set; }
    }
