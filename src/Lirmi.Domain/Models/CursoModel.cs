using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lirmi.Domain.Models
{
    public class CursoModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public List<AsignaturaModel> AsignaturasModel { get; set; }
        public ColegioModel Colegio { get; set; }
    }
}
