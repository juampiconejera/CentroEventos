using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.CasosDeUso.EventoDeportivoCasosDeUso;
using Microsoft.VisualBasic;

namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{
    public void Agregar(Persona persona)
    {
        using (var context = new CentroEventosContext())
        {
            context.Add(persona);
            context.SaveChanges();
        }
    }

    public void Eliminar(int id)
    {
        using (var context = new CentroEventosContext())
        {
            Persona? persona = context.Personas.FirstOrDefault(p => p.Id == id);
            if (persona != null)
            {
                context.Remove(persona);
                context.SaveChanges();
            }
        }
    }

    public void Modificar(Persona personaNueva)
    {
        using (var context = new CentroEventosContext())
        {
            Persona? personaVieja = context.Personas.FirstOrDefault(p => p.Id == personaNueva.Id);
            if (personaVieja != null)
            {
                personaVieja.Nombre = personaNueva.Nombre;
                personaVieja.Apellido = personaNueva.Apellido;
                personaVieja.Dni = personaNueva.Dni;
                personaVieja.Email = personaNueva.Email;
                personaVieja.Telefono = personaNueva.Telefono;
                context.SaveChanges();
            }
        }
    }

    public List<Persona> Listar()
    {
        using (var context = new CentroEventosContext())
        {
            return context.Personas.ToList();
        }
    }
    public bool ExistePorId(int id)
    {
        using (var context = new CentroEventosContext())
        {
            Persona? persona = context.Personas.FirstOrDefault(p => p.Id == id);
            return persona != null;
        }
    }

    public bool ExistePorDni(string? dni)
    {
        using (var context = new CentroEventosContext())
        {
            Persona? persona = context.Personas.FirstOrDefault(p => p.Dni == dni);
            return persona != null;
        }
    }
    public bool ExistePorEmail(string? email)
    {
        using (var context = new CentroEventosContext())
        {
            Persona? persona = context.Personas.FirstOrDefault(p => p.Email == email);
            return persona != null;
        }
    }
}
