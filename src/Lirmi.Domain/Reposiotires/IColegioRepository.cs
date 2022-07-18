using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lirmi.Domain.Models;

namespace Lirmi.Domain.Reposiotires
{
    public interface IColegioRepository
    {
        Task Delete(int id);
        Task<List<ColegioModel>> GetAll();
        Task<ColegioModel> GetById(int id);
        Task<ColegioModel> Insert(ColegioModel colegioModel);
        Task<ColegioModel> Update(ColegioModel colegioModel);
    }
}
