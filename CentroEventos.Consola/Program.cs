using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.CasosDeUso.PersonaCasosDeUso;
using CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Repositorios;

//Creamos las dependencias
IRepositorioPersona repoPersona = new RepositorioPersona();
IRepositorioReserva repoReserva = new RepositorioReserva();
IRepositorioEventoDeportivo repoEventoDeportivo = new RepositorioEventoDeportivo(repoReserva, repoPersona);
IServicioAutorizacionProvisorio Auth = new ServicioAutorizacionProvisiorio();
PersonaValidador personaValidador = new PersonaValidador();
EventoDeportivoValidador eventoDeportivoValidador = new EventoDeportivoValidador();
ReservaValidador reservaValidador = new ReservaValidador();

//Casos de uso PERSONA
var altaPersona = new AltaPersonaUseCase(repoPersona, Auth, personaValidador);
var bajaPersona = new BajaPersonaUseCase(repoPersona, Auth);
var modificarPersona = new ModificacionPersonaUseCase(repoPersona, Auth, personaValidador);
var listarPersonas = new ListarPersonaUseCase(repoPersona);

//Casos de uso EVENTODEPORTIVO
var altaEventoDeportivo = new AltaEventoDeportivoUseCase(repoEventoDeportivo, repoPersona, Auth, eventoDeportivoValidador);
var bajaEventoDeportivo = new BajaEventoDeportivoUseCase(repoEventoDeportivo, Auth);
var modificarEventoDeportivo = new ModificarEventoDeportivoUseCase(repoEventoDeportivo, repoPersona, Auth, eventoDeportivoValidador);
var listarEventoDeportivo = new ListarEventoDeportivoUseCase(repoEventoDeportivo);
var listarEventosConCupoDisponible = new ListarEventosConCupoDisponibleUseCase(repoEventoDeportivo);

//Casos de uso RESERVA
var altaReserva = new AltaReservaUseCase(repoEventoDeportivo, repoPersona, repoReserva, Auth, reservaValidador);
var bajaReserva = new BajaReservaUseCase(repoReserva, Auth);
var modificarReserva = new ModificarReservaUseCase(repoReserva, repoPersona, repoEventoDeportivo, Auth, reservaValidador);
var listarReserva = new ListarReservaUseCase(repoReserva);

Console.WriteLine("Sistema de Gestión del Centro Deportivo Universitario");

//MENU PRINCIPAL
var metodosPersona = new MetodosPersona();
var metodosEventoDeportivo = new MetodosEventoDeportivo();
var metodosReserva = new MetodosReserva();
bool state = true;

while (state)
{
    Console.WriteLine("Ingrese alguna de las siguientes opciones: ");
    Console.WriteLine("1. Dar de alta, modificar, eliminar o listar personas.");
    Console.WriteLine("2. Dar de alta, modificar, eliminar o listar eventos deportivos.");
    Console.WriteLine("3. Dar de alta, modificar, eliminar o listar reservas.");
    Console.WriteLine("4. Salir.");
    char opciones = char.Parse(Console.ReadLine() ?? "");

    switch (opciones)
    {
        case '1':
            Console.Clear();
            metodosPersona.menu();
            break;
        case '2':
            Console.Clear();
            metodosEventoDeportivo.menu();
            break;
        case '3':
            Console.Clear();
            metodosReserva.menu();
            break;
        case '4':
            Console.Clear();
            state = false;
            break;
    }
}

/* int ancho = opciones.Max(op => op.Length) + 4;
    string bordeSuperior = "┌" + new string('─', ancho) + "┐";
    string bordeInferior = "└" + new string('─', ancho) + "┘";
} 
Console.WriteLine(bordeSuperior);
    Console.WriteLine("│" + CenterText("MENÚ PRINCIPAL", ancho) + "│");
    Console.WriteLine("├" + new string('─', ancho) + "┤");
    foreach (var op in opciones)
        Console.WriteLine("│ " + op.PadRight(ancho - 2) + " │");
    Console.WriteLine(bordeInferior);
    Console.Write("Seleccione una opción: ");
}

string CenterText(string text, int width)
{
    int padding = (width - text.Length) / 2;
    return new string(' ', padding) + text + new string(' ', width - text.Length - padding);
}*/