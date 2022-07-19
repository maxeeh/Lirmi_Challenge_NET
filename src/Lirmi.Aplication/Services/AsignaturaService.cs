using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lirmi.Domain.Models;
using Lirmi.Domain.Reposiotires;

namespace Lirmi.Aplication.Services
{
    public class AsignaturaService
    {
        private readonly IAsignaturaRepository _asignaturaRepository;
        public AsignaturaService(IAsignaturaRepository asignaturaRepository)
        {
            this._asignaturaRepository = asignaturaRepository;
        }

        public async Task<List<AsignaturaModel>> AsignaturasGetAll()
        {
            var asignaturas = new List<AsignaturaModel>();
            try
            {
                asignaturas = await _asignaturaRepository.GetAll();
            }
            catch (Exception ex)
            {

            }
            return asignaturas;
        }

        public async Task<AsignaturaModel> ObtenerAsignaturaPorId(int id)
        {
            var asignatura = new AsignaturaModel();
            try
            {
                asignatura = await _asignaturaRepository.GetById(id);
            }
            catch (Exception ex)
            {


            }
            return asignatura;
        }

        public async Task<AsignaturaModel> ActualizarAsignatura(int id, AsignaturaModel asignatura)
        {
            try
            {
                var existencia = await _asignaturaRepository.GetById(id);

                if (existencia.Id > 0)
                    await _asignaturaRepository.Update(asignatura);

            }
            catch (Exception ex)
            {

                return null;
            }

            return asignatura;
        }

        public async Task<AsignaturaModel> CrearAsignatura(AsignaturaModel asignatura)
        {
            try
            {
                var result = await _asignaturaRepository.Insert(asignatura);

                if (result.Id > 0)
                {
                    asignatura.Id = result.Id;
                }

            }
            catch (Exception ex)
            {

                return null;
            }

            return asignatura;
        }
    }
}
