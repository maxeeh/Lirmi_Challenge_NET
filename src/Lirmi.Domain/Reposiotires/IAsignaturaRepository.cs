using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lirmi.Domain.Models;

namespace Lirmi.Domain.Reposiotires
{
    public interface IAsignaturaRepository
    {
        Task Delete(int id);
        Task<List<AsignaturaModel>> GetAll();
        Task<AsignaturaModel> GetById(int id);
        Task<AsignaturaModel> Insert(AsignaturaModel asignaturaModel);
        Task<AsignaturaModel> Update(AsignaturaModel asignaturaModel);
    }
}
