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
    public class ColegioService
    {
        private readonly IColegioRepository _colegioRepository;
        private readonly ILogger<ColegioService> _logger;
        public ColegioService(IColegioRepository colegioRepository)
        {
            this._colegioRepository = colegioRepository;
        }

        public async Task<List<ColegioModel>> ColegiosGetAll()
        {
            var colecigos = new List<ColegioModel>();
            try
            {
                colecigos = await _colegioRepository.GetAll();
            }
            catch (Exception ex)
            {

            }
            return colecigos;
        }

        public async Task<ColegioModel> ObtenerColegioPorId(int id)
        {
            var colecigos = new ColegioModel();
            try
            {
                colecigos = await _colegioRepository.GetById(id);
            }
            catch (Exception ex)
            {


            }
            return colecigos;
        }

        public  async Task<ColegioModel> ActualizarColegio(int id,ColegioModel colegio)
        {
            try
            {
                var existencia = await _colegioRepository.GetById(id);

                if (existencia.Id > 0)
                    await _colegioRepository.Update(colegio);

            }
            catch (Exception ex)
            {

                return null;
            }

            return colegio;
        }

        public async Task<ColegioModel> CrearColegio(ColegioModel colegio)
        {
            try
            {
                var result = await _colegioRepository.Insert(colegio);

                if (result.Id >  0)
                {
                    colegio.Id = result.Id;
                }

            }
            catch (Exception ex)
            {

                return null;
            }

            return colegio;
        }
    }
}
