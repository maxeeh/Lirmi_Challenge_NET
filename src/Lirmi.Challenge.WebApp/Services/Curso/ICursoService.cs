using Lirmi.Domain.Models;

namespace Lirmi.Challenge.WebApp.Services.Curso
{
    public interface ICursoService
    {
        List<CursoModel> Cursos { get; set; }

        Task ObtenerCursos();
        Task<CursoModel> ObtenerCursoPorId(int id);
        Task ActualizarCurso(CursoModel Curso);
        Task CrearCurso(CursoModel curso);
    }
}
