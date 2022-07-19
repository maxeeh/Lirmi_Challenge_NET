using Lirmi.Aplication.Services;
using Lirmi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lirmi.WebApi.Controllers
{
    [Route("api/asignatura")]
    [ApiController]
    public class AsignaturaController : ControllerBase
    {
        private readonly AsignaturaService _asignaturaService;

        public AsignaturaController(AsignaturaService asignaturaService)
        {
            this._asignaturaService = asignaturaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AsignaturaModel>>> RetornarAsignaturassBandeja()
        {
            return Ok(await _asignaturaService.AsignaturasGetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AsignaturaModel>> ObtenerAsignaturaPorId(int id)
        {
            return Ok(await _asignaturaService.ObtenerAsignaturaPorId(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AsignaturaModel>> ActualizarAsignatura(int id, AsignaturaModel asignatura)
        {
            var result = await _asignaturaService.ActualizarAsignatura(id, asignatura);

            if (result.Id == 0)
                return BadRequest();


            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ColegioModel>> CreateAsignatura(AsignaturaModel asignatura)
        {
            var result = await _asignaturaService.CrearAsignatura(asignatura);

            if (result.Id == 0)
                return BadRequest();

            return Ok(result);
        }

    }
}
