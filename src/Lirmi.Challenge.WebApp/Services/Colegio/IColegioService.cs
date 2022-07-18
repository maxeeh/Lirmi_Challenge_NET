using Lirmi.Domain.Models;

namespace Lirmi.Challenge.WebApp.Services.Colegio
{
    public interface IColegioService
    {
        List<ColegioModel> Colegios { get; set; }
        Task ObtenerColegios();
        Task<ColegioModel> ObtenerColegioPorId(int id);
        Task ActualizarColegio(ColegioModel colegio);
        Task CrearColegio(ColegioModel colegio);
    }
}
