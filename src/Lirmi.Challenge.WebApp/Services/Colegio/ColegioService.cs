using System.Net;
using System.Net.Http.Json;
using Lirmi.Domain.Models;

namespace Lirmi.Challenge.WebApp.Services.Colegio
{
    public class ColegioService : IColegioService
    {
        private readonly HttpClient _http;

        public ColegioService(HttpClient http)
        {
            _http = http;

        }
        public List<ColegioModel> Colegios { get; set; }

        public async Task ObtenerColegios()
        {
            var result = await _http.GetFromJsonAsync<List<ColegioModel>>("/api/colegio");

            if (result != null)
                Colegios = result;

        }

        public async Task<ColegioModel> ObtenerColegioPorId(int id)
        {
            var result = await _http.GetFromJsonAsync<ColegioModel>($"/api/colegio/{id}");
            if (result != null)
                return result;
            throw new Exception("Hero not found!");
        }

        public async Task ActualizarColegio(ColegioModel colegio)
        {

            var result = await _http.PutAsJsonAsync($"/api/colegio/{colegio.Id}", colegio);


            if (result.IsSuccessStatusCode)
                await ObtenerColegios();

        }

        public async Task CrearColegio(ColegioModel colegio)
        {
            var result = await _http.PostAsJsonAsync("/api/colegio", colegio);

            if (result.IsSuccessStatusCode)
                await ObtenerColegios();
        }


    }
}
