using System.Net.Http.Json;
using Lirmi.Domain.Models;

namespace Lirmi.Challenge.WebApp.Services.Curso
{
    public class CursoService : ICursoService
    {
        private readonly HttpClient _http;

        public CursoService(HttpClient http)
        {
            this._http = http;
        }

        public List<CursoModel> Cursos { get; set; }

        public async Task ObtenerCursos()
        {
            var result = await _http.GetFromJsonAsync<List<CursoModel>>("/api/curso");

            if (result != null)
                Cursos = result;

        }

        public async Task<CursoModel> ObtenerCursoPorId(int id)
        {
            var result = await _http.GetFromJsonAsync<CursoModel>($"/api/curso/{id}");
            if (result != null)
                return result;
            throw new Exception("Hero not found!");
        }

        public async Task ActualizarCurso(CursoModel curso)
        {

            var result = await _http.PutAsJsonAsync($"/api/curso/{curso.Id}", curso);


            if (result.IsSuccessStatusCode)
                await ObtenerCursos();

        }

        public async Task CrearCurso(CursoModel curso)
        {
            var result = await _http.PostAsJsonAsync("/api/curso", curso);

            if (result.IsSuccessStatusCode)
                await ObtenerCursos();
        }
    }
}
