using System;
using CentroEventos.Aplicacion.CasosDeUso;
using CentroEventos.Aplicacion.CasosDeUso.PersonaCasosDeUso;
using CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;
using CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Repositorios;

namespace CentroEventos.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
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
            var listarPersona = new ListarPersonaUseCase(repoPersona);

            //Casos de uso EVENTODEPORTIVO
            var altaEventoDeportivo = new AltaEventoDeportivoUseCase(repoEventoDeportivo, repoPersona, Auth, eventoDeportivoValidador);
            var bajaEventoDeportivo = new BajaEventoDeportivoUseCase(repoEventoDeportivo, Auth);
            var modificarEventoDeportivo = new ModificarEventoDeportivoUseCase(repoEventoDeportivo, repoPersona, Auth, eventoDeportivoValidador);
            var listarEventoDeportivo = new ListarEventoDeportivoUseCase(repoEventoDeportivo);
            var listarEventosConCupoDisponible = new ListarEventosConCupoDisponibleUseCase(repoEventoDeportivo);
            var listarAsistencia = new ListarAsistenciaAEventoUseCase(repoEventoDeportivo);

            //Casos de uso RESERVA
            var altaReserva = new AltaReservaUseCase(repoEventoDeportivo, repoPersona, repoReserva, Auth, reservaValidador);
            var bajaReserva = new BajaReservaUseCase(repoEventoDeportivo, repoReserva, Auth);
            var modificarReserva = new ModificarReservaUseCase(repoReserva, repoPersona, repoEventoDeportivo, Auth, reservaValidador);
            var listarReserva = new ListarReservaUseCase(repoReserva);


            if (!File.Exists("personas.txt")){
                File.Create("personas.txt").Close();
                altaPersona.Ejecutar(new Persona("Admin","Admin","Admin","Admin","Admin"),1);
            }
            if (!File.Exists("eventos.txt")) File.Create("eventos.txt").Close();
            if (!File.Exists("reservas.txt")) File.Create("reservas.txt").Close();


            Console.WriteLine("Sistema de Gestión del Centro Deportivo Universitario");

            //MENU PRINCIPAL
            var metodosPersona = new MetodosPersona();
            var metodosEventoDeportivo = new MetodosEventoDeportivo();
            var metodosReserva = new MetodosReserva();
            var metodosComunes = new MetodosComunes();
            bool estado = true;

            while (estado)
            {
                Console.Clear();
                string[] opcionesMenu = {
                    "1. Dar de alta, modificar, eliminar o listar personas.",
                    "2. Dar de alta, modificar, eliminar o listar eventos deportivos.",
                    "3. Dar de alta, modificar, eliminar o listar reservas.",
                    "4. Salir."
                };

                metodosComunes.MostrarMenuConCuadro("MENU PRINCIPAL", opcionesMenu);

                char opciones = char.Parse(Console.ReadLine() ?? "");

                switch (opciones)
                {
                    case '1':
                        Console.Clear();
                        metodosPersona.menu(repoPersona,Auth,personaValidador,altaPersona,bajaPersona,modificarPersona,listarPersona,listarAsistencia);
                        break;
                    case '2':
                        Console.Clear();
                        metodosEventoDeportivo.menu(repoPersona, repoReserva, repoEventoDeportivo, Auth, eventoDeportivoValidador, altaEventoDeportivo, bajaEventoDeportivo, modificarEventoDeportivo, listarEventoDeportivo, listarEventosConCupoDisponible, listarPersona);
                        break;
                    case '3':
                        Console.Clear();
                        metodosReserva.menu(repoPersona, repoReserva, repoEventoDeportivo, Auth, altaReserva, bajaReserva, modificarReserva, listarReserva, listarPersona);
                        break;
                    case '4':
                        Console.Clear();
                        estado = false;
                        break;
                }
            }
        }
    }
}