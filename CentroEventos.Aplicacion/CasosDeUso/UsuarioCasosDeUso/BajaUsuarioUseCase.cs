using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;
using CentroEventos.Aplicacion.Enumerativos;


namespace CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;

public class BajaUsuarioUseCase(IRepositorioUsuario repoUsuario, IServicioAutorizacion Auth )
{
    public void Ejecutar(int id, Usuario usuario)
    {
        if (!Auth.PoseeElPermiso(usuario.Permisos, Permiso.UsuarioBaja))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        }
        if (!repoUsuario.ExistePorId(id))
        {
            throw new EntidadNotFoundException("El usuario no existe en la base de datos.");
        }

        repoUsuario.Eliminar(id);
    }
}
