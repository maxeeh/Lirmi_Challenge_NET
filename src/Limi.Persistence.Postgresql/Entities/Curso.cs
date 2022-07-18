using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Limi.Persistence.Postgresql.Entities
{
    public class Curso
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public bool Activo { get; set; }
        public List<Asignatura> Asignaturas { get; set; }

    }
}
