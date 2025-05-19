using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;
using Microsoft.VisualBasic;

namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    readonly string _nombreArchivo = "personas.txt";

    private int GenerarId()
    {
        return Listar().Count();
    }

    public void Agregar(Persona persona)
    {
        persona.Id = GenerarId();
        using var sw = new StreamWriter(_nombreArchivo, true);
        sw.WriteLine(persona.Id);
        sw.WriteLine(persona.Dni);
        sw.WriteLine(persona.Nombre);
        sw.WriteLine(persona.Apellido);
        sw.WriteLine(persona.Email);
        sw.WriteLine(persona.Telefono);
    }

    public void Eliminar(int id)
    {
        var listaTotal = Listar();
        foreach (Persona p in listaTotal)
        {
            if (p.Id == id)
            {
                p.Telefono = "Eliminado";
                break;
            }
        }

        using var sw = new StreamWriter(_nombreArchivo, false);
        foreach (Persona p in listaTotal)
        {
            sw.WriteLine(p.Id); sw.WriteLine(p.Dni); sw.WriteLine(p.Nombre); sw.WriteLine(p.Apellido); sw.WriteLine(p.Email); sw.WriteLine(p.Telefono);
        }
    }

    public void Modificar(Persona persona)
    {
        var listaTotal = Listar();

        for (int i = 0; i < listaTotal.Count; i++)
        {
            if (listaTotal[i].Id == persona.Id)
            {
                listaTotal[i] = persona;
                break;
            }
        }

        using var sw = new StreamWriter(_nombreArchivo, false);
        foreach (Persona p in listaTotal)
        {
            sw.WriteLine(p.Id); sw.WriteLine(p.Dni); sw.WriteLine(p.Nombre); sw.WriteLine(p.Apellido); sw.WriteLine(p.Email); sw.WriteLine(p.Telefono);
        }
    }

    public List<Persona> Listar()
    {
        var listaTotal = new List<Persona>();
        using var sr = new StreamReader(_nombreArchivo);
        while (!sr.EndOfStream)
        {
            var persona = new Persona();
            persona.Id = int.Parse(sr.ReadLine() ?? ""); persona.Dni = sr.ReadLine(); persona.Nombre = sr.ReadLine(); persona.Apellido = sr.ReadLine(); persona.Email = sr.ReadLine(); persona.Telefono = sr.ReadLine();
            listaTotal.Add(persona);
        }

        return listaTotal;
    }
    public bool ExistePorId(int id)
    {
        var listaTotal = Listar();
        foreach (Persona p in listaTotal)
        {
            if (p.Id == id)
            {
                return true;
            }
        }
        return false;
    }

    public bool ExistePorDni(string dni)
    {
        var listaTotal = Listar();
        foreach (Persona p in listaTotal)
        {
            if (p.Dni == dni)
            {
                return true;
            }
        }
        return false;
    }
    public bool ExistePorEmail(string email)
    {
        var listaTotal = Listar();
        foreach (Persona p in listaTotal)
        {
            if (p.Email == email)
            {
                return true;
            }
        }
        return false;
    }
}
