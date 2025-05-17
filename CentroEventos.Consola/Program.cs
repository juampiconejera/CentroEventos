using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.CasosDeUso;

IRepositorioPersona repo = new RepositorioPersona();

var agregarPersona = new AltaPersonaUseCase(repo);

var persona = new Persona
{
    Dni = "123456",
    Nombre = "fran",
    Apellido = "conejera",
    Email = "tutu@gmail.com",
    Telefono = "14312345"
};

agregarPersona.Ejecutar(persona, 1);
agregarPersona.Ejecutar(persona, 1);

Console.WriteLine("Listo");