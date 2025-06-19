using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
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

    public void AsignarPermisos(int id, List<Permiso> listaPermisos)        //ingresa la lista de permisos y lo agrego uno a uno
    {
        using (var context = new CentroEventosContext())
        {
            Usuario? usuario = context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                foreach (Permiso p in listaPermisos)
                {
                    usuario.Permisos.Add(p);
                }
                context.SaveChanges();
            }
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
        using (var context = new CentroEventosContext())
        {
            Usuario? usuario = context.Usuarios.FirstOrDefault(u => u.Email == email);
            return usuario != null;
        }
    }

    public bool ExistePorId(int id)
    {
        using (var context = new CentroEventosContext())
        {
            Usuario? usuario = context.Usuarios.FirstOrDefault(u => u.Id == id);
            return usuario != null;
        }
    }

    public List<Usuario> listarUsuarios()
    {
        using (var context = new CentroEventosContext())
        {
            return context.Usuarios.ToList();
        }
    }

    public void Modificar(Usuario usuarioNuevo)
    {
        using (var context = new CentroEventosContext())
        {
            Usuario? usuarioViejo = context.Usuarios.FirstOrDefault(u => u.Id == usuarioNuevo.Id);
            if (usuarioViejo != null)
            {
                usuarioViejo.Nombre = usuarioNuevo.Nombre;
                usuarioViejo.Apellido = usuarioNuevo.Apellido;
                usuarioViejo.Email = usuarioNuevo.Email;
                usuarioViejo.Password = usuarioNuevo.Password;
                context.SaveChanges();
            }
        }
    }

    public Usuario? ObtenerUsuario(int id)
    {
        using (var context = new CentroEventosContext())
        {
            Usuario? usuario = context.Usuarios.FirstOrDefault(u => u.Id == id);
            return usuario;
        }
    }
}