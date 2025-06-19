using System;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Entidades;

namespace CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;

public class RetirarPermisosUseCase(IRepositorioUsuario repoUsuario, IServicioAutorizacion Auth)
{
    public void Ejecutar(int id, List<Permiso> listaPermisos, Usuario usuario)
    {
        if (!Auth.PoseeElPermiso(usuario.Permisos, Permiso.UsuarioModificacion))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }
        if (!repoUsuario.ExistePorId(id))
        {
            throw new EntidadNotFoundException("El usuario no existe en la base de datos.");
        }

        repoUsuario.RetirarPermisos(id, listaPermisos);
    }
}
