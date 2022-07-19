using Lirmi.Domain.Models;

namespace Lirmi.Challenge.WebApp.Services.Asignatura
{
    public interface IAsignaturaService
    {
        List<AsignaturaModel> Asignaturas { get; set; }

        Task ObtenerAsignaturas();
        Task<AsignaturaModel> ObtenerAsignaturaPorId(int id);
        Task ActualizarAsignatura(AsignaturaModel asignatura);
        Task CrearAsignatura(ColegioModel colegio);
    }
}
