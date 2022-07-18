using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lirmi.Domain.Models
{
    public class CursoAsignaturasModel
    {
        public int Id { get; set; }

        public CursoModel CursoModel { get; set; }
        public AsignaturaModel AsignaturaModel { get; set; }
    }
}
