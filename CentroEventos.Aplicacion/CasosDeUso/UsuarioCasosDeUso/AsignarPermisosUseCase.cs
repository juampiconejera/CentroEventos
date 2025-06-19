using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones;

namespace CentroEventos.Aplicacion.CasosDeUso.ServiciosCasosDeUso;

public class AsignarPermisosUseCase(IRepositorioUsuario repoUsuario, IServicioAutorizacion Auth)
{
    public void Ejecutar(int id, List<Permiso> listaPermisos, Usuario usuario)
    {
        if (!Auth.PoseeElPermiso(usuario.Permisos, Permiso.AsignarPermiso))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }
        if (!repoUsuario.ExistePorId(id))
        {
            throw new EntidadNotFoundException("El usuario no existe en la base de datos.");
        }

        repoUsuario.AsignarPermisos(id, listaPermisos);
    }
}
