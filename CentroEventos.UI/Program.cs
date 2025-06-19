using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.Servicios;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios;
using CentroEventos.UI.Components;
using CentroEventos.Aplicacion.CasosDeUso.PersonaCasosDeUso;
using CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;
using CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;
using CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;

CentroEventosSqlite.Inicializar();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CentroEventosContext>();

// Repositorios
builder.Services.AddScoped<IRepositorioPersona, RepositorioPersona>();
builder.Services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReserva>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

// Use cases
builder.Services.AddTransient<AltaPersonaUseCase>();
builder.Services.AddTransient<ModificacionPersonaUseCase>();
builder.Services.AddTransient<BajaPersonaUseCase>();
builder.Services.AddTransient<ListarPersonaUseCase>();

builder.Services.AddTransient<AltaEventoDeportivoUseCase>();
builder.Services.AddTransient<ModificarEventoDeportivoUseCase>();
builder.Services.AddTransient<BajaEventoDeportivoUseCase>();
builder.Services.AddTransient<ListarAsistenciaAEventoUseCase>();
builder.Services.AddTransient<ListarEventoDeportivoUseCase>();
builder.Services.AddTransient<ListarEventosConCupoDisponibleUseCase>();

builder.Services.AddTransient<AltaReservaUseCase>();
builder.Services.AddTransient<AltaReservaUseCase>();
builder.Services.AddTransient<AltaReservaUseCase>();
builder.Services.AddTransient<ListarReservaUseCase>();

builder.Services.AddTransient<AltaUsuarioUseCase>();
builder.Services.AddTransient<ModificarUsuarioUseCase>();
builder.Services.AddTransient<BajaUsuarioUseCase>();
builder.Services.AddTransient<ListarUsuarioUseCase>();

// Servicios
builder.Services.AddTransient<IServicioAutorizacion, ServicioAutorizacion>();
// Validadores
builder.Services.AddTransient<PersonaValidador>();
builder.Services.AddTransient<EventoDeportivoValidador>();
builder.Services.AddTransient<ReservaValidador>();
builder.Services.AddTransient<UsuarioValidador>();
//Sesion


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
