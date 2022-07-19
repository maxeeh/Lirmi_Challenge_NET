using Lirmi.Challenge.WebApp;
using Lirmi.Challenge.WebApp.Services.Asignatura;
using Lirmi.Challenge.WebApp.Services.Colegio;
using Lirmi.Challenge.WebApp.Services.Curso;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7253") });
builder.Services.AddScoped<IColegioService, ColegioService>();
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IAsignaturaService, AsignaturaServices>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
