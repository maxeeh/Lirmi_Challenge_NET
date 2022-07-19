using System.Net.Http.Json;
using Lirmi.Domain.Models;

namespace Lirmi.Challenge.WebApp.Services.Asignatura
{
    public class AsignaturaServices : IAsignaturaService
    {
        private readonly HttpClient _http;

        public AsignaturaServices(HttpClient http)
        {
            this._http = http;
        }

        public List<AsignaturaModel> Asignaturas { get; set; }

        public async Task ObtenerAsignaturas()
        {
            var result = await _http.GetFromJsonAsync<List<AsignaturaModel>>("/api/asignatura");

            if (result != null)
                Asignaturas = result;

        }
        public async Task<AsignaturaModel> ObtenerAsignaturaPorId(int id)
        {
            var result = await _http.GetFromJsonAsync<AsignaturaModel>($"/api/asignatura/{id}");
            if (result != null)
                return result;
            throw new Exception("Hero not found!");
        }
        public async Task ActualizarAsignatura(AsignaturaModel asignatura)
        {

            var result = await _http.PutAsJsonAsync($"/api/asignatura/{asignatura.Id}", asignatura);


            if (result.IsSuccessStatusCode)
                await ObtenerAsignaturas();

        }
        public async Task CrearAsignatura(ColegioModel colegio)
        {
            var result = await _http.PostAsJsonAsync("/api/colegio", colegio);

            if (result.IsSuccessStatusCode)
                await ObtenerAsignaturas();
        }
    }
}
