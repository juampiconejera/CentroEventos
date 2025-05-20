using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;
using CentroEventos.Aplicacion.CasosDeUso.PersonaCasosDeUso;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.CasosDeUso.ReservaCasosDeUso;
public class MetodosEventoDeportivo
{
    public void menu(IRepositorioPersona repoPersona, IRepositorioReserva repoReserva, IRepositorioEventoDeportivo repoEventoDeportivo, IServicioAutorizacionProvisorio Auth, EventoDeportivoValidador eventoDeportivoValidador, AltaEventoDeportivoUseCase altaEvento, BajaEventoDeportivoUseCase bajaEvento, ModificarEventoDeportivoUseCase modificarEvento, ListarEventoDeportivoUseCase listarEventoDeportivo, ListarEventosConCupoDisponibleUseCase listarEventosDisponibles, ListarPersonaUseCase listarPersona)
    {
        MetodosComunes metodosComunes = new MetodosComunes();
        bool estado = true;
        while(estado) {
            Console.WriteLine("Ingrese alguno de los siguientes casos: ");
            Console.WriteLine("1. Dar de alta un evento deportivo.");
            Console.WriteLine("2. Modificar un evento deportivo registrado.");
            Console.WriteLine("3. Eliminar un evento deportivo registrado.");
            Console.WriteLine("4. Listar a todos los eventos deportivos registrados.");
            Console.WriteLine("5. Listar a todos los eventos con cupo disponible.");
            Console.WriteLine("6. Volver.");
            
            char opciones = char.Parse(Console.ReadLine() ?? "");
            switch (opciones)
            {
                //Dar de alta evento deportivo
                case '1':
                    Console.Clear();
                    EventoDeportivo nuevoEvento = leerEventoDeportivo();
                    altaEvento.Ejecutar(nuevoEvento, listarPersona.Ejecutar()[0].Id);                     //tenemos que ver como pasarle el admin 
                    Console.Clear();
                    Console.WriteLine("Evento agregado correctamente!");
                    break;
                //Modificar evento deportivo
                case '2':
                    Console.Clear();
                    EventoDeportivo eventoModificar = leerEventoDeportivo();
                    modificarEvento.Ejecutar(eventoModificar, listarPersona.Ejecutar()[0].Id);                //tenemos que ver como pasarle el admin 
                    Console.Clear();
                    Console.WriteLine("Evento modificado correctamente!");
                    break;
                //Eliminar evento deportivo  
                case '3':
                    Console.Clear();
                    int idEventoEliminar = metodosComunes.leerId("evento deportivo");
                    bajaEvento.Ejecutar(idEventoEliminar, listarPersona.Ejecutar()[0].Id);                           //tenemos que ver como pasarle el admin 
                    Console.Clear();
                    Console.WriteLine("Evento eliminado correctamente!");
                    break;
                case '4':
                    Console.Clear();
                    listarEventoDeportivo.Ejecutar();
                    Console.Clear();
                    Console.WriteLine("Eventos listados correctamente!");
                    break;
                case '5':
                    Console.Clear();
                    listarEventosDisponibles.Ejecutar(metodosComunes.leerId("evento deportivo"));
                    break;
                case '6':
                    estado = false;
                    break;       
            }

        }


    }
    private EventoDeportivo leerEventoDeportivo()
    {
        Console.WriteLine("LECTURA DE EVENTO DEPORTIVO");
        Console.WriteLine("Ingrese el nombre del evento deportivo: ");
        string nombre = Console.ReadLine()??"";
        Console.WriteLine("Ingrese la descripcion del evento deportivo: ");
        string descripcion = Console.ReadLine()??"";
        Console.WriteLine("Ingrese la fecha y hora de inicio del evento deportivo: ");
        //crear metodo para cargar datetime
        DateTime fechaHoraInicio = leerFechaHoraInicio();
        Console.WriteLine("Ingrese la duracion (en horas) del evento deportivo: ");
        double duracionHoras = double.Parse(Console.ReadLine()??"");
        Console.WriteLine("Ingrese el cupo maximo del evento deportivo: ");
        int cupoMaximo = int.Parse(Console.ReadLine()??"");
        Console.WriteLine("Ingrese el Id del responsable del evento deportivo: ");
        int responsableId = int.Parse(Console.ReadLine()??"");
        return new EventoDeportivo(nombre, descripcion, fechaHoraInicio, duracionHoras, cupoMaximo, responsableId);
    }

    private DateTime leerFechaHoraInicio()      //aca deberiamos chequear fecha valida
    {
        Console.WriteLine("Ingrese el año: ");
        int a = int.Parse(Console.ReadLine() ?? "");
        Console.WriteLine("Ingrese el mes: ");
        int m = int.Parse(Console.ReadLine() ?? "");
        Console.WriteLine("Ingrese el dia: ");
        int d = int.Parse(Console.ReadLine() ?? "");
        Console.WriteLine("Ingrese la hora: ");
        int h = int.Parse(Console.ReadLine() ?? "");
        Console.WriteLine("Ingrese los minutos: ");
        int min = int.Parse(Console.ReadLine() ?? "");
        Console.WriteLine("Ingrese los segundos: ");
        int s = int.Parse(Console.ReadLine() ?? "");

        DateTime fechaHoraInicio = new DateTime(a, m, d, h, min, 0);
        return fechaHoraInicio;
    }
}