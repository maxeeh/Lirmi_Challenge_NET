using Lirmi.Aplication.Services;
using Lirmi.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lirmi.WebApi.Controllers
{
    [ApiController]
    [Route("/api/colegio")]
    public class ColegioController : ControllerBase
    {
        private readonly ColegioService _colegioService;

        public ColegioController(ColegioService colegioService)
        {
            this._colegioService = colegioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ColegioModel>>> RetornarAreasBandeja()
        {
            return Ok(await _colegioService.ColegiosGetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ColegioModel>> ObtenerColegioPorId(int id)
        {
            return Ok(await _colegioService.ObtenerColegioPorId(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ColegioModel>> ActualizarColegio(int id,ColegioModel colegio)
        {
            var result = await _colegioService.ActualizarColegio(id, colegio);

            if (result.Id ==0)
                return BadRequest();


            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<ColegioModel>> CreateColegio(ColegioModel colegio)
        {
            var result = await _colegioService.CrearColegio(colegio);

            if (result.Id == 0)
                return BadRequest();

            return Ok(result);
        }
    }
}
