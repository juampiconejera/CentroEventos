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
        while(estado){
            
            Console.WriteLine("Ingrese alguno de los siguientes casos: ");
            Console.WriteLine("1. Dar de alta una reserva.");
            Console.WriteLine("2. Modificar una reserva registrada.");
            Console.WriteLine("3. Eliminar una reserva registrada.");
            Console.WriteLine("4. Listar todas las reservas registradas.");
            Console.WriteLine("5. Volver.");
            char opciones = char.Parse(Console.ReadLine() ?? "");

            switch (opciones)
            {
                case '1':
                    Console.Clear();
                    Reserva nuevaReserva = leerReserva();
                    altaReserva.Ejecutar(nuevaReserva, listarPersona.Ejecutar()[0].Id);              //tenemos que ver como pasarle el admin
                    Console.Clear();
                    Console.WriteLine("Reserva agregada correctamente!");
                    break;
                case '2':
                    Console.Clear();
                    Reserva reservaModificar = leerReserva();
                    modificarReserva.Ejecutar(reservaModificar, listarPersona.Ejecutar()[0].Id);     //tenemos que ver como pasarle el admin
                    Console.Clear();
                    Console.WriteLine("Reserva modificada correctamente!");
                    break;
                case '3':
                    Console.Clear();
                    MetodosComunes metodosComunes = new MetodosComunes();
                    int idReservaEliminar = metodosComunes.leerId("reserva");
                    bajaReserva.Ejecutar(idReservaEliminar, listarPersona.Ejecutar()[0].Id);          //tenemos que ver como pasarle el admin
                    Console.Clear();
                    Console.WriteLine("Reserva eliminada correctamente!");
                    break;
                case '4':
                    Console.Clear();
                    List<Reserva> listaReservas = listarReserva.Ejecutar();
                    foreach (Reserva r in listaReservas)
                    {
                        Console.WriteLine(r.ToString());
                    }
                    Console.Clear();
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
        return new Reserva(personaId, eventoDeportivoId, DateTime.Now, EstadoAsistencia.Pendiente);
    }
}