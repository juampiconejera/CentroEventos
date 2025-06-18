using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Repositorios;

public class RepositorioUsuario : IRepositorioUsuario
{
    public void Agregar(Usuario usuario)
    {
        using (var context = new CentroEventosContext())
        {
            context.Add(usuario);
            context.SaveChanges();
        }
    }

    public void Eliminar(int id)
    {
        using (var context = new CentroEventosContext())
        {
            Usuario? usuario = context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                context.Remove(usuario);
                context.SaveChanges();
            }
        }
    }

    public bool ExistePorEmail(string email)
    {
        throw new NotImplementedException();
    }

    public bool ExistePorId(int id)
    {
        throw new NotImplementedException();
    }

    public List<Usuario> listarUsuarios()
    {
        throw new NotImplementedException();
    }

    public void Modificar(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Usuario? ObtenerUsuario(int id)
    {
        throw new NotImplementedException();
    }
}