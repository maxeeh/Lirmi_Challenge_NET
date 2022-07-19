using Lirmi.Aplication.Services;
using Lirmi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Lirmi.WebApi.Controllers
{
    [Route("api/curso")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly CursoService _cursoService;

        public CursoController(CursoService _cursoService)
        {
            this._cursoService = _cursoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CursoModel>>> RetornarCursoBandeja()
        {
            return Ok(await _cursoService.CursosGetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CursoModel>> ObtenerCursoPorId(int id)
        {
            return Ok(await _cursoService.ObtenerCursoPorId(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CursoModel>> ActualizarCurso(int id, CursoModel curso)
        {
            var result = await _cursoService.ActualizarCurso(id, curso);

            if (result.Id == 0)
                return BadRequest();


            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ColegioModel>> CreateCurso(CursoModel cruso)
        {
            var result = await _cursoService.CrearCurso(cruso);

            if (result.Id == 0)
                return BadRequest();

            return Ok(result);
        }
    }
}
