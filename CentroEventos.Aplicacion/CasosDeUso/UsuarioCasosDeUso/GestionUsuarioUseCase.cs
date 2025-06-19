using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Enumerativos;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;

public class GestionUsuarioUseCase(IRepositorioUsuario repoUsuario, IServicioAutorizacion Auth)
{
    public void Ejecutar(Usuario usuario, List<Permiso> nuevosPermisos, Usuario administrador)
    {
        if (!Auth.PoseeElPermiso(administrador.Permisos, Permiso.UsuarioModificacion))
        {
            throw new FalloAutorizacionException("No tiene permiso para modificar usuarios.");
        }
        usuario.AsignarPermisos(nuevosPermisos);
        repoUsuario.Modificar(usuario);
    }
}
