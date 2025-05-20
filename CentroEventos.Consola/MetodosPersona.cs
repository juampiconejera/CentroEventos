using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.CasosDeUso.PersonaCasosDeUso;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Validadores;

public class MetodosPersona
{
    public void menu()
    {
        IRepositorioPersona repoPersona = new RepositorioPersona();
        IServicioAutorizacionProvisorio Auth = new ServicioAutorizacionProvisiorio();
        PersonaValidador personaValidador = new PersonaValidador();
        var altaPersona = new AltaPersonaUseCase(repoPersona, Auth, personaValidador);
        var bajaPersona = new BajaPersonaUseCase(repoPersona, Auth);
        var modificarPersona = new ModificacionPersonaUseCase(repoPersona, Auth, personaValidador);
        var listarPersonas = new ListarPersonaUseCase(repoPersona);
        
        Console.WriteLine("Ingrese alguno de los siguientes casos: ");
        Console.WriteLine("1. Dar de alta una persona.");
        Console.WriteLine("2. Modificar una persona registrada.");
        Console.WriteLine("3. Eliminar una persona registrada.");
        Console.WriteLine("4. Listar a todas las personas registradas.");
        Console.WriteLine("5. Volver.");
        char opciones = char.Parse(Console.ReadLine() ?? "");

        switch(opciones)
        {
            case '1':
                Console.Clear();
                Persona nuevaPersona = leerPersona();
                altaPersona.Ejecutar(nuevaPersona, 1);          //tenemos que ver como pasarle el admin 
                Console.Clear();
                Console.WriteLine("Persona agregada correctamente!");
                break;
            case '2':
                
                break;
            case '3':
                Console.Clear();
                MetodosComunes metodosComunes = new MetodosComunes();
                break;
            case '4':
                break;
            case '5':
                break;
        }
    }
    
    private Persona leerPersona()
    {
        Console.WriteLine("LECTURA DE PERSONA");
        Console.WriteLine("Ingrese el DNI de la persona: ");
        string dni = Console.ReadLine() ?? "";
        Console.WriteLine("Ingrese el nombre de la persona: ");
        string nombre = Console.ReadLine() ?? "";
        Console.WriteLine("Ingrese el apellido de la persona: ");
        string apellido = Console.ReadLine() ?? "";
        Console.WriteLine("Ingrese el email de la persona: ");
        string email = Console.ReadLine() ?? "";
        Console.WriteLine("Ingrese el telefono de la persona: ");
        string telefono = Console.ReadLine()??"";
        return new Persona(dni, nombre, apellido, email, telefono);
    }
}