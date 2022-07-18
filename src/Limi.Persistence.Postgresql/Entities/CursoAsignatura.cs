using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limi.Persistence.Postgresql.Entities
{
    public class CursoAsignatura
    {
        public int Id { get; set; }
        [Required]
        public Curso Curso { get; set; }
        [Required]
        public Asignatura Asignatura { get; set; }
    }
}
