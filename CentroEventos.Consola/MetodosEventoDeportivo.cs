using CentroEventos.Aplicacion.Entidades;
public class MetodosEventoDeportivo
{
    public void menu()
    {
        
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
        DateTime fechaHoraInicio;
        
        //cargar fecha

        return fechaHoraInicio;
    }
}