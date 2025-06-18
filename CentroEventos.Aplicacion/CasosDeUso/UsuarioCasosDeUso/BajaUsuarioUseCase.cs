using System;
using CentroEventos.Aplicacion.Entidades;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;


namespace CentroEventos.Aplicacion.CasosDeUso.UsuarioCasosDeUso;

public class BajaUsuarioUseCase(IRepositorioUsuario repoUsuario /*, IServicioAutorizacion Auth */)
{
    public void Ejecutar(int id, Usuario admin)
    {
        /* if (!Auth.PoseeElPermiso(admin))
        {
            throw new FalloAutorizacionException("Usuario no autorizado.");
        } */
        if (!repoUsuario.ExistePorId(id))
        {
            throw new EntidadNotFoundException("El usuario no existe en la base de datos.");
        }

        repoUsuario.Eliminar(id);
    }
}
