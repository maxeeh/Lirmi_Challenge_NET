using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limi.Persistence.Postgresql.Entities;
using Microsoft.EntityFrameworkCore;


namespace Limi.Persistence.Postgresql.Context
{
    public class LirmiDataContext : DbContext
    {
        public LirmiDataContext(DbContextOptions<LirmiDataContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Colegio> Colegios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<CursoAsignatura> CursoAsignaturas { get; set; }

    }
}
