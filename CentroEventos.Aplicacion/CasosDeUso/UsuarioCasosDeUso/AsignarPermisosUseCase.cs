using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;

public class AsignarPermisosUseCase(IRepositorioUsuario repoUsuario, IServicioAutorizacion Auth)
{
    public void Ejecutar(int id, List<Permiso> nuevosPermisos, Usuario usuario)
    {
        if (!Auth.PoseeElPermiso(usuario.Permisos, Permiso.UsuarioModificacion))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }
        if (!repoUsuario.ExistePorId(id))
        {
            throw new EntidadNotFoundException("El usuario no existe en la base de datos.");
        }

        repoUsuario.AsignarPermisos(id, nuevosPermisos);
    }
}
