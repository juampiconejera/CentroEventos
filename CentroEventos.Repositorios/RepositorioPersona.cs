using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    readonly string _nombreArchivo = "personas.txt";
    
    private int GenerarId(){
        return 1;
    }

    public void Agregar(Persona persona)
    {
        persona.Id = GenerarId();
        using var sw = new StreamWriter(_nombreArchivo, true);  //true: agrega al final  ; false: sobreescribe
        sw.WriteLine(persona.Id);
        sw.WriteLine(persona.Dni);
        sw.WriteLine(persona.Nombre);
        sw.WriteLine(persona.Apellido);
        sw.WriteLine(persona.Email);
        sw.WriteLine(persona.Telefono);
    }

    public void Eliminar(int id){}

 /*    public void Eliminar(Persona persona)
    {
        using var sr = new StreamReader(_nombreArch);
        while(!sr.EndOfStream && ){}
    }
 */
}
