using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;
using Microsoft.VisualBasic;

namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    readonly string _nombreArchivo = "personas.txt";

    public void Agregar(Persona persona)
    {
        using (var context = new CentroDeportivoContext())
        {
            context.Add(persona);
            context.SaveChanges();
        }
    }

    public void Eliminar(int id)
    {
        using (var context = new CentroDeportivoContext())
        {
            Persona? persona = context.Personas.FirstOrDefault(p => p.Id == id);
            if (persona != null)
            {
                context.Remove(persona);
                context.SaveChanges();
            }
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
        using (var context = new CentroDeportivoContext())
        {
            return context.Personas.ToList();
        }
    }
    public bool ExistePorId(int id)
    {
        using (var context = new CentroDeportivoContext())
        {
            Persona? persona = context.Personas.FirstOrDefault(p => p.Id == id);
            return persona != null;
        }
    }

    public bool ExistePorDni(string? dni)
    {
        using (var context = new CentroDeportivoContext())
        {
            Persona? persona = context.Personas.FirstOrDefault(p => p.Dni == dni);
            return persona != null;
        }
    }
    public bool ExistePorEmail(string? email)
    {
        using (var context = new CentroDeportivoContext())
        {
            Persona? persona = context.Personas.FirstOrDefault(p => p.Email == email);
            return persona != null;
        }
    }
}
