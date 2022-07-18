using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lirmi.Domain.Models;

namespace Lirmi.Domain.Reposiotires
{
    public interface ICursoRepository
    {
        Task Delete(int id);
        Task<List<CursoModel>> GetAll();
        Task<CursoModel> GetById(int id);
        Task<CursoModel> Insert(CursoModel asignaturaModel);
        Task<CursoModel> Update(CursoModel asignaturaModel);
    }
}
