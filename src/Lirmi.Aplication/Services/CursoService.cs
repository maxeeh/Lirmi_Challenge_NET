using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lirmi.Domain.Models;
using Lirmi.Domain.Reposiotires;
using Microsoft.Extensions.Logging;

namespace Lirmi.Aplication.Services
{
    public class CursoService
    {

        private readonly ICursoRepository _cursoRepository;
        public CursoService(ICursoRepository cursoRepository)
        {
            this._cursoRepository = cursoRepository;
        }

        public async Task<List<CursoModel>> CursosGetAll()
        {
            var cursos = new List<CursoModel>();
            try
            {
                cursos = await _cursoRepository.GetAll();
            }
            catch (Exception ex)
            {

            }
            return cursos;
        }

        public async Task<CursoModel> ObtenerCursoPorId(int id)
        {
            var cursos = new CursoModel();
            try
            {
                cursos = await _cursoRepository.GetById(id);
            }
            catch (Exception ex)
            {


            }
            return cursos;
        }

        public async Task<CursoModel> ActualizarCurso(int id, CursoModel curso)
        {
            try
            {
                var existencia = await _cursoRepository.GetById(id);

                if (existencia.Id > 0)
                    await _cursoRepository.Update(curso);

            }
            catch (Exception ex)
            {

                return null;
            }

            return curso;
        }

        public async Task<CursoModel> CrearCurso(CursoModel curso)
        {
            try
            {
                var result = await _cursoRepository.Insert(curso);

                if (result.Id > 0)
                {
                    curso.Id = result.Id;
                }

            }
            catch (Exception ex)
            {

                return null;
            }

            return curso;
        }

    }
}
