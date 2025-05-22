using Aplicacion;
using CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;
using CentroEventos.Aplicacion.CasosDeUso.PersonaCasosDeUso;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Repositorios;
public class MetodosReserva
{
    public void menu(IRepositorioPersona repoPersona, IRepositorioReserva repoReserva, IRepositorioEventoDeportivo repoEventoDeportivo, IServicioAutorizacionProvisorio Auth, AltaReservaUseCase altaReserva, BajaReservaUseCase bajaReserva, ModificarReservaUseCase modificarReserva, ListarReservaUseCase listarReserva, ListarPersonaUseCase listarPersona)
    {
        bool estado = true;
        MetodosComunes metodosComunes = new MetodosComunes();
        while(estado){
            string[] opcionesMenu = {
                "1. Dar de alta una reserva.",
                "2. Modificar una reserva registrada.",
                "3. Eliminar una reserva registrada.",
                "4. Listar todas las reservas registradas.",
                "5. Volver."
            };
            metodosComunes.MostrarMenuConCuadro("MENÚ RESERVAS", opcionesMenu);
            char opciones = char.Parse(Console.ReadLine() ?? "");

            switch (opciones)
            {
                case '1':
                    Reserva nuevaReserva = leerReserva();
                    altaReserva.Ejecutar(nuevaReserva, listarPersona.Ejecutar()[0].Id);
                    Console.WriteLine("Reserva agregada correctamente!");
                    break;
                case '2':
                    Reserva reservaModificar = leerReserva();
                    reservaModificar.Id = metodosComunes.leerId("reserva");
                    modificarReserva.Ejecutar(reservaModificar, listarPersona.Ejecutar()[0].Id);
                    Console.WriteLine("Reserva modificada correctamente!");
                    break;
                case '3':
                    int idReservaEliminar = metodosComunes.leerId("reserva");
                    bajaReserva.Ejecutar(idReservaEliminar, listarPersona.Ejecutar()[0].Id);
                    Console.WriteLine("Reserva eliminada correctamente!");
                    break;
                case '4':
                    List<Reserva> listaReservas = listarReserva.Ejecutar();
                    foreach (Reserva r in listaReservas)
                    {
                        Console.WriteLine(r.ToString());
                    }
                    Console.WriteLine("Reservas listadas correctamente!");
                    break;
                //Volvemos
                case '5':
                    estado = false;
                    break;
            }
        }
    }
    private Reserva leerReserva()
    {
        Console.WriteLine("Ingrese el Id de la persona que realiza la reserva: ");
        int personaId = int.Parse(Console.ReadLine() ?? "");
        Console.WriteLine("Ingrese el Id del evento deportivo a reservar: ");
        int eventoDeportivoId = int.Parse(Console.ReadLine() ?? "");
        return new Reserva(personaId, eventoDeportivoId);
    }
}