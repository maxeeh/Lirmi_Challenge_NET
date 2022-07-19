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
    public class CursoRepository : ICursoRepository
    {
        private readonly LirmiDataContext lirmiContext;
        private readonly IMapper mapper;

        public CursoRepository(LirmiDataContext lirmiContext, IMapper mapper)
        {
            this.lirmiContext = lirmiContext;
            this.mapper = mapper;
        }

        public async Task Delete(int id)
        {
            var entity = await lirmiContext.Set<Curso>().FindAsync(id);

            if (entity == null)
                throw new Exception("The entity is null");

            lirmiContext.Set<Curso>().Remove(entity);
            await lirmiContext.SaveChangesAsync();
        }

        public async Task<List<CursoModel>> GetAll()
        {
            var cursos = await lirmiContext.Cursos.Include(a => a.Colegio).ToListAsync();

            return mapper.Map<IEnumerable<CursoModel>>(cursos).ToList(); ;
        }

        public async Task<CursoModel> GetById(int id)
        {
            var curso = await lirmiContext.Cursos.Include(a => a.Colegio).AsNoTracking().FirstAsync(x=>x.Id == id);
            return mapper.Map<CursoModel>(curso);
        }

        public async Task<CursoModel> Insert(CursoModel cursoModel)
        {
            var entity = mapper.Map<Curso>(cursoModel);
            entity.ColegioId = cursoModel.Colegio.Id;
            await lirmiContext.Set<Curso>().AddAsync(entity);
            await lirmiContext.SaveChangesAsync();

            if (entity.Id > 0)
                cursoModel.Id = entity.Id;

            return cursoModel;
        }

        public async Task<CursoModel> Update(CursoModel cursoModel)
        {
            var entity = mapper.Map<Curso>(cursoModel);
            entity.ColegioId = cursoModel.Colegio.Id;
            lirmiContext.Set<Curso>().Update(entity);
            await lirmiContext.SaveChangesAsync();
            return cursoModel;
        }
    }
}
