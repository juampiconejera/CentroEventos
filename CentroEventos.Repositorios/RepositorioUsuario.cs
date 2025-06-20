using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Servicios;

namespace CentroEventos.Repositorios;

public class RepositorioUsuario : IRepositorioUsuario
{
    IServicioSHA256 servicioSHA256 = new ServicioSHA256(); 
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
                    if (!usuario.Permisos.Contains(p))      //si no tiene el permiso, lo agrega
                    {
                        usuario.Permisos.Add(p);
                    }
                }
                context.SaveChanges();
            }
        }
    }

    public void RetirarPermisos(int id, List<Permiso> listaPermisos)
    {
        using (var context = new CentroEventosContext())
        {
            Usuario? usuario = context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                foreach (Permiso p in listaPermisos)
                {
                    if (usuario.Permisos.Contains(p))   //si tiene el permiso, lo elimina
                    {
                        usuario.Permisos.Remove(p);
                    }
                }
            }
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
                if (usuarioViejo.Password != usuarioNuevo.Password)
                {
                    //hago el hash
                    string newPass = servicioSHA256.getSha256(usuarioNuevo.Password);
                    usuarioViejo.Password = newPass;
                }
                context.SaveChanges();
            }
        }
    }

    public Usuario? ObtenerUsuarioPorId(int id)
    {
        using (var context = new CentroEventosContext())
        {
            Usuario? usuario = context.Usuarios.FirstOrDefault(u => u.Id == id);
            return usuario;
        }
    }
    public Usuario? ObtenerPorEmail(string email)
{
    using var context = new CentroEventosContext();
    return context.Usuarios.FirstOrDefault(u => u.Email == email);
}
}