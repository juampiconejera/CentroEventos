using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.CasosDeUso.PersonaCasosDeUso;
using CentroEventos.Repositorios;
using CentroEventos.Aplicacion.Validadores;
using CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;

public class MetodosPersona
{
    public void menu(IRepositorioPersona repoPersona, IServicioAutorizacionProvisorio Auth, PersonaValidador personaValidador, AltaPersonaUseCase altaPersona, BajaPersonaUseCase bajaPersona, ModificacionPersonaUseCase modificarPersona, ListarPersonaUseCase listarPersona, ListarAsistenciaAEventoUseCase listarAsistencia)
    {
        bool estado = true;
        MetodosComunes metodosComunes = new MetodosComunes();
        while(estado){
            string[] opcionesMenu = {
                "Ingrese alguno de los siguientes casos: ",
                "1. Dar de alta una persona.",
                "2. Modificar una persona registrada.",
                "3. Eliminar una persona registrada.",
                "4. Listar a todas las personas registradas.",
                "5. Listar asistencia a un evento determinado.",
                "6. Volver.",
            };
            metodosComunes.MostrarMenuConCuadro("MENU PERSONAS", opcionesMenu);

            char opciones = char.Parse(Console.ReadLine() ?? "");

            switch (opciones)
            {
                //Dar de alta una persona
                case '1':
                    Persona nuevaPersona = leerPersona();
                    altaPersona.Ejecutar(nuevaPersona, listarPersona.Ejecutar()[0].Id);          //tenemos que ver como pasarle el admin 
                    Console.WriteLine("Persona agregada correctamente!");
                    break;
                //Modificar una persona
                case '2':
                    Persona personaModificar = leerPersona();
                    personaModificar.Id = metodosComunes.leerId("persona");
                    modificarPersona.Ejecutar(personaModificar, listarPersona.Ejecutar()[0].Id);     //tenemos que ver como pasarle el admin 
                    Console.WriteLine("Persona modificada correctamente!");
                    break;
                //Eliminar una persona
                case '3':
                    int idPersonaEliminar = metodosComunes.leerId("persona");
                    bajaPersona.Ejecutar(idPersonaEliminar, listarPersona.Ejecutar()[0].Id);         //tenemos que ver como pasarle el admin 
                    Console.WriteLine("Persona eliminada correctamente!");
                    break;
                //Listar a todas las personas
                case '4':
                    List<Persona> listaPersonas = listarPersona.Ejecutar();
                    foreach (Persona p in listaPersonas)
                    {
                        Console.WriteLine(p);
                    }
                    Console.WriteLine("Personas listadas correctamente!");
                    break;
                //Listar a todas las personas presentes en un evento deportivo pasado
                case '5':
                    int idEvento = metodosComunes.leerId("evento deportivo");
                    List<Persona> listaAsistentes = listarAsistencia.Ejecutar(idEvento);
                    foreach (Persona p in listaAsistentes)
                    {
                        Console.WriteLine(p.ToString());
                    }
                    Console.WriteLine("Personas presentes listadas correctamente!");
                    break;
                //Volvemos 
                case '6':
                    estado = false;
                    break;
            }
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