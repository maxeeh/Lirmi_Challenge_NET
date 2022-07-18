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
    public class CursoAsignaturRepository : ICursoAsignaturaRepository
    {
        private readonly LirmiDataContext lirmiContext;
        private readonly IMapper mapper;

        public CursoAsignaturRepository(LirmiDataContext lirmiContext, IMapper mapper)
        {
            this.lirmiContext = lirmiContext;
            this.mapper = mapper;
        }

        public async Task Delete(int id)
        {
            var entity = await lirmiContext.Set<CursoAsignatura>().FindAsync(id);

            if (entity == null)
                throw new Exception("The entity is null");

            lirmiContext.Set<CursoAsignatura>().Remove(entity);
            await lirmiContext.SaveChangesAsync();
        }

        public async Task<List<CursoAsignaturasModel>> GetAll()
        {
            var cursos = await lirmiContext.Set<CursoAsignatura>().ToListAsync();

            return mapper.Map<IEnumerable<CursoAsignaturasModel>>(cursos).ToList(); ;
        }

        public async Task<CursoAsignaturasModel> GetById(int id)
        {
            var curso = await lirmiContext.Set<CursoAsignatura>().FindAsync(id);
            return mapper.Map<CursoAsignaturasModel>(curso);
        }

        public async Task<CursoAsignaturasModel> Insert(CursoAsignaturasModel cursoAsignaturasModel)
        {
            var entity = mapper.Map<CursoAsignatura>(cursoAsignaturasModel);
            await lirmiContext.Set<CursoAsignatura>().AddAsync(entity);
            await lirmiContext.SaveChangesAsync();

            if (entity.Id > 0)
                cursoAsignaturasModel.Id = entity.Id;

            return cursoAsignaturasModel;
        }

        public async Task<CursoAsignaturasModel> Update(CursoAsignaturasModel cursoAsignaturasModel)
        {
            var entity = mapper.Map<CursoAsignatura>(cursoAsignaturasModel);
            lirmiContext.Set<CursoAsignatura>().Update(entity);
            await lirmiContext.SaveChangesAsync();
            return cursoAsignaturasModel;
        }
    }
}
