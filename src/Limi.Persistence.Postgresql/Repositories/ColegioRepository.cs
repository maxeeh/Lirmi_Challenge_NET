using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Limi.Persistence.Postgresql.Context;
using Limi.Persistence.Postgresql.Entities;
using Lirmi.Domain.Models;
using Lirmi.Domain.Reposiotires;
using Microsoft.EntityFrameworkCore;

namespace Limi.Persistence.Postgresql.Repositories
{
    public class ColegioRepository : IColegioRepository
    {
        private readonly LirmiDataContext lirmiContext;
        private readonly IMapper mapper;
        public ColegioRepository(LirmiDataContext lirmiContext, IMapper mapper)
        {
            this.lirmiContext = lirmiContext;
            this.mapper = mapper;
        }


        public async Task Delete(int id)
        {
            var entity = await lirmiContext.Set<Colegio>().FindAsync(id);

            if (entity == null)
                throw new Exception("The entity is null");

            lirmiContext.Set<Colegio>().Remove(entity);
            await lirmiContext.SaveChangesAsync();
        }

        public async Task<List<ColegioModel>> GetAll()

        {
            try
            {
                var colegios = await lirmiContext.Colegios.ToListAsync();

                return mapper.Map<IEnumerable<ColegioModel>>(colegios).ToList(); ;
            }
            catch (Exception ex)
            {
                throw;
            }
          
        }

        public async Task<ColegioModel> GetById(int id)
        {
            var colegio = await lirmiContext.Colegios.AsNoTracking().FirstAsync(x=> x.Id == id);
            return mapper.Map<ColegioModel>(colegio);
        }

        public async Task<ColegioModel> Insert(ColegioModel colegioModel)
        {
            var entity = mapper.Map<Colegio>(colegioModel);
            await lirmiContext.Set<Colegio>().AddAsync(entity);
            await lirmiContext.SaveChangesAsync();

            if (entity.Id > 0)
                colegioModel.Id = entity.Id;

            return colegioModel;
        }

        public async Task<ColegioModel> Update(ColegioModel colegioModel)
        {
            var entity = mapper.Map<Colegio>(colegioModel);
            lirmiContext.Colegios.Update(entity);
            await lirmiContext.SaveChangesAsync();
            return colegioModel;
        }
    }
}
