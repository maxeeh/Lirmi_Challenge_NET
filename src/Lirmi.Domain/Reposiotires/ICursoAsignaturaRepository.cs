using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lirmi.Domain.Models;

namespace Lirmi.Domain.Reposiotires
{
    public interface ICursoAsignaturaRepository
    {
        Task Delete(int id);
        Task<List<CursoAsignaturasModel>> GetAll();
        Task<CursoAsignaturasModel> GetById(int id);
        Task<CursoAsignaturasModel> Insert(CursoAsignaturasModel asignaturaModel);
        Task<CursoAsignaturasModel> Update(CursoAsignaturasModel asignaturaModel);
    }
}
