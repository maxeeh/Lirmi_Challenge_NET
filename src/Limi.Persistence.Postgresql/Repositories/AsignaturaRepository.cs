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
    public class AsignaturaRepository : IAsignaturaRepository
    {
        private readonly LirmiDataContext lirmiContext;
        private readonly IMapper mapper;

        public AsignaturaRepository(LirmiDataContext lirmiContext, IMapper mapper)
        {
            this.lirmiContext = lirmiContext;
            this.mapper = mapper;
        }


        public async Task Delete(int id)
        {
            var entity = await lirmiContext.Set<Asignatura>().FindAsync(id);

            if (entity == null)
                throw new Exception("The entity is null");

            lirmiContext.Set<Asignatura>().Remove(entity);
            await lirmiContext.SaveChangesAsync();
        }

        public async Task<List<AsignaturaModel>> GetAll()
        {
            var asignaturas = await lirmiContext.Set<Asignatura>().ToListAsync();

            return mapper.Map<IEnumerable<AsignaturaModel>>(asignaturas).ToList(); ;
        }

        public async Task<AsignaturaModel> GetById(int id)
        {
            var colegio = await lirmiContext.Set<Asignatura>().FindAsync(id);
            return mapper.Map<AsignaturaModel>(colegio);
        }

        public async Task<AsignaturaModel> Insert(AsignaturaModel asignaturaModel)
        {
            var entity = mapper.Map<Asignatura>(asignaturaModel);
            await lirmiContext.Set<Asignatura>().AddAsync(entity);
            await lirmiContext.SaveChangesAsync();

            if (entity.Id > 0)
                asignaturaModel.Id = entity.Id;

            return asignaturaModel;
        }

        public async Task<AsignaturaModel> Update(AsignaturaModel asignaturaModel)
        {
            var entity = mapper.Map<Asignatura>(asignaturaModel);
            lirmiContext.Set<Asignatura>().Update(entity);
            await lirmiContext.SaveChangesAsync();
            return asignaturaModel;
        }
    }
}
